using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class fileuploadEntityModelModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "DOI_FileUploads",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "DOI_FileUploads",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DOI_FileUploads",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "DOI_FileUploads");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "DOI_FileUploads");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DOI_FileUploads");
        }
    }
}
