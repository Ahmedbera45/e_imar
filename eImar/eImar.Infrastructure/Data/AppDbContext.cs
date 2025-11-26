using eImar.Application.Interfaces;
using eImar.Domain.Entities;
using eImar.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace eImar.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Entities from the database schema
        public DbSet<Process> Processes { get; set; }
        public DbSet<ProcessStep> ProcessSteps { get; set; }
        public DbSet<ProcessAction> ProcessActions { get; set; }
        public DbSet<ProcessRole> ProcessRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<ProcessApplication> ProcessApplications { get; set; }
        public DbSet<ProcessEntry> ProcessEntries { get; set; }
        public DbSet<ProcessEntryAnswer> ProcessEntryAnswers { get; set; }
        public DbSet<ProcessActionHistoryEntry> ProcessActionHistoryEntries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentInProcessEntryAnswer> DocumentInProcessEntryAnswers { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<DeveloperLog> DeveloperLogs { get; set; }
        public DbSet<Api> Apis { get; set; }
        public DbSet<ApiRequestParameter> ApiRequestParameters { get; set; }
        public DbSet<ApiResponseParameter> ApiResponseParameters { get; set; }
        public DbSet<Muellif> Muellifs { get; set; }
        public DbSet<MuellifType> MuellifTypes { get; set; }
        public DbSet<MuellifGroup> MuellifGroups { get; set; }
        public DbSet<MuellifGroupType> MuellifGroupTypes { get; set; }
        public DbSet<PePsConnection> PePsConnections { get; set; }
        public DbSet<ProcessActionCondition> ProcessActionConditions { get; set; }
        public DbSet<ProcessStepAuthorization> ProcessStepAuthorizations { get; set; }
        public DbSet<ProcessStepType> ProcessStepTypes { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply seed data
            WorkflowSeed.Seed(modelBuilder);
        }
    }
}
