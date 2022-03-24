using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class socialInfoEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOI_EthicsGroups",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_EthicsGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOI_EthicsInfos",
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
                    YearOfSurvey = table.Column<int>(nullable: false),
                    NoOfHousehold = table.Column<int>(nullable: false),
                    WomenHeadedHouseHold = table.Column<int>(nullable: false),
                    Female = table.Column<int>(nullable: false),
                    Male = table.Column<int>(nullable: false),
                    TotalPopulation = table.Column<int>(nullable: false),
                    MajorSourceOfIncome = table.Column<string>(nullable: true),
                    AnnualIncomePerFamily = table.Column<decimal>(nullable: false),
                    AnnualIncomePerAgriculture = table.Column<decimal>(nullable: false),
                    AnnualIncomePerOtherSrcs = table.Column<decimal>(nullable: false),
                    LiteracyRate = table.Column<decimal>(nullable: false),
                    FemaleLiteracyRate = table.Column<decimal>(nullable: false),
                    MaleLiteracyRate = table.Column<decimal>(nullable: false),
                    AnnualPopMigrationIn = table.Column<int>(nullable: false),
                    AnnualPopMigrationOut = table.Column<int>(nullable: false),
                    LandOwners = table.Column<int>(nullable: false),
                    LandOwnersPercent = table.Column<decimal>(nullable: false),
                    Tenants = table.Column<int>(nullable: false),
                    TenantsPercent = table.Column<decimal>(nullable: false),
                    OwnerWithTenants = table.Column<int>(nullable: false),
                    OwnerWithTenantsPercent = table.Column<decimal>(nullable: false),
                    FarmSizeSmall = table.Column<int>(nullable: false),
                    FarmSizeMedium = table.Column<int>(nullable: false),
                    FarmSizeLarge = table.Column<int>(nullable: false),
                    FarmSizeVeryLarge = table.Column<int>(nullable: false),
                    FoodSufficiency = table.Column<string>(nullable: true),
                    FoodSufficiencMonth = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    EthicsGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_EthicsInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_EthicsInfos_DOI_EthicsGroups_EthicsGroupId",
                        column: x => x.EthicsGroupId,
                        principalTable: "DOI_EthicsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOI_EthicsInfos_DOI_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DOI_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DOI_EthicsData",
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
                    EthicsGroupId = table.Column<int>(nullable: false),
                    SocialInfoId = table.Column<int>(nullable: false),
                    NoOfPeople = table.Column<int>(nullable: false),
                    NoOfPeoplePercent = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_EthicsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DOI_EthicsData_DOI_EthicsGroups_EthicsGroupId",
                        column: x => x.EthicsGroupId,
                        principalTable: "DOI_EthicsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DOI_EthicsData_DOI_EthicsInfos_SocialInfoId",
                        column: x => x.SocialInfoId,
                        principalTable: "DOI_EthicsInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOI_EthicsData_EthicsGroupId",
                table: "DOI_EthicsData",
                column: "EthicsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_EthicsData_SocialInfoId",
                table: "DOI_EthicsData",
                column: "SocialInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_EthicsInfos_EthicsGroupId",
                table: "DOI_EthicsInfos",
                column: "EthicsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DOI_EthicsInfos_ProjectId",
                table: "DOI_EthicsInfos",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOI_EthicsData");

            migrationBuilder.DropTable(
                name: "DOI_EthicsInfos");

            migrationBuilder.DropTable(
                name: "DOI_EthicsGroups");
        }
    }
}
