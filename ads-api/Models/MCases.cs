using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("Cases")]
    [Index(nameof(CaseNo), IsUnique = true, Name = "Case_No_Idx1")]
    [Index(nameof(OrgId), IsUnique = false, Name = "Case_OrgId_Idx1")]
    [Index(nameof(CaseStatus), IsUnique = false, Name = "Case_Status_Idx1")]
    [Index(nameof(CaseOwner), IsUnique = false, Name = "Case_Owner_Idx1")]

    public class MCases
    {
        [Key]
        [Column("case_id")]
        public Guid? CaseId { get; set; }
    
        [Column("case_no")]
        public string? CaseNo { get; set; }

        [Column("case_date")]
        public DateTime? CaseDate { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("case_status")]
        public string? CaseStatus { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("incident_type")]
        public string? IncidentType { get; set; }
        
        [Column("case_owner")]
        public string? CaseOwner { get; set; }
        
        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MCases()
        {
            CaseId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
