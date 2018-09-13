using Microsoft.EntityFrameworkCore.Migrations;

namespace FifaPlayers.Migrations
{
    public partial class ChangedPKForUserTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTeams_UserTeamId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTeamId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserTeamId",
                table: "Users",
                newName: "ActiveUserTeamId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserTeams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_UserId",
                table: "UserTeams",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_Users_UserId",
                table: "UserTeams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_Users_UserId",
                table: "UserTeams");

            migrationBuilder.DropIndex(
                name: "IX_UserTeams_UserId",
                table: "UserTeams");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserTeams");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ActiveUserTeamId",
                table: "Users",
                newName: "UserTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTeamId",
                table: "Users",
                column: "UserTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTeams_UserTeamId",
                table: "Users",
                column: "UserTeamId",
                principalTable: "UserTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
