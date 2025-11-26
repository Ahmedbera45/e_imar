using eImar.Api.DTOs;
using eImar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eImar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowsController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;

        public WorkflowsController(IWorkflowService workflowService)
        {
            _workflowService = workflowService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartProcess([FromBody] StartProcessRequest request)
        {
            // In a real app, this would be retrieved from the HttpContext.User
            var currentUserId = 1; // Simulating a logged-in user with ID 1 (e.g., an Admin)
            var processApplicationId = await _workflowService.StartProcessAsync(request.ProcessId, currentUserId, request.InitialData);
            return Ok(new { ProcessApplicationId = processApplicationId });
        }

        [HttpGet("{id}/state")]
        public async Task<IActionResult> GetProcessState(int id)
        {
            var state = await _workflowService.GetProcessStateAsync(id);
            return Ok(state);
        }

        [HttpGet("{id}/actions")]
        public async Task<IActionResult> GetAvailableActions(int id)
        {
            // In a real app, this would be retrieved from the HttpContext.User
            var currentUserId = 1; // Simulating a logged-in user
            var actions = await _workflowService.GetAvailableActionsAsync(id, currentUserId);
            return Ok(actions);
        }

        [HttpPost("{id}/execute")]
        public async Task<IActionResult> ExecuteAction(int id, [FromBody] ExecuteActionRequest request)
        {
            // In a real app, this would be retrieved from the HttpContext.User
            var currentUserId = 1; // Simulating a logged-in user
            await _workflowService.ExecuteActionAsync(id, request.ActionId, currentUserId, request.ActionData);
            return Ok();
        }
    }
}
