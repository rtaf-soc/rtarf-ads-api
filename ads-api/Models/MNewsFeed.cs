using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("NewsFeed")]
    [Index(nameof(FeedNo), IsUnique = true)]
    [Index(nameof(OrgId))]

    public class MNewsFeed
    {
        [Key]
        [Column("feed_id")]
        public Guid? Id { get; set; }

        [Column("feed_no")]
        public string? FeedNo { get; set; }

        [Column("feed_date")]
        public DateTime? FeedDate { get; set; }

       [Column("feed_date_str")]
        public string? FeedDateStr { get; set; }

        [Column("feed_type")]
        public string? FeedType { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("comment")]
        public string? Comment { get; set; }

        [Column("feed_source")]
        public string? FeedSource { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MNewsFeed()
        {
            Id = Guid.NewGuid();
        }
    }
}
