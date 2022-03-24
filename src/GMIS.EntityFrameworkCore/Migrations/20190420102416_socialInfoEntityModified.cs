using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class socialInfoEntityModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FarmSizeLargePercent",
                table: "DOI_EthicsInfos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FarmSizeMediumPercent",
                table: "DOI_EthicsInfos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FarmSizeSmallPercent",
                table: "DOI_EthicsInfos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FarmSizeVeryLargePercent",
                table: "DOI_EthicsInfos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Landless",
                table: "DOI_EthicsInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "LandlessPercent",
                table: "DOI_EthicsInfos",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmSizeLargePercent",
                table: "DOI_EthicsInfos");

            migrationBuilder.DropColumn(
                name: "FarmSizeMediumPercent",
                table: "DOI_EthicsInfos");

            migrationBuilder.DropColumn(
                name: "FarmSizeSmallPercent",
                table: "DOI_EthicsInfos");

            migrationBuilder.DropColumn(
                name: "FarmSizeVeryLargePercent",
                table: "DOI_EthicsInfos");

            migrationBuilder.DropColumn(
                name: "Landless",
                table: "DOI_EthicsInfos");

            migrationBuilder.DropColumn(
                name: "LandlessPercent",
                table: "DOI_EthicsInfos");
        }
    }
}
