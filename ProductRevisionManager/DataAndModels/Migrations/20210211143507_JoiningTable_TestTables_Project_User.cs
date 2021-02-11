using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAndModels.Migrations
{
    public partial class JoiningTable_TestTables_Project_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Project2ProjectID",
                table: "Revisions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projects2",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects2", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects2_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users2",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    securityLevel = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users2", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    projectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects2_projectID",
                        column: x => x.projectID,
                        principalTable: "Projects2",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjects_Users2_userID",
                        column: x => x.userID,
                        principalTable: "Users2",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_Project2ProjectID",
                table: "Revisions",
                column: "Project2ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects2_UserID",
                table: "Projects2",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_projectID",
                table: "UserProjects",
                column: "projectID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_userID",
                table: "UserProjects",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Revisions_Projects2_Project2ProjectID",
                table: "Revisions",
                column: "Project2ProjectID",
                principalTable: "Projects2",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revisions_Projects2_Project2ProjectID",
                table: "Revisions");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropTable(
                name: "Projects2");

            migrationBuilder.DropTable(
                name: "Users2");

            migrationBuilder.DropIndex(
                name: "IX_Revisions_Project2ProjectID",
                table: "Revisions");

            migrationBuilder.DropColumn(
                name: "Project2ProjectID",
                table: "Revisions");
        }
    }
}
