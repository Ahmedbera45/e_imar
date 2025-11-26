using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class Process
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public ICollection<ProcessStep> ProcessSteps { get; set; } = new List<ProcessStep>();
        public ICollection<ProcessRole> ProcessRoles { get; set; } = new List<ProcessRole>();
        public ICollection<ProcessApplication> ProcessApplications { get; set; } = new List<ProcessApplication>();
        public ICollection<ProcessEntry> ProcessEntries { get; set; } = new List<ProcessEntry>();
    }
}
