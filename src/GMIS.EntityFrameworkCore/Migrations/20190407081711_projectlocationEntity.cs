using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class projectlocationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOI_Location_District",
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
                    DistrictName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Location_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Location_LocalBodyName",
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
                    LocalBodyName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Location_LocalBodyName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Location_LocalBodyType",
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
                    LocalBodyTypeName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Location_LocalBodyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Location_Provience",
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
                    ProvienceName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Location_Provience", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOI_LocationMajorRiverBasin",
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
                    RiverBasinName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_LocationMajorRiverBasin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOI_Location_Relation",
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
                    DistrictId = table.Column<int>(nullable: false),
                    LocalBodyNameId = table.Column<int>(nullable: false),
                    LocalBodyTypeId = table.Column<int>(nullable: false),
                    ProvienceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_Location_Relation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_Location_Relation_DOI_Location_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "DOI_Location_District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_Location_Relation_DOI_Location_LocalBodyName_LocalBodyNameId",
                        column: x => x.LocalBodyNameId,
                        principalTable: "DOI_Location_LocalBodyName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_Location_Relation_DOI_Location_LocalBodyType_LocalBodyTypeId",
                        column: x => x.LocalBodyTypeId,
                        principalTable: "DOI_Location_LocalBodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_Location_Relation_DOI_Location_Provience_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "DOI_Location_Provience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_LocationProjectRelation",
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
                    DistrictId = table.Column<int>(nullable: false),
                    LocalBodyNameId = table.Column<int>(nullable: false),
                    LocalBodyTypeId = table.Column<int>(nullable: false),
                    ProvienceId = table.Column<int>(nullable: false),
                    Ward = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_LocationProjectRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_LocationProjectRelation_DOI_Location_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "DOI_Location_District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_LocationProjectRelation_DOI_Location_LocalBodyName_LocalBodyNameId",
                        column: x => x.LocalBodyNameId,
                        principalTable: "DOI_Location_LocalBodyName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_LocationProjectRelation_DOI_Location_LocalBodyType_LocalBodyTypeId",
                        column: x => x.LocalBodyTypeId,
                        principalTable: "DOI_Location_LocalBodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_LocationProjectRelation_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_LocationProjectRelation_DOI_Location_Provience_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "DOI_Location_Provience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_LocationInfo",
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
                    EcologicalRegion = table.Column<string>(nullable: true),
                    NearestRoad = table.Column<string>(nullable: true),
                    AirportDistance = table.Column<decimal>(nullable: false),
                    Airport = table.Column<string>(nullable: true),
                    MarketDistance = table.Column<decimal>(nullable: false),
                    Market = table.Column<string>(nullable: true),
                    RiverBasinDistance = table.Column<decimal>(nullable: false),
                    LocalRiverBasin = table.Column<string>(nullable: true),
                    RiverSource = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    MajorRiverBasinId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_LocationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_LocationInfo_DOI_LocationMajorRiverBasin_MajorRiverBasinId",
                        column: x => x.MajorRiverBasinId,
                        principalTable: "DOI_LocationMajorRiverBasin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_LocationInfo_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Location_Relation_DistrictId",
                table: "DOI_Location_Relation",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Location_Relation_LocalBodyNameId",
                table: "DOI_Location_Relation",
                column: "LocalBodyNameId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Location_Relation_LocalBodyTypeId",
                table: "DOI_Location_Relation",
                column: "LocalBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Location_Relation_ProvienceId",
                table: "DOI_Location_Relation",
                column: "ProvienceId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_LocationInfo_MajorRiverBasinId",
                table: "DOI_LocationInfo",
                column: "MajorRiverBasinId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_LocationInfo_ProjectId",
                table: "DOI_LocationInfo",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_LocationProjectRelation_DistrictId",
                table: "DOI_LocationProjectRelation",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_LocationProjectRelation_LocalBodyNameId",
                table: "DOI_LocationProjectRelation",
                column: "LocalBodyNameId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_LocationProjectRelation_LocalBodyTypeId",
                table: "DOI_LocationProjectRelation",
                column: "LocalBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_LocationProjectRelation_ProjectId",
                table: "DOI_LocationProjectRelation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_LocationProjectRelation_ProvienceId",
                table: "DOI_LocationProjectRelation",
                column: "ProvienceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOI_Location_Relation");

            migrationBuilder.DropTable(
                name: "DOI_LocationInfo");

            migrationBuilder.DropTable(
                name: "DOI_LocationProjectRelation");

            migrationBuilder.DropTable(
                name: "DOI_LocationMajorRiverBasin");

            migrationBuilder.DropTable(
                name: "DOI_Location_District");

            migrationBuilder.DropTable(
                name: "DOI_Location_LocalBodyName");

            migrationBuilder.DropTable(
                name: "DOI_Location_LocalBodyType");

            migrationBuilder.DropTable(
                name: "DOI_Location_Provience");
        }
    }
}
