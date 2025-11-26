using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class ProcessRole
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int ProcessId { get; set; }
        [ForeignKey("ProcessId")]
        public Process Process { get; set; } = null!;

        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }

        public int? MuellifGroupId { get; set; }
        [ForeignKey("MuellifGroupId")]
        public MuellifGroup? MuellifGroup { get; set; }

        public int? MuellifTypeId { get; set; }
        [ForeignKey("MuellifTypeId")]
        public MuellifType? MuellifType { get; set; }

        public ICollection<Person> People { get; set; } = new List<Person>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
