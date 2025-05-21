using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("Departments")]
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(OrgId))]

    public class MDepartment
    {
        [Key]
        [Column("department_id")]
        public Guid? Id { get; set; }

        [Column("department_code")]
        public string? Code { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("short_name")]
        public string? ShortName { get; set; }

        [Column("long_name")]
        public string? LongName { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MDepartment()
        {
            Id = Guid.NewGuid();
        }
    }
}
