using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class ContractEntityModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhysicalProgress",
                table: "DOI_ContractMgmt",
                newName: "PhysicalProgressPercent");

            migrationBuilder.RenameColumn(
                name: "FinancialProgress",
                table: "DOI_ContractMgmt",
                newName: "FinancialProgressPercent");

            migrationBuilder.RenameColumn(
                name: "ContracterName",
                table: "DOI_ContractMgmt",
                newName: "PhysicalProgressNote");

            migrationBuilder.RenameColumn(
                name: "ContracterAddress",
                table: "DOI_ContractMgmt",
                newName: "FinancialProgressNote");

            migrationBuilder.AddColumn<DateTime>(
                name: "AgreementDate",
                table: "DOI_ContractMgmt",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ContractId",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractName",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ContractStatus",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractorName",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "DOI_ContractMgmt",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinancialProgressAmount",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InitialContractAmnt",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVariation",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NoOfTimesExtension",
                table: "DOI_ContractMgmt",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreementDate",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ContractName",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ContractStatus",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ContractorName",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "FinancialProgressAmount",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "InitialContractAmnt",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "IsVariation",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "NoOfTimesExtension",
                table: "DOI_ContractMgmt");

            migrationBuilder.RenameColumn(
                name: "PhysicalProgressPercent",
                table: "DOI_ContractMgmt",
                newName: "PhysicalProgress");

            migrationBuilder.RenameColumn(
                name: "PhysicalProgressNote",
                table: "DOI_ContractMgmt",
                newName: "ContracterName");

            migrationBuilder.RenameColumn(
                name: "FinancialProgressPercent",
                table: "DOI_ContractMgmt",
                newName: "FinancialProgress");

            migrationBuilder.RenameColumn(
                name: "FinancialProgressNote",
                table: "DOI_ContractMgmt",
                newName: "ContracterAddress");
        }
    }
}
