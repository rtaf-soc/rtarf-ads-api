using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("LogAggregatesFirewall")]
    [Index(nameof(CacheKey), IsUnique = true, Name = "CacheKey_Unique1")]
    [Index(nameof(EventDateStr), IsUnique = false, Name = "EventDateStr_Idx1")]
    [Index(nameof(EventDate), IsUnique = false, Name = "EventDate_Idx1")]
    [Index(nameof(DataSet), IsUnique = false, Name = "DataSet_Idx1")]
    [Index(nameof(AggregatorName), IsUnique = false, Name = "AggregatorName_Idx1")]
    [Index(nameof(AggregatorType), IsUnique = false, Name = "AggregatorType_Idx1")]
    [Index(nameof(SourceIp), IsUnique = false, Name = "SourceIp_Idx1")]
    [Index(nameof(SourceNetwork), IsUnique = false, Name = "SourceNetwork_Idx1")]
    [Index(nameof(DestinationIp), IsUnique = false, Name = "DestinationIp_Idx1")]
    [Index(nameof(DestinationNetwork), IsUnique = false, Name = "DestinationNetwork_Idx1")]

    public class MLogAggregateFirewall
    {
        [Key]
        [Column("log_aggregate_id")]
        public Guid? LogAggregateId { get; set; }
    
        [Column("event_date")]
        public DateTime? EventDate { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("cache_key")]
        public string? CacheKey { get; set; }

        [Column("data_set")]
        public string? DataSet { get; set; }

        [Column("aggregator_name")]
        public string? AggregatorName { get; set; }
        
        [Column("aggregator_type")]
        public string? AggregatorType { get; set; }
        
        [Column("loader_name")]
        public string? LoaderName { get; set; }

        [Column("source_ip")]
        public string? SourceIp { get; set; }

        [Column("source_network")]
        public string? SourceNetwork { get; set; }

        [Column("destination_ip")]
        public string? DestinationIp { get; set; }

        [Column("destination_network")]
        public string? DestinationNetwork { get; set; }

        [Column("protocol")]
        public string? Protocol { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("yyyymmdd")]
        public string? EventDateStr { get; set; }

        public MLogAggregateFirewall()
        {
            LogAggregateId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
