using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Feed_Threat_Add_Field_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "event_date_str",
                table: "Threats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "feed_date_str",
                table: "NewsFeed",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "event_date_str",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "feed_date_str",
                table: "NewsFeed");
        }
    }
}
