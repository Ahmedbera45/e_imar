namespace eImar.Domain.Entities
{
    public class ApiResponseParameter
    {
        public int Id { get; set; }
        public string ParameterName { get; set; } = string.Empty;
        public int ApiRef { get; set; }
        public Api Api { get; set; } = null!;
        public int? ProcessEntryRef { get; set; }
        public ProcessEntry? ProcessEntry { get; set; }
    }
}
