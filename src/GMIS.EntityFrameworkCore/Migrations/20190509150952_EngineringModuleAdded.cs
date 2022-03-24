using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class EngineringModuleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOI_Engineering_HeadWorks",
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
                    HeadWorksType = table.Column<string>(nullable: true),
                    BarrageIsGated = table.Column<bool>(nullable: true),
                    BarrageTotalLength = table.Column<decimal>(nullable: true),
                    NoOfBaysOrGates = table.Column<int>(nullable: true),
                    LengthOfEachBayOpening = table.Column<decimal>(nullable: true),
                    CrestElevation = table.Column<decimal>(nullable: true),
                    HeadOverTheCrest = table.Column<decimal>(nullable: true),
                    CoefficientOfDischarge = table.Column<decimal>(nullable: true),
                    WeirTotalLength = table.Column<decimal>(nullable: true),
                    WeirHeadOverTheCrest = table.Column<decimal>(nullable: true),
                    WeirCrestElevation = table.Column<decimal>(nullable: true),
                    WeirCoefficientOfDischarge = table.Column<decimal>(nullable: true),
                    BankIntakeIsGated = table.Column<bool>(nullable: true),
                    StillLevelLength = table.Column<decimal>(nullable: true),
                    SizeOfOrificeWidth = table.Column<decimal>(nullable: true),
                    SizeOfOrificeHeight = table.Column<decimal>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_HeadWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_HeadWorks_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Engineering_MainCanal",
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
                    IsCanalDirectionLeft = table.Column<bool>(nullable: false),
                    TotalLength = table.Column<decimal>(nullable: false),
                    UnlinedTypeCanalLength = table.Column<decimal>(nullable: false),
                    DesignDischarge = table.Column<decimal>(nullable: false),
                    LinedTypeCanalLength = table.Column<decimal>(nullable: false),
                    TopWidth = table.Column<decimal>(nullable: false),
                    SlideSlope = table.Column<string>(nullable: true),
                    BottomWidth = table.Column<decimal>(nullable: false),
                    LongitudinalSlope = table.Column<string>(nullable: true),
                    NoOfBranchCanal = table.Column<int>(nullable: false),
                    BranchCanalLength = table.Column<decimal>(nullable: false),
                    TotalDepth = table.Column<decimal>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_MainCanal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_MainCanal_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Engineering_MainCanalStructureType",
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
                    OrderNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_MainCanalStructureType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Engineering_RiverHydrology",
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
                    CatchmentArea = table.Column<decimal>(nullable: false),
                    RiverWidthAtHeadWorkSite = table.Column<decimal>(nullable: false),
                    LongitudinalSlopeOfRiver = table.Column<string>(nullable: true),
                    AverageAnnualRiverfall = table.Column<decimal>(nullable: false),
                    FloodDischarge25yrs = table.Column<decimal>(nullable: false),
                    FloodDischarge50yrs = table.Column<decimal>(nullable: false),
                    FloodDischarge100yrs = table.Column<decimal>(nullable: false),
                    FloodDischarge500yrs = table.Column<decimal>(nullable: false),
                    FloodDischarge1000yrs = table.Column<decimal>(nullable: false),
                    MethodOfFloodCalculations = table.Column<string>(nullable: true),
                    MIPHydrologyRegion = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_RiverHydrology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_RiverHydrology_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Engineering_BranchCanal",
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
                    BranchName = table.Column<string>(nullable: true),
                    GCA = table.Column<decimal>(nullable: false),
                    NCA = table.Column<decimal>(nullable: false),
                    UnlinedTypeCanalLength = table.Column<decimal>(nullable: false),
                    LinedTypeCanalLength = table.Column<decimal>(nullable: false),
                    TopLength = table.Column<decimal>(nullable: false),
                    DesignDischarge = table.Column<decimal>(nullable: false),
                    SubBranchLength = table.Column<decimal>(nullable: false),
                    TertiaryLength = table.Column<decimal>(nullable: false),
                    CanalStructure = table.Column<decimal>(nullable: false),
                    MainCanalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_BranchCanal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_BranchCanal_DOI_Engineering_MainCanal_MainCanalId",
                        column: x => x.MainCanalId,
                        principalTable: "DOI_Engineering_MainCanal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Engineering_MainCanalStructureTypeDetails",
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
                    MainCanalId = table.Column<int>(nullable: false),
                    MainCanalStructureTypeId = table.Column<int>(nullable: false),
                    NoOfStructure = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_MainCanalStructureTypeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_MainCanalStructureTypeDetails_DOI_Engineering_MainCanal_MainCanalId",
                        column: x => x.MainCanalId,
                        principalTable: "DOI_Engineering_MainCanal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_MainCanalStructureTypeDetails_DOI_Engineering_MainCanalStructureType_MainCanalStructureTypeId",
                        column: x => x.MainCanalStructureTypeId,
                        principalTable: "DOI_Engineering_MainCanalStructureType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_BranchCanal_MainCanalId",
                table: "DOI_Engineering_BranchCanal",
                column: "MainCanalId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_HeadWorks_ProjectId",
                table: "DOI_Engineering_HeadWorks",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_MainCanal_ProjectId",
                table: "DOI_Engineering_MainCanal",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_MainCanalStructureTypeDetails_MainCanalId",
                table: "DOI_Engineering_MainCanalStructureTypeDetails",
                column: "MainCanalId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_MainCanalStructureTypeDetails_MainCanalStructureTypeId",
                table: "DOI_Engineering_MainCanalStructureTypeDetails",
                column: "MainCanalStructureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_RiverHydrology_ProjectId",
                table: "DOI_Engineering_RiverHydrology",
                column: "ProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOI_Engineering_BranchCanal");

            migrationBuilder.DropTable(
                name: "DOI_Engineering_HeadWorks");

            migrationBuilder.DropTable(
                name: "DOI_Engineering_MainCanalStructureTypeDetails");

            migrationBuilder.DropTable(
                name: "DOI_Engineering_RiverHydrology");

            migrationBuilder.DropTable(
                name: "DOI_Engineering_MainCanal");

            migrationBuilder.DropTable(
                name: "DOI_Engineering_MainCanalStructureType");
        }
    }
}
