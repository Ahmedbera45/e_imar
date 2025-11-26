namespace eImar.Domain.Entities
{
    public class ProcessActionHistoryEntry
    {
        public int Id { get; set; }
        public int EntryOrder { get; set; }
        public string LogString { get; set; } = string.Empty;

        public int ProcessActionRef { get; set; }
        public ProcessAction ProcessAction { get; set; } = null!;

        public int ProcessApplicationRef { get; set; }
        public ProcessApplication ProcessApplication { get; set; } = null!;
    }
}
