namespace eImar.Domain.Entities
{
    public class ApiRequestParameter
    {
        public int Id { get; set; }
        public string ParameterName { get; set; } = string.Empty;
        public string StaticValue { get; set; } = string.Empty;
        public int ApiRef { get; set; }
        public Api Api { get; set; } = null!;
        public int? ProcessEntryRef { get; set; }
        public ProcessEntry? ProcessEntry { get; set; }
    }
}
