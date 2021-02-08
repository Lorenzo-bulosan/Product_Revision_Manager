using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAndModels.Migrations
{
    public partial class createdRevisionRoundModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RevisionRounds",
                table: "RevisionRounds");

            migrationBuilder.DropColumn(
                name: "RevisionRoundID",
                table: "RevisionRounds");

            migrationBuilder.AlterColumn<int>(
                name: "RevisionID",
                table: "RevisionRounds",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RevisionRounds",
                table: "RevisionRounds",
                column: "RevisionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RevisionRounds",
                table: "RevisionRounds");

            migrationBuilder.AlterColumn<int>(
                name: "RevisionID",
                table: "RevisionRounds",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RevisionRoundID",
                table: "RevisionRounds",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RevisionRounds",
                table: "RevisionRounds",
                column: "RevisionRoundID");
        }
    }
}
