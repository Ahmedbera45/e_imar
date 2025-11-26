using System.ComponentModel.DataAnnotations.Schema; // Bu satır ForeignKey hatasını çözer

namespace eImar.Domain.Entities
{
    public class ProcessActionHistoryEntry
    {
        public int Id { get; set; }
        public int EntryOrder { get; set; }
        public string LogString { get; set; } = string.Empty;

        // Ref -> Id dönüşümü
        public int ProcessActionId { get; set; }
        
        [ForeignKey("ProcessActionId")]
        public ProcessAction ProcessAction { get; set; } = null!;

        // Ref -> Id dönüşümü
        public int ProcessApplicationId { get; set; }
        
        [ForeignKey("ProcessApplicationId")]
        public ProcessApplication ProcessApplication { get; set; } = null!;
    }
}
