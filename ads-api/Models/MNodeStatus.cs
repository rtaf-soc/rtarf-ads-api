using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using NetTopologySuite.Geometries;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("NodeStatus")]
    public class MNodeStatus
    {
        [Key]
        [Column("node_status_id")]
        public Guid? Id { get; set; }
        
        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("node_id")]
        public Guid? NodeId { get; set; }

        [Column("layer")]
        public string? Layer { get; set; }

        [Column("status")]
        public string? Status { get; set; } /* JSON string - array of key-value object */


        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        public string? NodeName { get; set; }
        [NotMapped]
        public string? NodeDescription { get; set; }
        [NotMapped]
        public string? NodeType { get; set; }
        [NotMapped]
        public string? NodeTags { get; set; }


        public MNodeStatus()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
