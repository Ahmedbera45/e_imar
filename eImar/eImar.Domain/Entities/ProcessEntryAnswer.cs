using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; // Bu satırı eklemeyi unutma!

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

        // --- DEĞİŞİKLİK BURADA ---
        // Eskiden 'ProcessApplicationRef' idi, 'ProcessApplicationId' yaptık.
        public int ProcessApplicationId { get; set; }
        
        [ForeignKey("ProcessApplicationId")]
        public ProcessApplication ProcessApplication { get; set; } = null!;

        // --- DEĞİŞİKLİK BURADA ---
        // Eskiden 'ProcessEntryRef' idi, 'ProcessEntryId' yaptık.
        public int ProcessEntryId { get; set; }

        [ForeignKey("ProcessEntryId")]
        public ProcessEntry ProcessEntry { get; set; } = null!;

        public ICollection<DocumentInProcessEntryAnswer> DocumentInProcessEntryAnswers { get; set; } = new List<DocumentInProcessEntryAnswer>();
    }
}
