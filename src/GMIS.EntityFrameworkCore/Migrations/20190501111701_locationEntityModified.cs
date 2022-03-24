using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class locationEntityModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_Relation_LocationRelationId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropTable(
                name: "DOI_Location_Relation");

            migrationBuilder.RenameColumn(
                name: "LocationRelationId",
                table: "DOI_LocationProjectRelation",
                newName: "LocationLocalBodyNameId");

            migrationBuilder.RenameIndex(
                name: "IX_DOI_LocationProjectRelation_LocationRelationId",
                table: "DOI_LocationProjectRelation",
                newName: "IX_DOI_LocationProjectRelation_LocationLocalBodyNameId");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "DOI_Location_LocalBodyName",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalBodyTypeId",
                table: "DOI_Location_LocalBodyName",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvienceId",
                table: "DOI_Location_District",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCultivatedArea",
                table: "DOI_AgricultureInfo",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Location_LocalBodyName_DistrictId",
                table: "DOI_Location_LocalBodyName",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Location_LocalBodyName_LocalBodyTypeId",
                table: "DOI_Location_LocalBodyName",
                column: "LocalBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_Location_District_ProvienceId",
                table: "DOI_Location_District",
                column: "ProvienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DOI_Location_District_DOI_Location_Provience_ProvienceId",
                table: "DOI_Location_District",
                column: "ProvienceId",
                principalTable: "DOI_Location_Provience",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DOI_Location_LocalBodyName_DOI_Location_District_DistrictId",
                table: "DOI_Location_LocalBodyName",
                column: "DistrictId",
                principalTable: "DOI_Location_District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DOI_Location_LocalBodyName_DOI_Location_LocalBodyType_LocalBodyTypeId",
                table: "DOI_Location_LocalBodyName",
                column: "LocalBodyTypeId",
                principalTable: "DOI_Location_LocalBodyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_LocalBodyName_LocationLocalBodyNameId",
                table: "DOI_LocationProjectRelation",
                column: "LocationLocalBodyNameId",
                principalTable: "DOI_Location_LocalBodyName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DOI_Location_District_DOI_Location_Provience_ProvienceId",
                table: "DOI_Location_District");

            migrationBuilder.DropForeignKey(
                name: "FK_DOI_Location_LocalBodyName_DOI_Location_District_DistrictId",
                table: "DOI_Location_LocalBodyName");

            migrationBuilder.DropForeignKey(
                name: "FK_DOI_Location_LocalBodyName_DOI_Location_LocalBodyType_LocalBodyTypeId",
                table: "DOI_Location_LocalBodyName");

            migrationBuilder.DropForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_LocalBodyName_LocationLocalBodyNameId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropIndex(
                name: "IX_DOI_Location_LocalBodyName_DistrictId",
                table: "DOI_Location_LocalBodyName");

            migrationBuilder.DropIndex(
                name: "IX_DOI_Location_LocalBodyName_LocalBodyTypeId",
                table: "DOI_Location_LocalBodyName");

            migrationBuilder.DropIndex(
                name: "IX_DOI_Location_District_ProvienceId",
                table: "DOI_Location_District");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "DOI_Location_LocalBodyName");

            migrationBuilder.DropColumn(
                name: "LocalBodyTypeId",
                table: "DOI_Location_LocalBodyName");

            migrationBuilder.DropColumn(
                name: "ProvienceId",
                table: "DOI_Location_District");

            migrationBuilder.DropColumn(
                name: "TotalCultivatedArea",
                table: "DOI_AgricultureInfo");

            migrationBuilder.RenameColumn(
                name: "LocationLocalBodyNameId",
                table: "DOI_LocationProjectRelation",
                newName: "LocationRelationId");

            migrationBuilder.RenameIndex(
                name: "IX_DOI_LocationProjectRelation_LocationLocalBodyNameId",
                table: "DOI_LocationProjectRelation",
                newName: "IX_DOI_LocationProjectRelation_LocationRelationId");

            migrationBuilder.CreateTable(
                name: "DOI_Location_Relation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
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

            migrationBuilder.AddForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_Relation_LocationRelationId",
                table: "DOI_LocationProjectRelation",
                column: "LocationRelationId",
                principalTable: "DOI_Location_Relation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
