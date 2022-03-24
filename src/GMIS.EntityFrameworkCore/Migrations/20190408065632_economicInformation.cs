using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class economicInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOI_EconomicInfo",
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
                    CostingYear = table.Column<int>(nullable: false),
                    TotalProjectCost = table.Column<decimal>(nullable: false),
                    GONShare = table.Column<decimal>(nullable: false),
                    WUAShare = table.Column<decimal>(nullable: false),
                    EIRR = table.Column<decimal>(nullable: false),
                    BC1 = table.Column<decimal>(nullable: false),
                    DiscountRate1 = table.Column<decimal>(nullable: false),
                    BC2 = table.Column<decimal>(nullable: false),
                    DiscountRate2 = table.Column<decimal>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_EconomicInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_EconomicInfo_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOI_EconomicInfo_ProjectId",
                table: "DOI_EconomicInfo",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOI_EconomicInfo");
        }
    }
}
