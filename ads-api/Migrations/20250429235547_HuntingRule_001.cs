using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class HuntingRule_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HuntingRules",
                columns: table => new
                {
                    rule_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rule_name = table.Column<string>(type: "text", nullable: true),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    rule_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rule_description = table.Column<string>(type: "text", nullable: true),
                    rule_definition = table.Column<string>(type: "text", nullable: true),
                    ref_url = table.Column<string>(type: "text", nullable: true),
                    tags = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntingRules", x => x.rule_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HuntingRules_org_id",
                table: "HuntingRules",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_HuntingRules_rule_name",
                table: "HuntingRules",
                column: "rule_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HuntingRules");
        }
    }
}
