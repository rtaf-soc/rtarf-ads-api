using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("MIocHosts")]
    public class MIocHost
    {
        [Key]
        [Column("ioc_host_id")]
        public Guid? IocHostId { get; set; }
        
        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("ioc_host_code")]
        public string? IocHostCode { get; set; }

        [Column("ioc_type")] /* MISP, OCTI */
        public string? IocType { get; set; }

        [Column("ioc_endpoint")]
        public string? IocEndpoint { get; set; }

        [Column("authentication_key")]
        public string? AuthenticationKey { get; set; }

        [Column("is_tls_required")]
        public bool? IsTlsRequired { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MIocHost()
        {
            IocHostId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
