using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Monitoring_Index_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Monitoring_Name_Idx1",
                table: "Monitoring");

            migrationBuilder.CreateIndex(
                name: "Monitoring_Name_Idx2",
                table: "Monitoring",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Monitoring_Name_Idx2",
                table: "Monitoring");

            migrationBuilder.CreateIndex(
                name: "Monitoring_Name_Idx1",
                table: "Monitoring",
                column: "name");
        }
    }
}
