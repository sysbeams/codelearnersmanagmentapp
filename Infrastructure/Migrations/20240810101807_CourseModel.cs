using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CourseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseMode",
                table: "ApplicantEnrollments");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Courses",
                newName: "CourseInformation");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CoverPhotoUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DurationUnit",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseModeId",
                table: "ApplicantEnrollments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CourseMode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMode_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantEnrollments_CourseModeId",
                table: "ApplicantEnrollments",
                column: "CourseModeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMode_CourseId",
                table: "CourseMode",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantEnrollments_CourseMode_CourseModeId",
                table: "ApplicantEnrollments",
                column: "CourseModeId",
                principalTable: "CourseMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantEnrollments_CourseMode_CourseModeId",
                table: "ApplicantEnrollments");

            migrationBuilder.DropTable(
                name: "CourseMode");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantEnrollments_CourseModeId",
                table: "ApplicantEnrollments");

            migrationBuilder.DropColumn(
                name: "DurationUnit",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseModeId",
                table: "ApplicantEnrollments");

            migrationBuilder.RenameColumn(
                name: "CourseInformation",
                table: "Courses",
                newName: "Level");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CoverPhotoUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CourseMode",
                table: "ApplicantEnrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
