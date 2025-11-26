using eImar.Application.Interfaces;
using eImar.Application.ViewModels;
using eImar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eImar.Application.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IAppDbContext _context;

        public WorkflowService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> StartProcessAsync(int processId, int userId, Dictionary<string, object> initialData)
        {
            var process = await _context.Processes.FindAsync(processId);
            if (process == null) throw new Exception("Process not found.");

            var firstStep = await _context.ProcessSteps
                .Where(s => s.ProcessId == processId) // Ref -> Id
                .OrderBy(s => s.Id)
                .FirstOrDefaultAsync();
            if (firstStep == null) throw new Exception("Process has no starting step.");

            var application = new ProcessApplication
            {
                ProcessId = processId, // Ref -> Id
                CurrentProcessStepId = firstStep.Id, // Ref -> Id
                BasvuranWebUserId = userId, // Ref -> Id
                State = 0 
            };

            _context.ProcessApplications.Add(application);
            await _context.SaveChangesAsync(new System.Threading.CancellationToken());
            return application.Id;
        }

        public async Task<ProcessStateViewModel> GetProcessStateAsync(int processApplicationId)
        {
            var application = await _context.ProcessApplications
                .Include(a => a.CurrentProcessStep)
                .FirstOrDefaultAsync(a => a.Id == processApplicationId);

            if (application == null) throw new Exception("Application not found.");

            return new ProcessStateViewModel
            {
                ProcessApplicationId = application.Id,
                CurrentStateName = application.CurrentProcessStep.Title,
                CurrentStateDescription = application.CurrentProcessStep.DisplayTitle
            };
        }

        public async Task<IEnumerable<ActionViewModel>> GetAvailableActionsAsync(int processApplicationId, int userId)
        {
            var application = await _context.ProcessApplications.FindAsync(processApplicationId);
            if (application == null) throw new Exception("Application not found.");
            
            // Kullanıcı yetki kontrolü
            var userRoleIds = await _context.WebUsers
                .Where(u => u.Id == userId)
                .SelectMany(u => u.Roles.Select(r => (int?)r.Id))
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToListAsync();

            if (!userRoleIds.Any()) return Enumerable.Empty<ActionViewModel>();

            // Ref -> Id değişiklikleri burada kritik
            var isAuthorized = await _context.ProcessStepAuthorizations
                .AnyAsync(auth => auth.ProcessSteps.Any(s => s.Id == application.CurrentProcessStepId) &&
                                 auth.ProcessRole.RoleId.HasValue && // Ref -> Id
                                 userRoleIds.Contains(auth.ProcessRole.RoleId.Value));

            if (!isAuthorized) return Enumerable.Empty<ActionViewModel>();

            return await _context.ProcessActions
                .Where(a => a.ProcessStepId == application.CurrentProcessStepId) // Ref -> Id
                .Select(a => new ActionViewModel
                {
                    ActionId = a.Id,
                    ActionName = a.Title
                })
                .ToListAsync();
        }

        public async Task ExecuteActionAsync(int processApplicationId, int actionId, int userId, Dictionary<string, object> actionData)
        {
            var application = await _context.ProcessApplications.FindAsync(processApplicationId);
            if (application == null) throw new Exception("Application not found.");

            var action = await _context.ProcessActions
                .Include(a => a.ProcessActionConditions)
                .FirstOrDefaultAsync(a => a.Id == actionId && a.ProcessStepId == application.CurrentProcessStepId); // Ref -> Id
            
            if (action == null) throw new Exception("Invalid action for the current state.");

            int nextStepId = -1;

            foreach (var condition in action.ProcessActionConditions.OrderBy(c => c.OrderOfCondition))
            {
                bool conditionMet = false;
                if (condition.ConditionedProcessEntryId.HasValue) // Ref -> Id
                {
                    var answer = await _context.ProcessEntryAnswers
                        .FirstOrDefaultAsync(ans => ans.ProcessApplicationId == application.Id && ans.ProcessEntryId == condition.ConditionedProcessEntryId.Value); // Ref -> Id
                    
                    if (answer != null && answer.TextAnswer == condition.ConditionedProcessEntryAnswerValue)
                    {
                        conditionMet = true;
                    }
                }
                else
                {
                    conditionMet = true; // Koşulsuz geçiş
                }

                if (conditionMet)
                {
                    nextStepId = condition.ToProcessStepId; // Ref -> Id
                    break;
                }
            }

            if (nextStepId == -1) throw new Exception("No valid transition found.");

            // Loglama
            var historyEntry = new ProcessActionHistoryEntry
            {
                ProcessApplicationId = processApplicationId, // Ref -> Id
                ProcessActionId = actionId, // Ref -> Id
                LogString = $"User {userId} performed action {action.Title}.",
                EntryOrder = (_context.ProcessActionHistoryEntries.Count(h => h.ProcessApplicationId == processApplicationId) + 1)
            };
            _context.ProcessActionHistoryEntries.Add(historyEntry);

            // Durumu güncelle
            application.CurrentProcessStepId = nextStepId; // Ref -> Id

            await _context.SaveChangesAsync(new System.Threading.CancellationToken());
        }
    }
}
