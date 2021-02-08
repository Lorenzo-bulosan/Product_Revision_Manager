using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAndModels.Migrations
{
    public partial class createdRevisionRoundModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RevisionID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RevisionRounds",
                columns: table => new
                {
                    RevisionRoundID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevisionID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionRounds", x => x.RevisionRoundID);
                    table.ForeignKey(
                        name: "FK_RevisionRounds_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RevisionRounds_ProjectID",
                table: "RevisionRounds",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevisionRounds");

            migrationBuilder.DropColumn(
                name: "RevisionID",
                table: "Projects");
        }
    }
}
