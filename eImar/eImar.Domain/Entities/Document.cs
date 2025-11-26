using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Filepath { get; set; } = string.Empty;
        public string EbysLink { get; set; } = string.Empty;
        public ICollection<Signature> Signatures { get; set; } = new List<Signature>();
        public ICollection<DocumentInProcessEntryAnswer> DocumentInProcessEntryAnswers { get; set; } = new List<DocumentInProcessEntryAnswer>();
    }
}
