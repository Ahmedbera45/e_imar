using eImar.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eImar.Application.Interfaces
{
    public interface IWorkflowService
    {
        Task<int> StartProcessAsync(int processId, int userId, Dictionary<string, object> initialData);
        Task<ProcessStateViewModel> GetProcessStateAsync(int processApplicationId);
        Task<IEnumerable<ActionViewModel>> GetAvailableActionsAsync(int processApplicationId, int userId);
        Task ExecuteActionAsync(int processApplicationId, int actionId, int userId, Dictionary<string, object> actionData);
    }
}
