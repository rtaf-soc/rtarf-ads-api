using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("Blacklists")]
    public class MBlacklist
    {
        [Key]
        [Column("blacklist_id")]
        public Guid? BlacklistId { get; set; }
        
        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("blacklist_code")] /* SourceIP, DestIP, Domain, Hash, File Name */
        public string? BlacklistCode { get; set; }

        [Column("tags")] /* Comma separate --> MISP,Blacklist */
        public string? Tags { get; set; }

        [Column("blacklist_type")] /* 1=SrcIP, 2=DestIP, 3=Domain, 4=Hash, 5=FileName */
        public int? BlacklistType { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MBlacklist()
        {
            BlacklistId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
