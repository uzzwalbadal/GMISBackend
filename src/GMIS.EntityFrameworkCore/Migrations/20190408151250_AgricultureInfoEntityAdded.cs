using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class AgricultureInfoEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOI_Agriculture_CropName",
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
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Agriculture_CropName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOI_AgricultureInfo",
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
                    CropId = table.Column<int>(nullable: false),
                    PlantingMonth = table.Column<string>(nullable: true),
                    PlantingWeek = table.Column<string>(nullable: true),
                    CropArea = table.Column<decimal>(nullable: false),
                    HarvestingMonth = table.Column<string>(nullable: true),
                    HarvestingWeek = table.Column<string>(nullable: true),
                    AverageCropYield = table.Column<decimal>(nullable: false),
                    SeedInput = table.Column<decimal>(nullable: false),
                    OrganicManureInput = table.Column<decimal>(nullable: false),
                    DAPInput = table.Column<decimal>(nullable: false),
                    PotashInput = table.Column<decimal>(nullable: false),
                    UreaInput = table.Column<decimal>(nullable: false),
                    HumanLaborInput = table.Column<decimal>(nullable: false),
                    AnimalLaborInput = table.Column<decimal>(nullable: false),
                    MachineLaborInput = table.Column<decimal>(nullable: false),
                    SeedPrice = table.Column<decimal>(nullable: false),
                    OrganicManurePrice = table.Column<decimal>(nullable: false),
                    DAPPrice = table.Column<decimal>(nullable: false),
                    PotashPrice = table.Column<decimal>(nullable: false),
                    UreaPrice = table.Column<decimal>(nullable: false),
                    HumanLaborPrice = table.Column<decimal>(nullable: false),
                    AnimalLaborPrice = table.Column<decimal>(nullable: false),
                    MachineLaborPrice = table.Column<decimal>(nullable: false),
                    IsCropPatternExisting = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_AgricultureInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_AgricultureInfo_DOI_Agriculture_CropName_CropId",
                        column: x => x.CropId,
                        principalTable: "DOI_Agriculture_CropName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_AgricultureInfo_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOI_AgricultureInfo_CropId",
                table: "DOI_AgricultureInfo",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_AgricultureInfo_ProjectId",
                table: "DOI_AgricultureInfo",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOI_AgricultureInfo");

            migrationBuilder.DropTable(
                name: "DOI_Agriculture_CropName");
        }
    }
}
