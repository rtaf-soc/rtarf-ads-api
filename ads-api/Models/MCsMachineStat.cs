using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("CsMachineStat")]
    [Index(nameof(OrgId), IsUnique = false, Name = "MachineStat_OrgId_Idx1")]
    [Index(nameof(Name), IsUnique = true, Name = "MachineStat_Name_Idx1")]
    [Index(nameof(Department), IsUnique = false, Name = "MachineStat_Department_Idx1")]

    public class MCsMachineStat
    {
        [Key]
        [Column("machine_stat_id")]
        public Guid? Id { get; set; }

        [Column("machine_name")]
        public string? Name { get; set; }

        [Column("department_name")]
        public string? Department { get; set; }

        [Column("last_cs_event_date")]
        public DateTime? LastCsEventDate { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("cs_event_count")]
        public int? UptimePct { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MCsMachineStat()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
