using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneSkate.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClubRework2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racers_Clubs_ClubId",
                table: "Racers");

            migrationBuilder.AddForeignKey(
                name: "FK_Racers_Clubs_ClubId",
                table: "Racers",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racers_Clubs_ClubId",
                table: "Racers");

            migrationBuilder.AddForeignKey(
                name: "FK_Racers_Clubs_ClubId",
                table: "Racers",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");
        }
    }
}
