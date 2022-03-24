using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class addedFileuploadsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOI_FileUploads",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    DocType = table.Column<byte>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_FileUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_FileUploads_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOI_FileUploads_ProjectId",
                table: "DOI_FileUploads",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOI_FileUploads");
        }
    }
}
