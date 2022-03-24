using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class contractEntityModifed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PhysicalProgress",
                table: "DOI_ContractMgmt",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FinancialProgress",
                table: "DOI_ContractMgmt",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContracterAddress",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContracterName",
                table: "DOI_ContractMgmt",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContracterAddress",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ContracterName",
                table: "DOI_ContractMgmt");

            migrationBuilder.AlterColumn<string>(
                name: "PhysicalProgress",
                table: "DOI_ContractMgmt",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "FinancialProgress",
                table: "DOI_ContractMgmt",
                nullable: true,
                oldClrType: typeof(decimal));
        }
    }
}
