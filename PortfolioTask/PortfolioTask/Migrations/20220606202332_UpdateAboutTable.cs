using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioTask.Migrations
{
    public partial class UpdateAboutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "About",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Github",
                table: "About",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkEdin",
                table: "About",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "About",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Github",
                table: "About");

            migrationBuilder.DropColumn(
                name: "LinkEdin",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "About");
        }
    }
}
