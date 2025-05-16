using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class CsMachineStat_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CsMachineStat",
                columns: table => new
                {
                    machine_stat_id = table.Column<Guid>(type: "uuid", nullable: false),
                    machine_name = table.Column<string>(type: "text", nullable: true),
                    last_cs_event_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    cs_event_count = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsMachineStat", x => x.machine_stat_id);
                });

            migrationBuilder.CreateIndex(
                name: "MachineStat_Name_Idx1",
                table: "CsMachineStat",
                column: "machine_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MachineStat_OrgId_Idx1",
                table: "CsMachineStat",
                column: "org_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CsMachineStat");
        }
    }
}
