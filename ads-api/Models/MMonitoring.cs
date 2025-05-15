using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("Monitoring")]
    [Index(nameof(OrgId), IsUnique = false, Name = "Monitoring_OrgId_Idx1")]
    [Index(nameof(Name), IsUnique = true, Name = "Monitoring_Name_Idx2")]

    public class MMonitoring
    {
        [Key]
        [Column("monitoring_id")]
        public Guid? Id { get; set; }
    
        [Column("name")]
        public string? Name { get; set; }

        [Column("check_date")]
        public DateTime? CheckDate { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("uptime_pct")]
        public int? UptimePct { get; set; }

        [Column("success_check_count")]
        public int? SuccessCount { get; set; }

        [Column("total_check_count")]
        public int? TotalCount { get; set; }
                
        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MMonitoring()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
