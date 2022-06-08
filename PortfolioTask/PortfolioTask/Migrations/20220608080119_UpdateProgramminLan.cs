using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioTask.Migrations
{
    public partial class UpdateProgramminLan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "programmingLans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "programmingLans");
        }
    }
}
