using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Node_006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "Nodes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "Nodes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Nodes");
        }
    }
}
