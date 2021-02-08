using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAndModels.Migrations
{
    public partial class ammendingRevisionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revisions_Projects_ProjectID",
                table: "Revisions");

            migrationBuilder.DropColumn(
                name: "RevisionID",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Revisions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Revisions_Projects_ProjectID",
                table: "Revisions",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revisions_Projects_ProjectID",
                table: "Revisions");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Revisions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RevisionID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Revisions_Projects_ProjectID",
                table: "Revisions",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
