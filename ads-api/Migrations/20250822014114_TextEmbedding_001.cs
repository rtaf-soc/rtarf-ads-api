using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Pgvector;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class TextEmbedding_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextEmbedding",
                columns: table => new
                {
                    embedding_id = table.Column<Guid>(type: "uuid", nullable: false),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    embedding_bge_m3 = table.Column<Vector>(type: "vector(1024)", nullable: true),
                    normalized_text = table.Column<string>(type: "text", nullable: true),
                    category = table.Column<string>(type: "text", nullable: true),
                    ref_no = table.Column<string>(type: "text", nullable: true),
                    chunk_no = table.Column<int>(type: "integer", nullable: true),
                    tags = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextEmbedding", x => x.embedding_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextEmbedding_org_id",
                table: "TextEmbedding",
                column: "org_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextEmbedding");
        }
    }
}
