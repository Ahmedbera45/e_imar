using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class WebUser
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Muellif> Muellifs { get; set; } = new List<Muellif>();
        public ICollection<ProcessApplication> ProcessApplications { get; set; } = new List<ProcessApplication>();
    }
}
