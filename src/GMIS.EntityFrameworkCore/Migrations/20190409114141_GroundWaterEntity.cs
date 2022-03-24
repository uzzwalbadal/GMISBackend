using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class GroundWaterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOI_GroundWaterInfo",
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
                    TubewellNo = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Laltitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Elevation = table.Column<string>(nullable: true),
                    TubewellType = table.Column<string>(nullable: true),
                    TubewellHousingPipeSize = table.Column<decimal>(nullable: false),
                    TubewellScreenAndCastingPipeSize = table.Column<decimal>(nullable: false),
                    StaticWaterLevel = table.Column<decimal>(nullable: false),
                    AquiferMaterail = table.Column<string>(nullable: true),
                    TotalDrillDepth = table.Column<decimal>(nullable: false),
                    HousingLength = table.Column<decimal>(nullable: false),
                    ScreenLength = table.Column<decimal>(nullable: false),
                    TypeOfScreen = table.Column<string>(nullable: true),
                    PumpingDischarge = table.Column<decimal>(nullable: false),
                    Drawdown = table.Column<decimal>(nullable: false),
                    AquiferStorageCoefficient = table.Column<decimal>(nullable: false),
                    Aquifertransmissivity = table.Column<decimal>(nullable: false),
                    BrandOfPump = table.Column<string>(nullable: true),
                    Power = table.Column<decimal>(nullable: false),
                    Head = table.Column<decimal>(nullable: false),
                    PumpDischarge = table.Column<decimal>(nullable: false),
                    EfficienyOfMoter = table.Column<decimal>(nullable: false),
                    EfficienyOfPump = table.Column<decimal>(nullable: false),
                    PumpLoweringDepth = table.Column<decimal>(nullable: false),
                    ColumnPipeSize = table.Column<decimal>(nullable: false),
                    ColumnType = table.Column<string>(nullable: true),
                    SizeOfPumpHouse = table.Column<string>(nullable: true),
                    HeightOfOverheadTank = table.Column<decimal>(nullable: false),
                    VolumeOverheadTank = table.Column<decimal>(nullable: false),
                    TypeOfDistributionSystem = table.Column<string>(nullable: true),
                    NoOfOutlets = table.Column<decimal>(nullable: false),
                    LengthOfOpenChannel = table.Column<decimal>(nullable: true),
                    SizeOfAlphaValve = table.Column<decimal>(nullable: true),
                    PipeMaterial = table.Column<string>(nullable: true),
                    LengthOfPipe = table.Column<decimal>(nullable: true),
                    NoOfSurgeRaiser = table.Column<decimal>(nullable: true),
                    LengthOf11KvHtTransLine = table.Column<decimal>(nullable: false),
                    Lengthof440VLtTransLine = table.Column<decimal>(nullable: false),
                    NumberOfPoles = table.Column<decimal>(nullable: false),
                    TransformerCapacity = table.Column<decimal>(nullable: false),
                    ControlPanel = table.Column<decimal>(nullable: false),
                    VoltageStabilizer = table.Column<decimal>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_GroundWaterInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_GroundWaterInfo_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOI_GroundWaterInfo_ProjectId",
                table: "DOI_GroundWaterInfo",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOI_GroundWaterInfo");
        }
    }
}
