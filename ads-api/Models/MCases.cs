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


        [Column("case_title")]
        public string? CaseTitle { get; set; }

        [Column("case_ref_id")]
        public string? CaseRefId { get; set; }

        [Column("case_pap")]
        public string? CasePap { get; set; }

        [Column("case_severity")]
        public string? CaseSeverity { get; set; }

        [Column("case_summary")]
        public string? CaseSummary { get; set; }

        [Column("update_by")]
        public string? UpdateBy { get; set; }

        [Column("solution_status")]
        public string? ResolutionStatus { get; set; }

        [Column("case_tlp")]
        public string? CaseTlp { get; set; }

        [Column("impact_status")]
        public string? ImpactStatus { get; set; }

        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        [Column("update_at")]
        public DateTime? UpdateAt { get; set; }

        [Column("tags")]
        public string? Tags { get; set; }

        [Column("flags")]
        public string? Flag { get; set; }

        [Column("custom_fields")]
        public string? CustomFields { get; set; }

        [Column("created_by")]
        public string? CreatedBy { get; set; }

        [Column("metrics")]
        public string? Metrics { get; set; }

        [Column("case_end_date")]
        public DateTime? CaseEndDate { get; set; }

        [Column("merge_into")]
        public string? MergeInto { get; set; }

        [Column("merge_from")]
        public string? MergeFrom { get; set; }

        public MCases()
        {
            CaseId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
