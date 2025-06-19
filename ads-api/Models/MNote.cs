using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("Notes")]
    [Index(nameof(OrgId))]

    public class MNote
    {
        [Key]
        [Column("note_id")]
        public Guid? Id { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("header")]
        public string? Header { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("owner")]
        public string? Owner { get; set; }

        [Column("tags")]
        public string? Tags { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MNote()
        {
            Id = Guid.NewGuid();
        }
    }
}
