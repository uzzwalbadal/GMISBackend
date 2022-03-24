using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class FinalUpdateChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchCanalLength",
                table: "DOI_Engineering_MainCanal");

            migrationBuilder.RenameColumn(
                name: "WUARegistrationProgressDate",
                table: "DOI_WUAInfo",
                newName: "WUARenewdUpToDate");

            migrationBuilder.RenameColumn(
                name: "WUADetail",
                table: "DOI_WUAInfo",
                newName: "RegistrationPlace");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "DOI_Info_ProjectStatus",
                newName: "OrderNo");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "DOI_Info_ProgramType",
                newName: "OrderNo");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "DOI_Info_ProgramInfo",
                newName: "OrderNo");

            migrationBuilder.RenameColumn(
                name: "UnlinedTypeCanalLength",
                table: "DOI_Engineering_MainCanal",
                newName: "EarthenTypeCanalLength");

            migrationBuilder.RenameColumn(
                name: "SlideSlope",
                table: "DOI_Engineering_MainCanal",
                newName: "SlideSlope1");

            migrationBuilder.RenameColumn(
                name: "WUAShare",
                table: "DOI_EconomicInfo",
                newName: "ProjectLife");

            migrationBuilder.RenameColumn(
                name: "GONShare",
                table: "DOI_EconomicInfo",
                newName: "BenefitWithoutProject");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "DOI_Agriculture_CropName",
                newName: "OrderNo");

            migrationBuilder.AddColumn<int>(
                name: "NoOfFemaleParticipant",
                table: "DOI_WUATrainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "DOI_WUAInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DOI_WUAInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfWUAMembers",
                table: "DOI_WUAInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoOffemaleMembers",
                table: "DOI_WUAInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PresidentName",
                table: "DOI_WUAInfo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WUARegistrationDate",
                table: "DOI_WUAInfo",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DonarCountriesName",
                table: "DOI_ProjectInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonarCountriesOthersName",
                table: "DOI_ProjectInfo",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CommandArea",
                table: "DOI_GroundWaterInfo",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Numberofpolesheading_HT_LT",
                table: "DOI_GroundWaterInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PumpInfoColumnTypeOther",
                table: "DOI_GroundWaterInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransformerBrand",
                table: "DOI_GroundWaterInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TubeWellName",
                table: "DOI_GroundWaterInfo",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageAnnualIncomePerFamily",
                table: "DOI_EthicsInfos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageFamilySize",
                table: "DOI_EthicsInfos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DesignFloodDischarge",
                table: "DOI_Engineering_RiverHydrology",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "EarthenSlideSlope",
                table: "DOI_Engineering_MainCanal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinedSlideSlope",
                table: "DOI_Engineering_MainCanal",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BenefitWithProject",
                table: "DOI_EconomicInfo",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ContractType",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDateOfCompletion",
                table: "DOI_ContractMgmt",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "FinancialDonar",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinancialGON",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinancialOthers",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinancialWUA",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ICBEstimatedCost",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ICBNumber",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "InitailContractAmount",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NCBEstimatedCost",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NCBNumber",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ProjectCost",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WUAEstimatedCost",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "WUANumber",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfFemaleParticipant",
                table: "DOI_WUATrainings");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "DOI_WUAInfo");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DOI_WUAInfo");

            migrationBuilder.DropColumn(
                name: "NoOfWUAMembers",
                table: "DOI_WUAInfo");

            migrationBuilder.DropColumn(
                name: "NoOffemaleMembers",
                table: "DOI_WUAInfo");

            migrationBuilder.DropColumn(
                name: "PresidentName",
                table: "DOI_WUAInfo");

            migrationBuilder.DropColumn(
                name: "WUARegistrationDate",
                table: "DOI_WUAInfo");

            migrationBuilder.DropColumn(
                name: "DonarCountriesName",
                table: "DOI_ProjectInfo");

            migrationBuilder.DropColumn(
                name: "DonarCountriesOthersName",
                table: "DOI_ProjectInfo");

            migrationBuilder.DropColumn(
                name: "CommandArea",
                table: "DOI_GroundWaterInfo");

            migrationBuilder.DropColumn(
                name: "Numberofpolesheading_HT_LT",
                table: "DOI_GroundWaterInfo");

            migrationBuilder.DropColumn(
                name: "PumpInfoColumnTypeOther",
                table: "DOI_GroundWaterInfo");

            migrationBuilder.DropColumn(
                name: "TransformerBrand",
                table: "DOI_GroundWaterInfo");

            migrationBuilder.DropColumn(
                name: "TubeWellName",
                table: "DOI_GroundWaterInfo");

            migrationBuilder.DropColumn(
                name: "AverageAnnualIncomePerFamily",
                table: "DOI_EthicsInfos");

            migrationBuilder.DropColumn(
                name: "AverageFamilySize",
                table: "DOI_EthicsInfos");

            migrationBuilder.DropColumn(
                name: "DesignFloodDischarge",
                table: "DOI_Engineering_RiverHydrology");

            migrationBuilder.DropColumn(
                name: "EarthenSlideSlope",
                table: "DOI_Engineering_MainCanal");

            migrationBuilder.DropColumn(
                name: "LinedSlideSlope",
                table: "DOI_Engineering_MainCanal");

            migrationBuilder.DropColumn(
                name: "BenefitWithProject",
                table: "DOI_EconomicInfo");

            migrationBuilder.DropColumn(
                name: "ContractType",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "DueDateOfCompletion",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "FinancialDonar",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "FinancialGON",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "FinancialOthers",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "FinancialWUA",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ICBEstimatedCost",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ICBNumber",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "InitailContractAmount",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "NCBEstimatedCost",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "NCBNumber",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ProjectCost",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "WUAEstimatedCost",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "WUANumber",
                table: "DOI_ContractMgmt");

            migrationBuilder.RenameColumn(
                name: "WUARenewdUpToDate",
                table: "DOI_WUAInfo",
                newName: "WUARegistrationProgressDate");

            migrationBuilder.RenameColumn(
                name: "RegistrationPlace",
                table: "DOI_WUAInfo",
                newName: "WUADetail");

            migrationBuilder.RenameColumn(
                name: "OrderNo",
                table: "DOI_Info_ProjectStatus",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderNo",
                table: "DOI_Info_ProgramType",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderNo",
                table: "DOI_Info_ProgramInfo",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "SlideSlope1",
                table: "DOI_Engineering_MainCanal",
                newName: "SlideSlope");

            migrationBuilder.RenameColumn(
                name: "EarthenTypeCanalLength",
                table: "DOI_Engineering_MainCanal",
                newName: "UnlinedTypeCanalLength");

            migrationBuilder.RenameColumn(
                name: "ProjectLife",
                table: "DOI_EconomicInfo",
                newName: "WUAShare");

            migrationBuilder.RenameColumn(
                name: "BenefitWithoutProject",
                table: "DOI_EconomicInfo",
                newName: "GONShare");

            migrationBuilder.RenameColumn(
                name: "OrderNo",
                table: "DOI_Agriculture_CropName",
                newName: "Order");

            migrationBuilder.AddColumn<decimal>(
                name: "BranchCanalLength",
                table: "DOI_Engineering_MainCanal",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
