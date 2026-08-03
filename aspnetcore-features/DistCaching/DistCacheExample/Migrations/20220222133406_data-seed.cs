using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistCacheExample.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "uncle.bob@gmail.com", "Uncle", "Bob", "999-888-7777" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2L, new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "jan.kirsten@gmail.com", "Jan", "Kirsten", "111-222-3333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2L);
        }
    }
}
