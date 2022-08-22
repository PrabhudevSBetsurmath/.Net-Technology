using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearningPlatform.Migrations
{
    public partial class FileModelEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Files",
                newName: "UserEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Files",
                newName: "Name");
        }
    }
}
