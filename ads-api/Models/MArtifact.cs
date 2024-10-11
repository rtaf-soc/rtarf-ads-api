using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("Artifacts")]
    public class MArtifact
    {
        [Key]
        [Column("artifact_id")]
        public Guid? ArtifactId { get; set; }
        
        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("artifact_code")] /* IP, Domain, Hash, File Name */
        public string? ArtifactCode { get; set; }

        [Column("tags")] /* Comma separate --> MISP,Blacklist */
        public string? Tags { get; set; }

        [Column("artifact_type")] /* 1=IP, 2=Domain, 3=Hash, 4=FileName */
        public int? ArtifactType { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MArtifact()
        {
            ArtifactId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
