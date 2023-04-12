using Microsoft.EntityFrameworkCore.Migrations;

namespace OneSkate.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Races_RaceId",
                table: "Results");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Races_RaceId",
                table: "Results",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Races_RaceId",
                table: "Results");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Races_RaceId",
                table: "Results",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");
        }
    }
}
