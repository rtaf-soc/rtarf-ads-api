using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Case_Add_Fields_002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "case_pap",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "case_ref_id",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "case_severity",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "case_summary",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "case_title",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "case_tlp",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "impact_status",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "solution_status",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "start_date",
                table: "Cases",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tags",
                table: "Cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "Cases",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "update_by",
                table: "Cases",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "case_pap",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "case_ref_id",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "case_severity",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "case_summary",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "case_title",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "case_tlp",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "impact_status",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "solution_status",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "start_date",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "tags",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "update_by",
                table: "Cases");
        }
    }
}
