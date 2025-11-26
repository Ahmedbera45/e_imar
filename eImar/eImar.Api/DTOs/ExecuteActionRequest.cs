using System.Collections.Generic;

namespace eImar.Api.DTOs
{
    public class ExecuteActionRequest
    {
        public int ActionId { get; set; }
        public Dictionary<string, object> ActionData { get; set; }
    }
}
