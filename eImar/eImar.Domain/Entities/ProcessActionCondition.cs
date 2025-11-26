using System.ComponentModel.DataAnnotations.Schema;

namespace eImar.Domain.Entities
{
    public class ProcessActionCondition
    {
        public int Id { get; set; }
        public int OrderOfCondition { get; set; }
        public string ConditionedProcessEntryAnswerValue { get; set; } = string.Empty;

        public int ProcessActionId { get; set; }
        [ForeignKey("ProcessActionId")]
        public ProcessAction ProcessAction { get; set; } = null!;

        public int? ConditionedProcessEntryId { get; set; }
        [ForeignKey("ConditionedProcessEntryId")]
        public ProcessEntry? ConditionedProcessEntry { get; set; }

        public int? ConditionedApiId { get; set; }
        [ForeignKey("ConditionedApiId")]
        public Api? ConditionedApi { get; set; }

        public int ToProcessStepId { get; set; }
        [ForeignKey("ToProcessStepId")]
        public ProcessStep ToProcessStep { get; set; } = null!;
    }
}
