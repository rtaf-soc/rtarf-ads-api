using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class LogAggregate_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogAggregates",
                columns: table => new
                {
                    log_aggregate_id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    cache_key = table.Column<string>(type: "text", nullable: true),
                    data_set = table.Column<string>(type: "text", nullable: true),
                    aggregator_name = table.Column<string>(type: "text", nullable: true),
                    loader_name = table.Column<string>(type: "text", nullable: true),
                    source_ip = table.Column<string>(type: "text", nullable: true),
                    source_network = table.Column<string>(type: "text", nullable: true),
                    destination_ip = table.Column<string>(type: "text", nullable: true),
                    destination_network = table.Column<string>(type: "text", nullable: true),
                    protocol = table.Column<string>(type: "text", nullable: true),
                    transport = table.Column<string>(type: "text", nullable: true),
                    evnet_count = table.Column<long>(type: "bigint", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAggregates", x => x.log_aggregate_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogAggregates");
        }
    }
}
