using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        
        public ICollection<WebUser> WebUsers { get; set; } = new List<WebUser>();
        public ICollection<ProcessRole> ProcessRoles { get; set; } = new List<ProcessRole>();
    }
}
