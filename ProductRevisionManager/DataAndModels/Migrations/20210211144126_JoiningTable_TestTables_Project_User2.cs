using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAndModels.Migrations
{
    public partial class JoiningTable_TestTables_Project_User2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects2_Users_UserID",
                table: "Projects2");

            migrationBuilder.DropIndex(
                name: "IX_Projects2_UserID",
                table: "Projects2");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Projects2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Projects2",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects2_UserID",
                table: "Projects2",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects2_Users_UserID",
                table: "Projects2",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
