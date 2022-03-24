using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class WUAEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOI_ContractMgmt",
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
                    PhysicalProgress = table.Column<string>(nullable: true),
                    PhysicalProgressDate = table.Column<DateTime>(type: "date", nullable: false),
                    FinancialProgress = table.Column<string>(nullable: true),
                    FinancialProgressDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_ContractMgmt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_ContractMgmt_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_WUAInfo",
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
                    WUADetail = table.Column<string>(nullable: true),
                    WUARegistrationProgressDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_WUAInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_WUAInfo_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_WUATrainings",
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
                    TrainingDays = table.Column<int>(nullable: false),
                    NoOfParticipants = table.Column<int>(nullable: false),
                    TrainingPeriod = table.Column<int>(nullable: false),
                    TrainingDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_WUATrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_WUATrainings_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOI_ContractMgmt_ProjectId",
                table: "DOI_ContractMgmt",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DOI_WUAInfo_ProjectId",
                table: "DOI_WUAInfo",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DOI_WUATrainings_ProjectId",
                table: "DOI_WUATrainings",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOI_ContractMgmt");

            migrationBuilder.DropTable(
                name: "DOI_WUAInfo");

            migrationBuilder.DropTable(
                name: "DOI_WUATrainings");
        }
    }
}
