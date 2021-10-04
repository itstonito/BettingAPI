using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Migrations
{
    public partial class AddIdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Bets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
