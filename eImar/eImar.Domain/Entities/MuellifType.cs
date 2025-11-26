using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class MuellifType
    {
        public int Id { get; set; }
        public ICollection<Muellif> Muellifs { get; set; } = new List<Muellif>();
    }
}
