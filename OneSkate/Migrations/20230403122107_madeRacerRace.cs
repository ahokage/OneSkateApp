using Microsoft.EntityFrameworkCore.Migrations;

namespace OneSkate.Migrations
{
    public partial class madeRacerRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racers_Races_RaceId",
                table: "Racers");

            migrationBuilder.DropIndex(
                name: "IX_Racers_RaceId",
                table: "Racers");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "Racers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "Racers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Racers_RaceId",
                table: "Racers",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Racers_Races_RaceId",
                table: "Racers",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
