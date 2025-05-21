using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Department_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    department_code = table.Column<string>(type: "text", nullable: true),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    long_name = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.department_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_department_code",
                table: "Departments",
                column: "department_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_org_id",
                table: "Departments",
                column: "org_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
