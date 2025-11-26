using System.Collections.Generic;

namespace eImar.Domain.Entities
{
    public class ProcessEntry
    {
        public int Id { get; set; }
        public bool Shared { get; set; }
        public int Type { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string KeywordName { get; set; } = string.Empty;
        public string Classtype { get; set; } = string.Empty;
        public string? AllowedDocumentExtensions { get; set; }
        public bool? MultipleFileAllowed { get; set; }
        public bool? EbysKayitYapilacakMi { get; set; }
        public string? Options { get; set; }
        public string? TahakkukKalemiId { get; set; }

        public int? ProcessRoleRef { get; set; }
        public ProcessRole? ProcessRole { get; set; }

        public int? WebUserRef { get; set; }
        public WebUser? WebUser { get; set; }

        public ICollection<Process> Processes { get; set; } = new List<Process>();
        public ICollection<PePsConnection> PePsConnections { get; set; } = new List<PePsConnection>();
        public ICollection<ProcessEntryAnswer> ProcessEntryAnswers { get; set; } = new List<ProcessEntryAnswer>();
        public ICollection<ApiRequestParameter> ApiRequestParameters { get; set; } = new List<ApiRequestParameter>();
        public ICollection<ApiResponseParameter> ApiResponseParameters { get; set; } = new List<ApiResponseParameter>();
        public ICollection<ProcessActionCondition> ProcessActionConditions { get; set; } = new List<ProcessActionCondition>();
    }
}
