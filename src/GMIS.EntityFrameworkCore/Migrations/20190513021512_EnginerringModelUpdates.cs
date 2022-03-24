using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class EnginerringModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOI_Engineering_SecondaryCanal",
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
                    GCA = table.Column<decimal>(nullable: false),
                    NCA = table.Column<decimal>(nullable: false),
                    UnlinedTypeCanalLength = table.Column<decimal>(nullable: false),
                    LinedTypeCanalLength = table.Column<decimal>(nullable: false),
                    TopLength = table.Column<decimal>(nullable: false),
                    DesignDischarge = table.Column<decimal>(nullable: false),
                    SubBranchLength = table.Column<decimal>(nullable: false),
                    TertiaryLength = table.Column<decimal>(nullable: false),
                    CanalStructure = table.Column<decimal>(nullable: false),
                    BranchCanalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_SecondaryCanal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_SecondaryCanal_DOI_Engineering_BranchCanal_BranchCanalId",
                        column: x => x.BranchCanalId,
                        principalTable: "DOI_Engineering_BranchCanal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Engineering_WaterInducedDisasterModel",
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
                    AverageRiverWidth = table.Column<decimal>(nullable: false),
                    AverageRiverSlope1 = table.Column<decimal>(nullable: false),
                    ProtectedArea = table.Column<decimal>(nullable: false),
                    ReclaimedArea = table.Column<decimal>(nullable: false),
                    InlineStructure = table.Column<string>(nullable: true),
                    InlineStructureOthers = table.Column<string>(nullable: true),
                    LateralStructure = table.Column<string>(nullable: true),
                    LateralStructureOthers = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_WaterInducedDisasterModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_WaterInducedDisasterModel_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Engineering_TertiaryCanal",
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
                    GCA = table.Column<decimal>(nullable: false),
                    NCA = table.Column<decimal>(nullable: false),
                    UnlinedTypeCanalLength = table.Column<decimal>(nullable: false),
                    LinedTypeCanalLength = table.Column<decimal>(nullable: false),
                    TopLength = table.Column<decimal>(nullable: false),
                    DesignDischarge = table.Column<decimal>(nullable: false),
                    SubBranchLength = table.Column<decimal>(nullable: false),
                    TertiaryLength = table.Column<decimal>(nullable: false),
                    CanalStructure = table.Column<decimal>(nullable: false),
                    SecondaryCanalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_TertiaryCanal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_TertiaryCanal_DOI_Engineering_SecondaryCanal_SecondaryCanalId",
                        column: x => x.SecondaryCanalId,
                        principalTable: "DOI_Engineering_SecondaryCanal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Engineering_WaterInduced_Embankment",
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
                    No = table.Column<int>(nullable: false),
                    LocationChainage = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    HFL = table.Column<decimal>(nullable: false),
                    LWL = table.Column<decimal>(nullable: false),
                    Materails = table.Column<string>(nullable: true),
                    DesignHeight = table.Column<decimal>(nullable: false),
                    DesignTopWidth = table.Column<decimal>(nullable: false),
                    DesignFreeBoard = table.Column<decimal>(nullable: false),
                    DesignSlideSlope = table.Column<decimal>(nullable: false),
                    DesignLengthOfLaunchingApron = table.Column<decimal>(nullable: false),
                    DesignThicknessOfPitching = table.Column<decimal>(nullable: false),
                    DesignThicknessOfFilter = table.Column<decimal>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    WaterInducedDisasterModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_WaterInduced_Embankment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_WaterInduced_Embankment_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_WaterInduced_Embankment_DOI_Engineering_WaterInducedDisasterModel_WaterInducedDisasterModelId",
                        column: x => x.WaterInducedDisasterModelId,
                        principalTable: "DOI_Engineering_WaterInducedDisasterModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Engineering_WaterInduced_Spur",
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
                    No = table.Column<int>(nullable: false),
                    LocationChainage = table.Column<decimal>(nullable: false),
                    Spacing = table.Column<decimal>(nullable: false),
                    HFL = table.Column<decimal>(nullable: false),
                    LWL = table.Column<decimal>(nullable: false),
                    Types = table.Column<string>(nullable: true),
                    Materails = table.Column<string>(nullable: true),
                    Conditions = table.Column<string>(nullable: true),
                    DesignTopWidth = table.Column<decimal>(nullable: false),
                    DesignFreeboard = table.Column<decimal>(nullable: false),
                    SlideSlope1 = table.Column<string>(nullable: true),
                    LengthOfLaunchingApron = table.Column<decimal>(nullable: false),
                    ThicknessOfPitching = table.Column<decimal>(nullable: false),
                    ThicknessOfFilter = table.Column<decimal>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    WaterInducedDisasterModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Engineering_WaterInduced_Spur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_WaterInduced_Spur_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_Engineering_WaterInduced_Spur_DOI_Engineering_WaterInducedDisasterModel_WaterInducedDisasterModelId",
                        column: x => x.WaterInducedDisasterModelId,
                        principalTable: "DOI_Engineering_WaterInducedDisasterModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_SecondaryCanal_BranchCanalId",
                table: "DOI_Engineering_SecondaryCanal",
                column: "BranchCanalId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_TertiaryCanal_SecondaryCanalId",
                table: "DOI_Engineering_TertiaryCanal",
                column: "SecondaryCanalId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_WaterInduced_Embankment_ProjectId",
                table: "DOI_Engineering_WaterInduced_Embankment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_WaterInduced_Embankment_WaterInducedDisasterModelId",
                table: "DOI_Engineering_WaterInduced_Embankment",
                column: "WaterInducedDisasterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_WaterInduced_Spur_ProjectId",
                table: "DOI_Engineering_WaterInduced_Spur",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_WaterInduced_Spur_WaterInducedDisasterModelId",
                table: "DOI_Engineering_WaterInduced_Spur",
                column: "WaterInducedDisasterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Engineering_WaterInducedDisasterModel_ProjectId",
                table: "DOI_Engineering_WaterInducedDisasterModel",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOI_Engineering_TertiaryCanal");

            migrationBuilder.DropTable(
                name: "DOI_Engineering_WaterInduced_Embankment");

            migrationBuilder.DropTable(
                name: "DOI_Engineering_WaterInduced_Spur");

            migrationBuilder.DropTable(
                name: "DOI_Engineering_SecondaryCanal");

            migrationBuilder.DropTable(
                name: "DOI_Engineering_WaterInducedDisasterModel");
        }
    }
}
