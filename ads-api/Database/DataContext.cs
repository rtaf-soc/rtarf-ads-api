namespace Its.Ads.Api.Database;

using Its.Ads.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class DataContext : DbContext, IDataContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration, DbContextOptions<DataContext> options) : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<MOrganization>? Organizations { get; set; }
    public DbSet<MApiKey>? ApiKeys { get; set; }
    public DbSet<MRole>? Roles { get; set; }
    public DbSet<MUser>? Users { get; set; }
    public DbSet<MOrganizationUser>? OrganizationUsers { get; set; }
    public DbSet<MWorkflowTemplate>? WorkflowTemplates { get; set; }
    public DbSet<MWorkFlow>? Workflows { get; set; }
    public DbSet<MBlacklist>? Blacklists { get; set; }
    public DbSet<MIpMap>? IpMaps { get; set; }
    public DbSet<MIocHost>? IocHosts { get; set; }
    public DbSet<MSystemVariable>? SystemVariables { get; set; }
    public DbSet<MLogAggregate>? LogAggregates { get; set; }
    public DbSet<MHuntingRule>? HuntingRules { get; set; }
    public DbSet<MCases>? Cases { get; set; }
    public DbSet<MLogAggregateFirewall>? LogAggregatesFirewall { get; set; }
    public DbSet<MMonitoring>? Monitorings { get; set; }
    public DbSet<MCsMachineStat>? CsMachineStats { get; set; }
    public DbSet<MDevice>? Devices { get; set; }
    public DbSet<MDepartment>? Departments { get; set; }
    public DbSet<MThreat>? Threats { get; set; }
    public DbSet<MNewsFeed>? NewsFeed { get; set; }
    public DbSet<MNote>? Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MOrganization>();
        modelBuilder.Entity<MApiKey>();
        modelBuilder.Entity<MRole>();
        modelBuilder.Entity<MUser>();
        modelBuilder.Entity<MOrganizationUser>();
        modelBuilder.Entity<MWorkflowTemplate>();
        modelBuilder.Entity<MWorkFlow>();
        modelBuilder.Entity<MBlacklist>();
        modelBuilder.Entity<MIpMap>();
        modelBuilder.Entity<MIocHost>();
        modelBuilder.Entity<MSystemVariable>();
        modelBuilder.Entity<MLogAggregate>();
        modelBuilder.Entity<MHuntingRule>();
        modelBuilder.Entity<MCases>();
        modelBuilder.Entity<MLogAggregateFirewall>();
        modelBuilder.Entity<MHuntingRule>();
        modelBuilder.Entity<MCsMachineStat>();
        modelBuilder.Entity<MDevice>();
        modelBuilder.Entity<MDepartment>();
        modelBuilder.Entity<MThreat>();
        modelBuilder.Entity<MNewsFeed>();
        modelBuilder.Entity<MNote>();
    }
}
