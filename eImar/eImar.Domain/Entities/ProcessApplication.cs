using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class ProcessApplication
    {
        public int Id { get; set; }
        public int State { get; set; }

        public int ProcessId { get; set; }
        [ForeignKey("ProcessId")]
        public Process Process { get; set; } = null!;

        public int CurrentProcessStepId { get; set; }
        [ForeignKey("CurrentProcessStepId")]
        public ProcessStep CurrentProcessStep { get; set; } = null!;

        public int BasvuranWebUserId { get; set; }
        [ForeignKey("BasvuranWebUserId")]
        public WebUser BasvuranWebUser { get; set; } = null!;

        public ICollection<ProcessEntryAnswer> ProcessEntryAnswers { get; set; } = new List<ProcessEntryAnswer>();
        public ICollection<ProcessActionHistoryEntry> ProcessActionHistoryEntries { get; set; } = new List<ProcessActionHistoryEntry>();
    }
}
