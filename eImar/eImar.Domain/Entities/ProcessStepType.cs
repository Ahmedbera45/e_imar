using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class ProcessStepType
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public ICollection<ProcessStep> ProcessSteps { get; set; } = new List<ProcessStep>();
    }
}
