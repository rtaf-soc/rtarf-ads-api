using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Threat_Feed_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsFeed",
                columns: table => new
                {
                    feed_id = table.Column<Guid>(type: "uuid", nullable: false),
                    feed_no = table.Column<string>(type: "text", nullable: true),
                    feed_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    feed_type = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    feed_source = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFeed", x => x.feed_id);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                columns: table => new
                {
                    threat_id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_no = table.Column<string>(type: "text", nullable: true),
                    event_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    incident_type = table.Column<string>(type: "text", nullable: true),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    target_address = table.Column<string>(type: "text", nullable: true),
                    action = table.Column<string>(type: "text", nullable: true),
                    owner = table.Column<string>(type: "text", nullable: true),
                    detected_by = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threats", x => x.threat_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_feed_no",
                table: "NewsFeed",
                column: "feed_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_org_id",
                table: "NewsFeed",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_event_no",
                table: "Threats",
                column: "event_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Threats_org_id",
                table: "Threats",
                column: "org_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsFeed");

            migrationBuilder.DropTable(
                name: "Threats");
        }
    }
}
