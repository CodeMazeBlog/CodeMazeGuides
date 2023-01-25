using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityByExamples.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Name", "Position" },
                values: new object[] { new Guid("e310a6cb-6677-4aa6-93c7-2763956f7a97"), 26, "Mark Miens", "Software Developer" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Name", "Position" },
                values: new object[] { new Guid("398d10fe-4b8d-4606-8e9c-bd2c78d4e001"), 29, "Anna Simmons", "Software Developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
