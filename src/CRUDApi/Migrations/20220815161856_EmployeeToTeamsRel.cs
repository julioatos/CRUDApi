using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDApi.Migrations
{
    public partial class EmployeeToTeamsRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevelopmentTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevelopmentTeamEmployee",
                columns: table => new
                {
                    DevelopmentTeamsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentTeamEmployee", x => new { x.DevelopmentTeamsId, x.EmployeesEmployeeId });
                    table.ForeignKey(
                        name: "FK_DevelopmentTeamEmployee_DevelopmentTeams_DevelopmentTeamsId",
                        column: x => x.DevelopmentTeamsId,
                        principalTable: "DevelopmentTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevelopmentTeamEmployee_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTeamEmployee_EmployeesEmployeeId",
                table: "DevelopmentTeamEmployee",
                column: "EmployeesEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevelopmentTeamEmployee");

            migrationBuilder.DropTable(
                name: "DevelopmentTeams");
        }
    }
}
