using Microsoft.EntityFrameworkCore.Migrations;

namespace GMIS.Migrations
{
    public partial class wuaTrainingEntityFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingDays",
                table: "DOI_WUATrainings");

            migrationBuilder.AddColumn<string>(
                name: "TrainingName",
                table: "DOI_WUATrainings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingName",
                table: "DOI_WUATrainings");

            migrationBuilder.AddColumn<int>(
                name: "TrainingDays",
                table: "DOI_WUATrainings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
