using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Migrations
{
    public partial class AddId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Bets");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Bets");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
