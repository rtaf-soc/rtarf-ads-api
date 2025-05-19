using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("Devices")]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(OrgId))]
    [Index(nameof(Brand))]
    [Index(nameof(Model))]
    public class MDevice
    {
        [Key]
        [Column("device_id")]
        public Guid? Id { get; set; }

        [Column("device_name")]
        public string? Name { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("device_address")]
        public string? IpAddress { get; set; }

        [Column("brand")]
        public string? Brand { get; set; }

        [Column("model")]
        public string? Model { get; set; }

        [Column("tags")]
        public string? Tags { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MDevice()
        {
            Id = Guid.NewGuid();
        }
    }
}
