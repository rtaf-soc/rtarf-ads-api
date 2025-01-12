using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class IOC_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mitr_attack_pattern",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mitr_ioc_key",
                table: "LogAggregates",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mitr_attack_pattern",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "mitr_ioc_key",
                table: "LogAggregates");
        }
    }
}
