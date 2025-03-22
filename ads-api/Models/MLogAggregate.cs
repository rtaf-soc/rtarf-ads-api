using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("LogAggregates")]
    [Index(nameof(CacheKey), IsUnique = true, Name = "CacheKey_Unique1")]
    [Index(nameof(EventDateStr), IsUnique = false, Name = "EventDateStr_Idx1")]

    public class MLogAggregate
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

        [Column("transport")]
        public string? Transport { get; set; }

        [Column("mitr_attack_pattern")]
        public string? MittrAttackPattern { get; set; }

        [Column("mitr_ioc_key")]
        public string? MittrIocKey { get; set; } //Dest IP, Src IP, File Hash

        [Column("misp_threat_level")]
        public string? MispThreatLevel { get; set; }

        [Column("evnet_count")]
        public long? EventCount { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("yyyymmdd")]
        public string? EventDateStr { get; set; }


        [Column("cs_event_name")]
        public string? CsEventName { get; set; }

        [Column("cs_incident_type")]
        public string? CsIncidentType { get; set; }

        [Column("cs_computer_name")]
        public string? CsComputerName { get; set; }

        [Column("cs_user_name")]
        public string? CsUserName { get; set; }

        [Column("cs_detect_name")]
        public string? CsDetectName { get; set; }

        [Column("cs_file_name")]
        public string? CsFileName { get; set; }

        [Column("cs_ioc_type")]
        public string? CsIOCType { get; set; }

        [Column("cs_local_ip")]
        public string? CsLocalIP { get; set; }

        public MLogAggregate()
        {
            LogAggregateId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
