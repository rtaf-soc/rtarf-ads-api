using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class IocHost_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MIocHosts",
                columns: table => new
                {
                    ioc_host_id = table.Column<Guid>(type: "uuid", nullable: false),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    ioc_host_code = table.Column<string>(type: "text", nullable: true),
                    ioc_type = table.Column<string>(type: "text", nullable: true),
                    ioc_endpoint = table.Column<string>(type: "text", nullable: true),
                    authentication_key = table.Column<string>(type: "text", nullable: true),
                    is_tls_required = table.Column<bool>(type: "boolean", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MIocHosts", x => x.ioc_host_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MIocHosts");
        }
    }
}
