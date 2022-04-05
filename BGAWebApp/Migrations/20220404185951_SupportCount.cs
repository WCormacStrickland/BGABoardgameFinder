using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BGAWebApp.Migrations
{
    public partial class SupportCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupportCount",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupportCount",
                table: "Game");
        }
    }
}
