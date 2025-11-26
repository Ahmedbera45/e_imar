using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class ProcessStep
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string DisplayTitle { get; set; } = string.Empty;

        public int ProcessRef { get; set; }
        public Process Process { get; set; } = null!;

        public int ProcessStepTypeRef { get; set; }
        public ProcessStepType ProcessStepType { get; set; } = null!;

        public ICollection<ProcessStepAuthorization> ProcessStepAuthorizations { get; set; } = new List<ProcessStepAuthorization>();
        public ICollection<PePsConnection> PePsConnections { get; set; } = new List<PePsConnection>();
        public ICollection<ProcessAction> ProcessActions { get; set; } = new List<ProcessAction>();
    }
}
