using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("IpMaps")]
    public class MIpMap
    {
        [Key]
        [Column("ip_map_id")]
        public Guid? IpMapId { get; set; }
        
        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("cidr")] 
        public string? Cidr { get; set; }

        [Column("zone")]
        public string? Zone { get; set; }

        [Column("description")] 
        public string? Description { get; set; }

        [Column("tags")] 
        public string? Tags { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MIpMap()
        {
            IpMapId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
