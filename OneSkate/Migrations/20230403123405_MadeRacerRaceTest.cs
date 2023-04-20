using Microsoft.EntityFrameworkCore.Migrations;

namespace OneSkate.Migrations
{
    public partial class MadeRacerRaceTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Adfsdas",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adfsdas",
                table: "Races");
        }
    }
}
