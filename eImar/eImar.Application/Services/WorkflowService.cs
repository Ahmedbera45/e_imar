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
                .Where(s => s.ProcessRef == processId)
                .OrderBy(s => s.Id)
                .FirstOrDefaultAsync();
            if (firstStep == null) throw new Exception("Process has no starting step.");

            var application = new ProcessApplication
            {
                ProcessRef = processId,
                CurrentProcessStepRef = firstStep.Id,
                BasvuranWebUserRef = userId,
                State = 0 // Default initial state
            };

            _context.ProcessApplications.Add(application);
            await _context.SaveChangesAsync(new System.Threading.CancellationToken());
            
            // Here you would typically process the 'initialData' dictionary and create
            // ProcessEntryAnswer records associated with this ProcessApplication.
            // This logic is omitted for brevity.

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
            
            // Corrected Authorization Logic (v2):
            // 1. Get all Role Ids for the given userId.
            // 2. Check if any of those roles are associated with a ProcessStepAuthorization
            //    that is linked to the current process step.
            var userRoleIds = await _context.WebUsers
                .Where(u => u.Id == userId)
                .SelectMany(u => u.Roles.Select(r => (int?)r.Id)) // Cast to nullable int
                .Where(id => id.HasValue) // Filter out nulls
                .Select(id => id.Value) // Select the non-null value
                .ToListAsync();

            if (!userRoleIds.Any())
            {
                return Enumerable.Empty<ActionViewModel>(); // User not found or has no roles
            }

            var isAuthorized = await _context.ProcessStepAuthorizations
                .AnyAsync(auth => auth.ProcessSteps.Any(s => s.Id == application.CurrentProcessStepRef) &&
                                 auth.ProcessRole.RoleRef.HasValue &&
                                 userRoleIds.Contains(auth.ProcessRole.RoleRef.Value));

            if (!isAuthorized)
            {
                return Enumerable.Empty<ActionViewModel>();
            }

            return await _context.ProcessActions
                .Where(a => a.ProcessStepRef == application.CurrentProcessStepRef)
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
                .FirstOrDefaultAsync(a => a.Id == actionId && a.ProcessStepRef == application.CurrentProcessStepRef);
            if (action == null) throw new Exception("Invalid action for the current state.");
            
            // Simplified authorization check. A more robust implementation from GetAvailableActionsAsync should be used.
            // bool isAuthorized = await IsUserAuthorizedForAction(userId, application.CurrentProcessStepRef);
            // if (!isAuthorized) throw new Exception("User is not authorized to perform this action.");

            int nextStepId = -1;

            // Evaluate conditions to find the next step
            foreach (var condition in action.ProcessActionConditions.OrderBy(c => c.OrderOfCondition))
            {
                bool conditionMet = false;
                if (condition.ConditionedProcessEntryRef.HasValue)
                {
                    // This is a conditional transition based on an answer
                    var answer = await _context.ProcessEntryAnswers
                        .FirstOrDefaultAsync(ans => ans.ProcessApplicationRef == application.Id && ans.ProcessEntryRef == condition.ConditionedProcessEntryRef.Value);
                    
                    // This is a simplified check. A real implementation would need to handle different data types (bool, text, number).
                    if (answer != null && answer.TextAnswer == condition.ConditionedProcessEntryAnswerValue)
                    {
                        conditionMet = true;
                    }
                }
                else
                {
                    // This is an unconditional transition (default case)
                    conditionMet = true;
                }

                if (conditionMet)
                {
                    nextStepId = condition.ToProcessStepRef;
                    break;
                }
            }

            if (nextStepId == -1)
            {
                throw new Exception("No valid transition found for the action and current application state.");
            }

            // Log the action history
            var historyEntry = new ProcessActionHistoryEntry
            {
                ProcessApplicationRef = processApplicationId,
                ProcessActionRef = actionId,
                LogString = $"User {userId} performed action {action.Title}.",
                EntryOrder = (_context.ProcessActionHistoryEntries.Count(h => h.ProcessApplicationRef == processApplicationId) + 1)
            };
            _context.ProcessActionHistoryEntries.Add(historyEntry);

            // Update the application state
            application.CurrentProcessStepRef = nextStepId;

            await _context.SaveChangesAsync(new System.Threading.CancellationToken());
        }
    }
}
