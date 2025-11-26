using eImar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace eImar.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Process> Processes { get; set; }
        DbSet<ProcessStep> ProcessSteps { get; set; }
        DbSet<ProcessAction> ProcessActions { get; set; }
        DbSet<ProcessRole> ProcessRoles { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<WebUser> WebUsers { get; set; }
        DbSet<ProcessApplication> ProcessApplications { get; set; }
        DbSet<ProcessEntry> ProcessEntries { get; set; }
        DbSet<ProcessEntryAnswer> ProcessEntryAnswers { get; set; }
        DbSet<ProcessActionHistoryEntry> ProcessActionHistoryEntries { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<DocumentInProcessEntryAnswer> DocumentInProcessEntryAnswers { get; set; }
        DbSet<Signature> Signatures { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<AuditLog> AuditLogs { get; set; }
        DbSet<DeveloperLog> DeveloperLogs { get; set; }
        DbSet<Api> Apis { get; set; }
        DbSet<ApiRequestParameter> ApiRequestParameters { get; set; }
        DbSet<ApiResponseParameter> ApiResponseParameters { get; set; }
        DbSet<Muellif> Muellifs { get; set; }
        DbSet<MuellifType> MuellifTypes { get; set; }
        DbSet<MuellifGroup> MuellifGroups { get; set; }
        DbSet<MuellifGroupType> MuellifGroupTypes { get; set; }
        DbSet<PePsConnection> PePsConnections { get; set; }
        DbSet<ProcessActionCondition> ProcessActionConditions { get; set; }
        DbSet<ProcessStepAuthorization> ProcessStepAuthorizations { get; set; }
        DbSet<ProcessStepType> ProcessStepTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
