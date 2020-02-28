using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreConsole.Migrations
{
    public partial class addSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "TeacherId", "StandardId", "TeacherName", "TeacherType" },
                values: new object[] { 1, null, "William", null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "TeacherId" },
                values: new object[] { 3, "Hamlet", 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "TeacherId" },
                values: new object[] { 4, "King Lear", 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "TeacherId" },
                values: new object[] { 5, "Othello", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "TeacherId",
                keyValue: 1);
        }
    }
}
