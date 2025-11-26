using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Tc { get; set; } = string.Empty;
        public ICollection<ProcessRole> ProcessRoles { get; set; } = new List<ProcessRole>();
    }
}
