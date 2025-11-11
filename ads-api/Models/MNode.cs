using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using NetTopologySuite.Geometries;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("Nodes")]
    public class MNode
    {
        [Key]
        [Column("node_id")]
        public Guid? Id { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("name")] 
        public string? Name { get; set; }

        [Column("layer")]
        public string? Layer { get; set; }

        [Column("tags")] 
        public string? Tags { get; set; }

        [Column("location")] 
        public Point? Location { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MNode()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
