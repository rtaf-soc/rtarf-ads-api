using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class HuntingRule_IsActive_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "is_active",
                table: "HuntingRules",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "HuntingRules");
        }
    }
}
