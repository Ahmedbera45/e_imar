namespace eImar.Domain.Entities
{
    public class DocumentInProcessEntryAnswer
    {
        public int Id { get; set; }
        public bool? IsApproved { get; set; }
        public int ProcessEntryAnswerId { get; set; }
        public ProcessEntryAnswer ProcessEntryAnswer { get; set; } = null!;
        public int DocumentRef { get; set; }
        public Document Document { get; set; } = null!;
    }
}
