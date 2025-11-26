using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Text { get; set; } = string.Empty;
        public ICollection<ProcessRole> ProcessRoles { get; set; } = new List<ProcessRole>();
        public ICollection<ProcessAction> ProcessActions { get; set; } = new List<ProcessAction>();
    }
}
