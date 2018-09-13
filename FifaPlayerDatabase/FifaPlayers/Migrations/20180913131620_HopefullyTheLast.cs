using Microsoft.EntityFrameworkCore.Migrations;

namespace FifaPlayers.Migrations
{
    public partial class HopefullyTheLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "FootballPlayers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "FootballPlayers",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FootballPlayers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "FootballPlayers",
                nullable: true);
        }
    }
}
