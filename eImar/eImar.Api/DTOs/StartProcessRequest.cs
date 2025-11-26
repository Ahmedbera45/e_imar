using System.Collections.Generic;

namespace eImar.Api.DTOs
{
    public class StartProcessRequest
    {
        public int ProcessId { get; set; }
        public Dictionary<string, object> InitialData { get; set; }
    }
}
