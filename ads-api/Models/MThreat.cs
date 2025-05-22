using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("Threats")]
    [Index(nameof(EventNo), IsUnique = true)]
    [Index(nameof(OrgId))]

    public class MThreat
    {
        [Key]
        [Column("threat_id")]
        public Guid? Id { get; set; }

        [Column("event_no")]
        public string? EventNo { get; set; }

        [Column("event_date")]
        public DateTime? EventDate { get; set; }

        [Column("incident_type")]
        public string? IncidentType { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("target_address")]
        public string? TargetAddress { get; set; }

        [Column("action")]
        public string? Action { get; set; }

        [Column("owner")]
        public string? Owner { get; set; }

        [Column("detected_by")]
        public string? DetectedBy { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MThreat()
        {
            Id = Guid.NewGuid();
        }
    }
}
