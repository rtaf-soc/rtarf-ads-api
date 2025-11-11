using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Node_005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Nodes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "NodeLinks",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "description",
                table: "NodeLinks");
        }
    }
}
