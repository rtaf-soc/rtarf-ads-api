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

        [Column("cidr")] /* SourceIP, DestIP, Domain, Hash, File Name */
        public string? Cidr { get; set; }

        [Column("zone")] /* Comma separate --> MISP,Blacklist */
        public string? Zone { get; set; }

        [Column("description")] /* 1=SrcIP, 2=DestIP, 3=Domain, 4=Hash, 5=FileName */
        public int? Description { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MIpMap()
        {
            IpMapId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
