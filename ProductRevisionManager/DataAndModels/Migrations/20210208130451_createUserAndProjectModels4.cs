using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAndModels.Migrations
{
    public partial class createUserAndProjectModels4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
