using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Case_Fields_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_fields",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "end_date",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "flags",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "merge_from",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "merge_into",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "metrics",
                table: "Cases",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "custom_fields",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "end_date",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "flags",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "merge_from",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "merge_into",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "metrics",
                table: "Cases");
        }
    }
}
