using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAndModels.Migrations
{
    public partial class createdRevisionRoundModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RevisionRounds_Projects_ProjectID",
                table: "RevisionRounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RevisionRounds",
                table: "RevisionRounds");

            migrationBuilder.RenameTable(
                name: "RevisionRounds",
                newName: "Revisions");

            migrationBuilder.RenameIndex(
                name: "IX_RevisionRounds_ProjectID",
                table: "Revisions",
                newName: "IX_Revisions_ProjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revisions",
                table: "Revisions",
                column: "RevisionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Revisions_Projects_ProjectID",
                table: "Revisions",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revisions_Projects_ProjectID",
                table: "Revisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revisions",
                table: "Revisions");

            migrationBuilder.RenameTable(
                name: "Revisions",
                newName: "RevisionRounds");

            migrationBuilder.RenameIndex(
                name: "IX_Revisions_ProjectID",
                table: "RevisionRounds",
                newName: "IX_RevisionRounds_ProjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RevisionRounds",
                table: "RevisionRounds",
                column: "RevisionID");

            migrationBuilder.AddForeignKey(
                name: "FK_RevisionRounds_Projects_ProjectID",
                table: "RevisionRounds",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
