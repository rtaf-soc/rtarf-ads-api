using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class CustomFields_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "custom_field1",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field10",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field11",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field12",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field13",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field14",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field15",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field2",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field3",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field4",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field5",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field6",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field7",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field8",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "custom_field9",
                table: "LogAggregates",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "custom_field1",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field10",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field11",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field12",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field13",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field14",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field15",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field2",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field3",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field4",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field5",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field6",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field7",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field8",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "custom_field9",
                table: "LogAggregates");
        }
    }
}
