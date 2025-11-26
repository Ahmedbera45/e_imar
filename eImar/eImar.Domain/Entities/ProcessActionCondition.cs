namespace eImar.Domain.Entities
{
    public class ProcessActionCondition
    {
        public int Id { get; set; }
        public int OrderOfCondition { get; set; }
        public string ConditionedProcessEntryAnswerValue { get; set; } = string.Empty;

        public int ProcessActionRef { get; set; }
        public ProcessAction ProcessAction { get; set; } = null!;

        public int? ConditionedProcessEntryRef { get; set; }
        public ProcessEntry? ConditionedProcessEntry { get; set; }

        public int? ConditionedApiRef { get; set; }
        public Api? ConditionedApi { get; set; }

        public int ToProcessStepRef { get; set; }
        public ProcessStep ToProcessStep { get; set; } = null!;
    }
}
