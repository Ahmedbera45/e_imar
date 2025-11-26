using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class ProcessAction
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public int ProcessStepRef { get; set; }
        public ProcessStep ProcessStep { get; set; } = null!;

        public int? DefaultProcessActionConditionRef { get; set; }
        public ProcessActionCondition? DefaultProcessActionCondition { get; set; }

        public ICollection<ProcessActionCondition> ProcessActionConditions { get; set; } = new List<ProcessActionCondition>();
        public ICollection<ProcessActionHistoryEntry> ProcessActionHistoryEntries { get; set; } = new List<ProcessActionHistoryEntry>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
