using Microsoft.EntityFrameworkCore.Migrations;

namespace OneSkate.Migrations
{
    public partial class Revert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RacerRaces_Racers_RacerId",
                table: "RacerRaces");

            migrationBuilder.DropForeignKey(
                name: "FK_RacerRaces_Races_RaceId",
                table: "RacerRaces");

            migrationBuilder.AddForeignKey(
                name: "FK_RacerRaces_Racers_RacerId",
                table: "RacerRaces",
                column: "RacerId",
                principalTable: "Racers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RacerRaces_Races_RaceId",
                table: "RacerRaces",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RacerRaces_Racers_RacerId",
                table: "RacerRaces");

            migrationBuilder.DropForeignKey(
                name: "FK_RacerRaces_Races_RaceId",
                table: "RacerRaces");

            migrationBuilder.AddForeignKey(
                name: "FK_RacerRaces_Racers_RacerId",
                table: "RacerRaces",
                column: "RacerId",
                principalTable: "Racers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RacerRaces_Races_RaceId",
                table: "RacerRaces",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");
        }
    }
}
