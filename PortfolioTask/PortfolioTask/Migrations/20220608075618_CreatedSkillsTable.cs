using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioTask.Migrations
{
    public partial class CreatedSkillsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "programmingLans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programmingLans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workFlows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workFlows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ProgrammingLanId = table.Column<int>(nullable: false),
                    WorkFlowsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_skills_programmingLans_ProgrammingLanId",
                        column: x => x.ProgrammingLanId,
                        principalTable: "programmingLans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skills_workFlows_WorkFlowsId",
                        column: x => x.WorkFlowsId,
                        principalTable: "workFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_skills_ProgrammingLanId",
                table: "skills",
                column: "ProgrammingLanId");

            migrationBuilder.CreateIndex(
                name: "IX_skills_WorkFlowsId",
                table: "skills",
                column: "WorkFlowsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "programmingLans");

            migrationBuilder.DropTable(
                name: "workFlows");
        }
    }
}
