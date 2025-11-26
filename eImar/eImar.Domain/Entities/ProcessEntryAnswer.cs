using System;
using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class ProcessEntryAnswer
    {
        public int Id { get; set; }
        public string TextAnswer { get; set; } = string.Empty;
        public DateTime? DatetimeAnswer { get; set; }
        public string BoolAnswer { get; set; } = string.Empty;
        public string TcAnswer { get; set; } = string.Empty;
        public string PhoneAnswer { get; set; } = string.Empty;
        public string EmailAnswer { get; set; } = string.Empty;
        public bool? IsApproved { get; set; }
        public string NumberAnswer { get; set; } = string.Empty;
        public string TahakkukId { get; set; } = string.Empty;
        public bool? TahakkukYapilmisMi { get; set; }

        public int ProcessApplicationRef { get; set; }
        public ProcessApplication ProcessApplication { get; set; } = null!;

        public int ProcessEntryRef { get; set; }
        public ProcessEntry ProcessEntry { get; set; } = null!;

        public ICollection<DocumentInProcessEntryAnswer> DocumentInProcessEntryAnswers { get; set; } = new List<DocumentInProcessEntryAnswer>();
    }
}
