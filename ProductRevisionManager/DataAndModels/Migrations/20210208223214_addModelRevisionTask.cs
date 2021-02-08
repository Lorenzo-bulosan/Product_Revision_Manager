using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAndModels.Migrations
{
    public partial class addModelRevisionTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RevisionTasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionID = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urgency = table.Column<int>(type: "int", nullable: false),
                    progress = table.Column<int>(type: "int", nullable: false),
                    links = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionTasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_RevisionTasks_Revisions_RevisionID",
                        column: x => x.RevisionID,
                        principalTable: "Revisions",
                        principalColumn: "RevisionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RevisionTasks_RevisionID",
                table: "RevisionTasks",
                column: "RevisionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevisionTasks");
        }
    }
}
