using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class LogAggregateFirewall_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogAggregatesFirewall",
                columns: table => new
                {
                    log_aggregate_id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    cache_key = table.Column<string>(type: "text", nullable: true),
                    data_set = table.Column<string>(type: "text", nullable: true),
                    aggregator_name = table.Column<string>(type: "text", nullable: true),
                    aggregator_type = table.Column<string>(type: "text", nullable: true),
                    loader_name = table.Column<string>(type: "text", nullable: true),
                    source_ip = table.Column<string>(type: "text", nullable: true),
                    source_network = table.Column<string>(type: "text", nullable: true),
                    destination_ip = table.Column<string>(type: "text", nullable: true),
                    destination_network = table.Column<string>(type: "text", nullable: true),
                    protocol = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    yyyymmdd = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAggregatesFirewall", x => x.log_aggregate_id);
                });

            migrationBuilder.CreateIndex(
                name: "AggregatorName_Idx11",
                table: "LogAggregatesFirewall",
                column: "aggregator_name");

            migrationBuilder.CreateIndex(
                name: "AggregatorType_Idx11",
                table: "LogAggregatesFirewall",
                column: "aggregator_type");

            migrationBuilder.CreateIndex(
                name: "CacheKey_Unique11",
                table: "LogAggregatesFirewall",
                column: "cache_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "DataSet_Idx11",
                table: "LogAggregatesFirewall",
                column: "data_set");

            migrationBuilder.CreateIndex(
                name: "DestinationIp_Idx11",
                table: "LogAggregatesFirewall",
                column: "destination_ip");

            migrationBuilder.CreateIndex(
                name: "DestinationNetwork_Idx11",
                table: "LogAggregatesFirewall",
                column: "destination_network");

            migrationBuilder.CreateIndex(
                name: "EventDate_Idx11",
                table: "LogAggregatesFirewall",
                column: "event_date");

            migrationBuilder.CreateIndex(
                name: "EventDateStr_Idx11",
                table: "LogAggregatesFirewall",
                column: "yyyymmdd");

            migrationBuilder.CreateIndex(
                name: "SourceIp_Idx11",
                table: "LogAggregatesFirewall",
                column: "source_ip");

            migrationBuilder.CreateIndex(
                name: "SourceNetwork_Idx11",
                table: "LogAggregatesFirewall",
                column: "source_network");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogAggregatesFirewall");
        }
    }
}
