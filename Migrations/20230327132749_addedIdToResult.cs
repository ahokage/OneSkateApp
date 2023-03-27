using Microsoft.EntityFrameworkCore.Migrations;

namespace OneSkate.Migrations
{
    public partial class addedIdToResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Results_RacerId",
                table: "Results",
                column: "RacerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_RacerId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Results");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                columns: new[] { "RacerId", "RaceId" });
        }
    }
}
