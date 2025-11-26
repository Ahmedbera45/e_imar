using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class MuellifGroup
    {
        public int Id { get; set; }
        public ICollection<Muellif> Muellifs { get; set; } = new List<Muellif>();
        public ICollection<MuellifGroupType> MuellifGroupTypes { get; set; } = new List<MuellifGroupType>();
    }
}
