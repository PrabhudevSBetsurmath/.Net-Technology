using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearningPlatform.Migrations
{
    public partial class MadechangesInModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Chat",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Chat",
                newName: "FacultyName");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "CalenderEvents",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "CalenderEvents",
                newName: "FacultyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Chat",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "FacultyName",
                table: "Chat",
                newName: "FacultyId");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "CalenderEvents",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "FacultyName",
                table: "CalenderEvents",
                newName: "FacultyId");
        }
    }
}
