using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class ProcessApplication
    {
        public int Id { get; set; }
        public int State { get; set; }

        public int ProcessRef { get; set; }
        public Process Process { get; set; } = null!;

        public int CurrentProcessStepRef { get; set; }
        public ProcessStep CurrentProcessStep { get; set; } = null!;

        public int BasvuranWebUserRef { get; set; }
        public WebUser BasvuranWebUser { get; set; } = null!;

        public ICollection<ProcessEntryAnswer> ProcessEntryAnswers { get; set; } = new List<ProcessEntryAnswer>();
        public ICollection<ProcessActionHistoryEntry> ProcessActionHistoryEntries { get; set; } = new List<ProcessActionHistoryEntry>();
    }
}
