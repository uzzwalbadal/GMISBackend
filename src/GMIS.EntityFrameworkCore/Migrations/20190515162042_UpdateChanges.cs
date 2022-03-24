using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class UpdateChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NCA",
                table: "DOI_Engineering_TertiaryCanal");

            migrationBuilder.DropColumn(
                name: "SubBranchLength",
                table: "DOI_Engineering_TertiaryCanal");

            migrationBuilder.DropColumn(
                name: "NCA",
                table: "DOI_Engineering_SecondaryCanal");

            migrationBuilder.DropColumn(
                name: "SubBranchLength",
                table: "DOI_Engineering_SecondaryCanal");

            migrationBuilder.DropColumn(
                name: "NCA",
                table: "DOI_Engineering_BranchCanal");

            migrationBuilder.DropColumn(
                name: "SubBranchLength",
                table: "DOI_Engineering_BranchCanal");

            migrationBuilder.DropColumn(
                name: "TotalCultivatedArea",
                table: "DOI_AgricultureInfo");

            migrationBuilder.RenameColumn(
                name: "RiverBasinDistance",
                table: "DOI_LocationInfo",
                newName: "RoadDistance");

            migrationBuilder.RenameColumn(
                name: "TopLength",
                table: "DOI_Engineering_TertiaryCanal",
                newName: "TotalLength");

            migrationBuilder.RenameColumn(
                name: "TertiaryLength",
                table: "DOI_Engineering_TertiaryCanal",
                newName: "CCA");

            migrationBuilder.RenameColumn(
                name: "TopLength",
                table: "DOI_Engineering_SecondaryCanal",
                newName: "TotalLength");

            migrationBuilder.RenameColumn(
                name: "TertiaryLength",
                table: "DOI_Engineering_SecondaryCanal",
                newName: "CCA");

            migrationBuilder.RenameColumn(
                name: "TotalDepth",
                table: "DOI_Engineering_MainCanal",
                newName: "IdleLength");

            migrationBuilder.RenameColumn(
                name: "TopLength",
                table: "DOI_Engineering_BranchCanal",
                newName: "TotalLength");

            migrationBuilder.RenameColumn(
                name: "TertiaryLength",
                table: "DOI_Engineering_BranchCanal",
                newName: "CCA");

            migrationBuilder.RenameColumn(
                name: "BranchName",
                table: "DOI_Engineering_BranchCanal",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "CanalStructure",
                table: "DOI_Engineering_TertiaryCanal",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "CanalStructure",
                table: "DOI_Engineering_SecondaryCanal",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "NoOfTertiaryCanal",
                table: "DOI_Engineering_SecondaryCanal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PMF",
                table: "DOI_Engineering_RiverHydrology",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "HeadWorksTypeOther",
                table: "DOI_Engineering_HeadWorks",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CanalStructure",
                table: "DOI_Engineering_BranchCanal",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "NoOfSecondaryCanal",
                table: "DOI_Engineering_BranchCanal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DOI_AgricultureDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    ExistingTotalCultivatedArea = table.Column<decimal>(nullable: false),
                    ExistingCropIntensity = table.Column<decimal>(nullable: false),
                    ProposedTotalCultivatedArea = table.Column<decimal>(nullable: false),
                    ProposedCropIntensity = table.Column<decimal>(nullable: false),
                    NearestAgricultureOffice = table.Column<string>(nullable: true),
                    AgricultureOfficeDistance = table.Column<decimal>(nullable: false),
                    NearestAgroVetOffice = table.Column<string>(nullable: true),
                    AgroVetOfficeDistance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_AgricultureDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_AgricultureDetail_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Graph_Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    DataValues = table.Column<decimal>(nullable: false),
                    IType = table.Column<byte>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Graph_Data", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOI_AgricultureDetail_ProjectId",
                table: "DOI_AgricultureDetail",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOI_AgricultureDetail");

            migrationBuilder.DropTable(
                name: "DOI_Graph_Data");

            migrationBuilder.DropColumn(
                name: "NoOfTertiaryCanal",
                table: "DOI_Engineering_SecondaryCanal");

            migrationBuilder.DropColumn(
                name: "PMF",
                table: "DOI_Engineering_RiverHydrology");

            migrationBuilder.DropColumn(
                name: "HeadWorksTypeOther",
                table: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropColumn(
                name: "NoOfSecondaryCanal",
                table: "DOI_Engineering_BranchCanal");

            migrationBuilder.RenameColumn(
                name: "RoadDistance",
                table: "DOI_LocationInfo",
                newName: "RiverBasinDistance");

            migrationBuilder.RenameColumn(
                name: "TotalLength",
                table: "DOI_Engineering_TertiaryCanal",
                newName: "TopLength");

            migrationBuilder.RenameColumn(
                name: "CCA",
                table: "DOI_Engineering_TertiaryCanal",
                newName: "TertiaryLength");

            migrationBuilder.RenameColumn(
                name: "TotalLength",
                table: "DOI_Engineering_SecondaryCanal",
                newName: "TopLength");

            migrationBuilder.RenameColumn(
                name: "CCA",
                table: "DOI_Engineering_SecondaryCanal",
                newName: "TertiaryLength");

            migrationBuilder.RenameColumn(
                name: "IdleLength",
                table: "DOI_Engineering_MainCanal",
                newName: "TotalDepth");

            migrationBuilder.RenameColumn(
                name: "TotalLength",
                table: "DOI_Engineering_BranchCanal",
                newName: "TopLength");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DOI_Engineering_BranchCanal",
                newName: "BranchName");

            migrationBuilder.RenameColumn(
                name: "CCA",
                table: "DOI_Engineering_BranchCanal",
                newName: "TertiaryLength");

            migrationBuilder.AlterColumn<decimal>(
                name: "CanalStructure",
                table: "DOI_Engineering_TertiaryCanal",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NCA",
                table: "DOI_Engineering_TertiaryCanal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubBranchLength",
                table: "DOI_Engineering_TertiaryCanal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "CanalStructure",
                table: "DOI_Engineering_SecondaryCanal",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NCA",
                table: "DOI_Engineering_SecondaryCanal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubBranchLength",
                table: "DOI_Engineering_SecondaryCanal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "CanalStructure",
                table: "DOI_Engineering_BranchCanal",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NCA",
                table: "DOI_Engineering_BranchCanal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubBranchLength",
                table: "DOI_Engineering_BranchCanal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCultivatedArea",
                table: "DOI_AgricultureInfo",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
