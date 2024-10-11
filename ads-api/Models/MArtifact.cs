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

        [Column("artifact_code")] /* SourceIP, DestIP, Domain, Hash, File Name */
        public string? ArtifactCode { get; set; }

        [Column("tags")] /* Comma separate --> MISP,Blacklist */
        public string? Tags { get; set; }

        [Column("artifact_type")] /* 1=SrcIP, 2=DestIP, 3=Domain, 4=Hash, 5=FileName */
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
