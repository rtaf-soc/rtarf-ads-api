using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Monitoring_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monitoring",
                columns: table => new
                {
                    monitoring_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    check_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    uptime_pct = table.Column<int>(type: "integer", nullable: true),
                    success_check_count = table.Column<int>(type: "integer", nullable: true),
                    total_check_count = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoring", x => x.monitoring_id);
                });

            migrationBuilder.CreateIndex(
                name: "Monitoring_Name_Idx1",
                table: "Monitoring",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "Monitoring_OrgId_Idx1",
                table: "Monitoring",
                column: "org_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitoring");
        }
    }
}
