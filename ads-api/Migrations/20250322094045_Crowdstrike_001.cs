using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Crowdstrike_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cs_computer_name",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cs_detect_name",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cs_event_name",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cs_file_name",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cs_incident_type",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cs_ioc_type",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cs_local_ip",
                table: "LogAggregates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cs_user_name",
                table: "LogAggregates",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cs_computer_name",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "cs_detect_name",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "cs_event_name",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "cs_file_name",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "cs_incident_type",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "cs_ioc_type",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "cs_local_ip",
                table: "LogAggregates");

            migrationBuilder.DropColumn(
                name: "cs_user_name",
                table: "LogAggregates");
        }
    }
}
