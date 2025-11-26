using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class ProcessRole
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int ProcessRef { get; set; }
        public Process Process { get; set; } = null!;

        public int? RoleRef { get; set; }
        public Role? Role { get; set; }

        public int? MuellifGroupRef { get; set; }
        public MuellifGroup? MuellifGroup { get; set; }

        public int? MuellifTypeRef { get; set; }
        public MuellifType? MuellifType { get; set; }

        public ICollection<Person> People { get; set; } = new List<Person>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
