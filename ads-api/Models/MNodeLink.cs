using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using NetTopologySuite.Geometries;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("NodeLinks")]
    public class MNodeLink
    {
        [Key]
        [Column("link_id")]
        public Guid? Id { get; set; }
        
        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("name")] 
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("layer")]
        public string? Layer { get; set; }

        [Column("tags")] 
        public string? Tags { get; set; }

        [Column("source_node")]
        public Guid? SourceNode { get; set; }

        [Column("destination_node")]
        public Guid? DestinationNode { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [NotMapped]
        public string? DestinationNodeType { get; set; }
        [NotMapped]
        public string? DestinationNodeName { get; set; }

        public MNodeLink()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
