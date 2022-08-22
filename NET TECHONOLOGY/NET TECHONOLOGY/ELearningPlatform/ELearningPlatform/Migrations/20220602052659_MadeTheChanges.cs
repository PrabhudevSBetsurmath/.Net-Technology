using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearningPlatform.Migrations
{
    public partial class MadeTheChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "StudentFiles");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentFiles",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "FacultyFiles",
                newName: "FacultyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "StudentFiles",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "FacultyName",
                table: "FacultyFiles",
                newName: "FacultyId");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "StudentFiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
