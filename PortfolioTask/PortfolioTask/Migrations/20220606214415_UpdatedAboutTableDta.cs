using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioTask.Migrations
{
    public partial class UpdatedAboutTableDta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "About",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "About");
        }
    }
}
