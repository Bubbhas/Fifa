using Microsoft.EntityFrameworkCore.Migrations;

namespace FifaPlayers.Migrations
{
    public partial class SolveDbShit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_UserTeams_UserTeamId",
                table: "FootballPlayers");

            migrationBuilder.DropIndex(
                name: "IX_FootballPlayers_UserTeamId",
                table: "FootballPlayers");

            migrationBuilder.DropColumn(
                name: "UserTeamId",
                table: "FootballPlayers");

            migrationBuilder.AddColumn<int>(
                name: "UserTeamId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "FootballPlayers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RealTeamId",
                table: "FootballPlayers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTeamId",
                table: "Users",
                column: "UserTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_RealTeamId",
                table: "FootballPlayers",
                column: "RealTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_RealTeams_RealTeamId",
                table: "FootballPlayers",
                column: "RealTeamId",
                principalTable: "RealTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTeams_UserTeamId",
                table: "Users",
                column: "UserTeamId",
                principalTable: "UserTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_RealTeams_RealTeamId",
                table: "FootballPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTeams_UserTeamId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTeamId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_FootballPlayers_RealTeamId",
                table: "FootballPlayers");

            migrationBuilder.DropColumn(
                name: "UserTeamId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "FootballPlayers");

            migrationBuilder.DropColumn(
                name: "RealTeamId",
                table: "FootballPlayers");

            migrationBuilder.AddColumn<int>(
                name: "UserTeamId",
                table: "FootballPlayers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_UserTeamId",
                table: "FootballPlayers",
                column: "UserTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_UserTeams_UserTeamId",
                table: "FootballPlayers",
                column: "UserTeamId",
                principalTable: "UserTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
