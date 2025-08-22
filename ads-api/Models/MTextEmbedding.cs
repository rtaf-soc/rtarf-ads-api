using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using System.Diagnostics.CodeAnalysis;
using Pgvector;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    [Table("TextEmbedding")]
    [Index(nameof(OrgId))]

    public class MTextEmbedding
    {
        [Key]
        [Column("embedding_id")]
        public Guid? Id { get; set; }

        [Column("org_id")]
        public string? OrgId { get; set; }

        [Column("embedding_bge_m3")]
        public Vector? EmbeddingBgeM3 { get; set; }

        [Column("normalized_text")] //Could be JSON string
        public string? NormalizedText { get; set; }

        [Column("category")] //Example --> "Incident"
        public string? Category { get; set; }

        [Column("ref_no")] //Case No
        public string? RefNo { get; set; }

        [Column("chunk_no")]
        public int? ChunkNo { get; set; }

        [Column("tags")]
        public string? Tags { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        public MTextEmbedding()
        {
            Id = Guid.NewGuid();
        }
    }
}
