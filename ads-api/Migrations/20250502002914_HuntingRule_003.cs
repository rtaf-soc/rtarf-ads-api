using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class HuntingRule_003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HuntingRules_ref_type",
                table: "HuntingRules",
                column: "ref_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HuntingRules_ref_type",
                table: "HuntingRules");
        }
    }
}
