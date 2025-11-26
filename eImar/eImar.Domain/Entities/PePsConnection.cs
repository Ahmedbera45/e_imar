namespace eImar.Domain.Entities
{
    public class PePsConnection
    {
        public int Id { get; set; }
        public int ViewType { get; set; }
        public bool? IsRequired { get; set; }
        public int ProcessStepRef { get; set; }
        public ProcessStep ProcessStep { get; set; } = null!;
        public int ProcessEntryRef { get; set; }
        public ProcessEntry ProcessEntry { get; set; } = null!;
    }
}
