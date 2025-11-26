using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class Muellif
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public int? PersonRef { get; set; }
        public Person? Person { get; set; }
        public ICollection<MuellifGroup> MuellifGroups { get; set; } = new List<MuellifGroup>();
        public ICollection<MuellifType> MuellifTypes { get; set; } = new List<MuellifType>();
        public ICollection<WebUser> WebUsers { get; set; } = new List<WebUser>();
    }
}
