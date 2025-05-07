using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Cases_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    case_id = table.Column<Guid>(type: "uuid", nullable: false),
                    case_no = table.Column<string>(type: "text", nullable: true),
                    case_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    case_status = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    incident_type = table.Column<string>(type: "text", nullable: true),
                    case_owner = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.case_id);
                });

            migrationBuilder.CreateIndex(
                name: "Case_No_Idx1",
                table: "Cases",
                column: "case_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Case_OrgId_Idx1",
                table: "Cases",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "Case_Owner_Idx1",
                table: "Cases",
                column: "case_owner");

            migrationBuilder.CreateIndex(
                name: "Case_Status_Idx1",
                table: "Cases",
                column: "case_status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
