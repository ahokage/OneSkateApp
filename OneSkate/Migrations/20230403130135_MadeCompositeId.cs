using Microsoft.EntityFrameworkCore.Migrations;

namespace OneSkate.Migrations
{
    public partial class MadeCompositeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RacerRaces",
                table: "RacerRaces");

            migrationBuilder.DropIndex(
                name: "IX_RacerRaces_RacerId",
                table: "RacerRaces");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RacerRaces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RacerRaces",
                table: "RacerRaces",
                columns: new[] { "RacerId", "RaceId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RacerRaces",
                table: "RacerRaces");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RacerRaces",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RacerRaces",
                table: "RacerRaces",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RacerRaces_RacerId",
                table: "RacerRaces",
                column: "RacerId");
        }
    }
}
