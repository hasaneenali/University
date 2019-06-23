using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityCore.Migrations
{
    public partial class deyerere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_College",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CollegeId",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Colleges",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_College",
                table: "Departments",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "CollegeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_College",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CollegeId",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Colleges",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Department_College",
                table: "Departments",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "CollegeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
