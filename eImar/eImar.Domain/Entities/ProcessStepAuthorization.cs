using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class ProcessStepAuthorization
    {
        public int Id { get; set; }
        public int? Yetki { get; set; }

        public int ProcessRoleRef { get; set; }
        public ProcessRole ProcessRole { get; set; } = null!;

        public ICollection<ProcessStep> ProcessSteps { get; set; } = new List<ProcessStep>();
    }
}
