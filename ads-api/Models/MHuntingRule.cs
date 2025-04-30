using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("HuntingRules")]
    [Index(nameof(RuleName), IsUnique = true)]
    [Index(nameof(OrgId))]
    public class MHuntingRule
    {
        [Key]
        [Column("rule_id")]
        public Guid? RuleId { get; set; }
    
        [Column("rule_name")]
        public string? RuleName { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("rule_created_date")]
        public DateTime? RuleCreatedDate { get; set; }

        [Column("rule_description")]
        public string? RuleDescription { get; set; }

        [Column("rule_definition")]
        public string? RuleDefinition { get; set; }

        [Column("ref_url")]
        public string? RefUrl { get; set; }

        [Column("tags")]
        public string? Tags { get; set; }

        public MHuntingRule()
        {
            RuleId = Guid.NewGuid();
            RuleCreatedDate = DateTime.UtcNow;
        }
    }
}
