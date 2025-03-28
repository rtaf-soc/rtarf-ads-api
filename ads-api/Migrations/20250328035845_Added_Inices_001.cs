using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ads_api.Migrations
{
    /// <inheritdoc />
    public partial class Added_Inices_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "AggregatorName_Idx1",
                table: "LogAggregates",
                column: "aggregator_name");

            migrationBuilder.CreateIndex(
                name: "AggregatorType_Idx1",
                table: "LogAggregates",
                column: "aggregator_type");

            migrationBuilder.CreateIndex(
                name: "CustomField1_Idx1",
                table: "LogAggregates",
                column: "custom_field1");

            migrationBuilder.CreateIndex(
                name: "CustomField10_Idx1",
                table: "LogAggregates",
                column: "custom_field10");

            migrationBuilder.CreateIndex(
                name: "CustomField2_Idx1",
                table: "LogAggregates",
                column: "custom_field2");

            migrationBuilder.CreateIndex(
                name: "CustomField3_Idx1",
                table: "LogAggregates",
                column: "custom_field3");

            migrationBuilder.CreateIndex(
                name: "CustomField4_Idx1",
                table: "LogAggregates",
                column: "custom_field4");

            migrationBuilder.CreateIndex(
                name: "CustomField5_Idx1",
                table: "LogAggregates",
                column: "custom_field5");

            migrationBuilder.CreateIndex(
                name: "CustomField6_Idx1",
                table: "LogAggregates",
                column: "custom_field6");

            migrationBuilder.CreateIndex(
                name: "CustomField7_Idx1",
                table: "LogAggregates",
                column: "custom_field7");

            migrationBuilder.CreateIndex(
                name: "CustomField8_Idx1",
                table: "LogAggregates",
                column: "custom_field8");

            migrationBuilder.CreateIndex(
                name: "CustomField9_Idx1",
                table: "LogAggregates",
                column: "custom_field9");

            migrationBuilder.CreateIndex(
                name: "DataSet_Idx1",
                table: "LogAggregates",
                column: "data_set");

            migrationBuilder.CreateIndex(
                name: "DestinationIp_Idx1",
                table: "LogAggregates",
                column: "destination_ip");

            migrationBuilder.CreateIndex(
                name: "DestinationNetwork_Idx1",
                table: "LogAggregates",
                column: "destination_network");

            migrationBuilder.CreateIndex(
                name: "EventDate_Idx1",
                table: "LogAggregates",
                column: "event_date");

            migrationBuilder.CreateIndex(
                name: "SourceIp_Idx1",
                table: "LogAggregates",
                column: "source_ip");

            migrationBuilder.CreateIndex(
                name: "SourceNetwork_Idx1",
                table: "LogAggregates",
                column: "source_network");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "AggregatorName_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "AggregatorType_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "CustomField1_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "CustomField10_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "CustomField2_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "CustomField3_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "CustomField4_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "CustomField5_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "CustomField6_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "CustomField7_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "CustomField8_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "CustomField9_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "DataSet_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "DestinationIp_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "DestinationNetwork_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "EventDate_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "SourceIp_Idx1",
                table: "LogAggregates");

            migrationBuilder.DropIndex(
                name: "SourceNetwork_Idx1",
                table: "LogAggregates");
        }
    }
}
