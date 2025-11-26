using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class MuellifGroupType
    {
        public int Id { get; set; }
        public ICollection<MuellifGroup> MuellifGroups { get; set; } = new List<MuellifGroup>();
    }
}
