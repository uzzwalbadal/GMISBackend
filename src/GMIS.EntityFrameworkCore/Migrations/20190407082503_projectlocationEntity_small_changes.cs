using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class projectlocationEntity_small_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_District_DistrictId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_LocalBodyName_LocalBodyNameId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_LocalBodyType_LocalBodyTypeId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_Provience_ProvienceId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropIndex(
                name: "IX_DOI_LocationProjectRelation_DistrictId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropIndex(
                name: "IX_DOI_LocationProjectRelation_LocalBodyNameId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropIndex(
                name: "IX_DOI_LocationProjectRelation_LocalBodyTypeId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropColumn(
                name: "LocalBodyNameId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.DropColumn(
                name: "LocalBodyTypeId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.RenameColumn(
                name: "ProvienceId",
                table: "DOI_LocationProjectRelation",
                newName: "LocationRelationId");

            migrationBuilder.RenameIndex(
                name: "IX_DOI_LocationProjectRelation_ProvienceId",
                table: "DOI_LocationProjectRelation",
                newName: "IX_DOI_LocationProjectRelation_LocationRelationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_Relation_LocationRelationId",
                table: "DOI_LocationProjectRelation",
                column: "LocationRelationId",
                principalTable: "DOI_Location_Relation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_Relation_LocationRelationId",
                table: "DOI_LocationProjectRelation");

            migrationBuilder.RenameColumn(
                name: "LocationRelationId",
                table: "DOI_LocationProjectRelation",
                newName: "ProvienceId");

            migrationBuilder.RenameIndex(
                name: "IX_DOI_LocationProjectRelation_LocationRelationId",
                table: "DOI_LocationProjectRelation",
                newName: "IX_DOI_LocationProjectRelation_ProvienceId");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "DOI_LocationProjectRelation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalBodyNameId",
                table: "DOI_LocationProjectRelation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalBodyTypeId",
                table: "DOI_LocationProjectRelation",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_District_DistrictId",
                table: "DOI_LocationProjectRelation",
                column: "DistrictId",
                principalTable: "DOI_Location_District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_LocalBodyName_LocalBodyNameId",
                table: "DOI_LocationProjectRelation",
                column: "LocalBodyNameId",
                principalTable: "DOI_Location_LocalBodyName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_LocalBodyType_LocalBodyTypeId",
                table: "DOI_LocationProjectRelation",
                column: "LocalBodyTypeId",
                principalTable: "DOI_Location_LocalBodyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DOI_LocationProjectRelation_DOI_Location_Provience_ProvienceId",
                table: "DOI_LocationProjectRelation",
                column: "ProvienceId",
                principalTable: "DOI_Location_Provience",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
