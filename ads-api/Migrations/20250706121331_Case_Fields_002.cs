using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Case_Fields_002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_date",
                table: "Cases");

            migrationBuilder.AddColumn<DateTime>(
                name: "case_end_date",
                table: "Cases",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "case_end_date",
                table: "Cases");

            migrationBuilder.AddColumn<string>(
                name: "end_date",
                table: "Cases",
                type: "text",
                nullable: true);
        }
    }
}
