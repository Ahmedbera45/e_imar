using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class Api
    {
        public int Id { get; set; }
        public string ApiName { get; set; } = string.Empty;
        public ICollection<ApiRequestParameter> ApiRequestParameters { get; set; } = new List<ApiRequestParameter>();
        public ICollection<ApiResponseParameter> ApiResponseParameters { get; set; } = new List<ApiResponseParameter>();
        public ICollection<ProcessActionCondition> ProcessActionConditions { get; set; } = new List<ProcessActionCondition>();
    }
}
