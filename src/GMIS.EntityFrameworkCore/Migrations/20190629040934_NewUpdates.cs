using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class NewUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarrageIsGated",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "DueDateOfCompletion",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "InitailContractAmount",
                table: "DOI_ContractMgmt");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "DOI_GroundWaterInfo",
                newName: "LongitudeSecond");

            migrationBuilder.RenameColumn(
                name: "Laltitude",
                table: "DOI_GroundWaterInfo",
                newName: "LongitudeMin");

            migrationBuilder.RenameColumn(
                name: "LongitudinalSlope",
                table: "DOI_Engineering_MainCanal",
                newName: "LinedLongitudinalSlope");

            migrationBuilder.RenameColumn(
                name: "WeirHeadOverTheCrest",
                table: "DOI_Engineering_HeadWorks",
                newName: "WeirWidthOfEachBayOpening");

            migrationBuilder.RenameColumn(
                name: "WeirCoefficientOfDischarge",
                table: "DOI_Engineering_HeadWorks",
                newName: "WeirWidthHeadRegulators");

            migrationBuilder.RenameColumn(
                name: "HeadOverTheCrest",
                table: "DOI_Engineering_HeadWorks",
                newName: "WeirUndersluiceLengthOfEachBayOpening");

            migrationBuilder.RenameColumn(
                name: "CoefficientOfDischarge",
                table: "DOI_Engineering_HeadWorks",
                newName: "WeirUndersluiceCrestElevation");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "DOI_ContractMgmt",
                newName: "TimeVariationInitialDueDate");

            migrationBuilder.AddColumn<string>(
                name: "LatitudeDegree",
                table: "DOI_GroundWaterInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LatitudeMin",
                table: "DOI_GroundWaterInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LatitudeSecond",
                table: "DOI_GroundWaterInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongitudeDegree",
                table: "DOI_GroundWaterInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasinType",
                table: "DOI_Engineering_RiverHydrology",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarthenLongitudinalSlope",
                table: "DOI_Engineering_MainCanal",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BarrageCrestElevation",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BarrageNoOfHeadRegulators",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BarrageNoOfHeadRegulatorsBays",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BarrageWidthHeadRegulators",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BarrageWidthOfEachBayOpening",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfUndersluice",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfUndersluiceBaysOrGates",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UndersluiceCrestElevation",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UndersluiceLengthOfEachBayOpening",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WeirHeadRegulatorsCrestElevation",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeirNoOfHeadRegulators",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeirNoOfHeadRegulatorsBays",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeirNoOfUndersluice",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeirNoOfUndersluiceBaysOrGates",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractMethod",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractVariationApprovedBy",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractVariationApprovedDate",
                table: "DOI_ContractMgmt",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalContractAmnt",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTimeVariation",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NoOfTimeExtension",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonsForContractVariation",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonsForTimeExtension",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeVariationApprovedBy",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeVariationApprovedDate",
                table: "DOI_ContractMgmt",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeVariationExtendedDueDate",
                table: "DOI_ContractMgmt",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VariationAmnt",
                table: "DOI_ContractMgmt",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageCropPrice",
                table: "DOI_AgricultureInfo",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatitudeDegree",
                table: "DOI_GroundWaterInfo");

            migrationBuilder.DropColumn(
                name: "LatitudeMin",
                table: "DOI_GroundWaterInfo");

            migrationBuilder.DropColumn(
                name: "LatitudeSecond",
                table: "DOI_GroundWaterInfo");

            migrationBuilder.DropColumn(
                name: "LongitudeDegree",
                table: "DOI_GroundWaterInfo");

            migrationBuilder.DropColumn(
                name: "BasinType",
                table: "DOI_Engineering_RiverHydrology");

            migrationBuilder.DropColumn(
                name: "EarthenLongitudinalSlope",
                table: "DOI_Engineering_MainCanal");

            migrationBuilder.DropColumn(
                name: "BarrageCrestElevation",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "BarrageNoOfHeadRegulators",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "BarrageNoOfHeadRegulatorsBays",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "BarrageWidthHeadRegulators",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "BarrageWidthOfEachBayOpening",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "NoOfUndersluice",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "NoOfUndersluiceBaysOrGates",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "UndersluiceCrestElevation",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "UndersluiceLengthOfEachBayOpening",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "WeirHeadRegulatorsCrestElevation",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "WeirNoOfHeadRegulators",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "WeirNoOfHeadRegulatorsBays",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "WeirNoOfUndersluice",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "WeirNoOfUndersluiceBaysOrGates",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "ContractMethod",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ContractVariationApprovedBy",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ContractVariationApprovedDate",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "FinalContractAmnt",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "IsTimeVariation",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "NoOfTimeExtension",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ReasonsForContractVariation",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "ReasonsForTimeExtension",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "TimeVariationApprovedBy",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "TimeVariationApprovedDate",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "TimeVariationExtendedDueDate",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "VariationAmnt",
                table: "DOI_ContractMgmt");

            migrationBuilder.DropColumn(
                name: "AverageCropPrice",
                table: "DOI_AgricultureInfo");

            migrationBuilder.RenameColumn(
                name: "LongitudeSecond",
                table: "DOI_GroundWaterInfo",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "LongitudeMin",
                table: "DOI_GroundWaterInfo",
                newName: "Laltitude");

            migrationBuilder.RenameColumn(
                name: "LinedLongitudinalSlope",
                table: "DOI_Engineering_MainCanal",
                newName: "LongitudinalSlope");

            migrationBuilder.RenameColumn(
                name: "WeirWidthOfEachBayOpening",
                table: "DOI_Engineering_HeadWorks",
                newName: "WeirHeadOverTheCrest");

            migrationBuilder.RenameColumn(
                name: "WeirWidthHeadRegulators",
                table: "DOI_Engineering_HeadWorks",
                newName: "WeirCoefficientOfDischarge");

            migrationBuilder.RenameColumn(
                name: "WeirUndersluiceLengthOfEachBayOpening",
                table: "DOI_Engineering_HeadWorks",
                newName: "HeadOverTheCrest");

            migrationBuilder.RenameColumn(
                name: "WeirUndersluiceCrestElevation",
                table: "DOI_Engineering_HeadWorks",
                newName: "CoefficientOfDischarge");

            migrationBuilder.RenameColumn(
                name: "TimeVariationInitialDueDate",
                table: "DOI_ContractMgmt",
                newName: "DueDate");

            migrationBuilder.AddColumn<bool>(
                name: "BarrageIsGated",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDateOfCompletion",
                table: "DOI_ContractMgmt",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "InitailContractAmount",
                table: "DOI_ContractMgmt",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
