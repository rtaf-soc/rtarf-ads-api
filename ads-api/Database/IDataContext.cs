using Microsoft.EntityFrameworkCore;
using Its.Ads.Api.Models;

namespace Its.Ads.Api.Database
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        public DbSet<MOrganization>? Organizations { get; set; }
        public DbSet<MApiKey>? ApiKeys { get; set; }
        public DbSet<MRole>? Roles { get; set; }
        public DbSet<MUser>? Users { get; set; }
        public DbSet<MOrganizationUser>? OrganizationUsers { get; set; }
        public DbSet<MWorkFlow>? Workflows { get; set; }
        public DbSet<MBlacklist>? Blacklists { get; set; }
        public DbSet<MIpMap>? IpMaps { get; set; }
        public DbSet<MIocHost>? IocHosts { get; set; }
        public DbSet<MSystemVariable>? SystemVariables { get; set; }
        public DbSet<MLogAggregate>? LogAggregates { get; set; }
        public DbSet<MHuntingRule>? HuntingRules { get; set; }
        public DbSet<MMonitoring>? Monitorings { get; set; }
        public DbSet<MCsMachineStat>? CsMachineStats { get; set; }
        public DbSet<MDevice>? Devices { get; set; }
        public DbSet<MDepartment>? Departments { get; set; }
        public DbSet<MThreat>? Threats { get; set; }
        public DbSet<MNewsFeed>? NewsFeed { get; set; }
        public DbSet<MNote>? Notes { get; set; }
    }
}