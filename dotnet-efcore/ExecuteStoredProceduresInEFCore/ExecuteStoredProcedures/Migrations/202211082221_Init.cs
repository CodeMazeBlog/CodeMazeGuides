using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExecuteStoredProceduresInEFCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");


            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[FindStudents]
	                                    @SearchFor NVARCHAR(50)
                                    AS
                                    BEGIN
	                                    SET NOCOUNT ON;
	                                    SELECT * FROM Students WHERE [Name] LIKE '%' + @SearchFor + '%'
                                    END");

            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[FindStudentsAlt]
	                                    @SearchFor NVARCHAR(50)
                                    AS
                                    BEGIN
	                                    SET NOCOUNT ON;
	                                    SELECT 
		                                    StudentName = S.[Name],
		                                    CourseTitle = C.Title
	                                    FROM 
		                                    Students S
	                                    LEFT JOIN Courses C ON S.CourseId = C.Id 
	                                    WHERE 
		                                    S.[Name] LIKE '%' + @SearchFor + '%'
                                    END");

            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE UpdateStudentMark
	                                    @Id int,
	                                    @Mark int
                                    AS
                                    BEGIN
	                                    UPDATE 
		                                    Students
	                                    SET 
		                                    Mark = @Mark
	                                    WHERE 
		                                    Id = @Id;
                                    END");

            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE UpdateStudentMarkWithReturnValue
                                        @Id int,
                                        @Mark int,
	                                    @AvgMark int OUTPUT
                                    AS
                                    BEGIN
                                        UPDATE 
                                            Students
                                        SET 
                                            Mark = @Mark
                                        WHERE 
                                            Id = @Id;

	                                    SELECT @AvgMark = AVG(Mark) FROM Students
                                    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.Sql("DROP PROCEDURE [dbo].[FindStudents]");

            migrationBuilder.Sql("DROP PROCEDURE [dbo].[FindStudentsAlt]");

            migrationBuilder.Sql("DROP PROCEDURE [dbo].[UpdateStudentMark]");

        }
    }
}
