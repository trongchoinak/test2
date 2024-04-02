using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    courseid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    coursename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.courseid);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "studentcourseids",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    courseid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentcourseids", x => x.id);
                    table.ForeignKey(
                        name: "FK_studentcourseids_courses_courseid",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "courseid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentcourseids_students_id",
                        column: x => x.id,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentcourseids_courseid",
                table: "studentcourseids",
                column: "courseid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentcourseids");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
