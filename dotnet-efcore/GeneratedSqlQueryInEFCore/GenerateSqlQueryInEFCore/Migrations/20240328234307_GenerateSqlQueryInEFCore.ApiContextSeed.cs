using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GenerateSqlQueryInEFCore.Migrations
{
    /// <inheritdoc />
    public partial class GenerateSqlQueryInEFCoreApiContextSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Model", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "BMW", "1 Series", "118d HatchBack", 2012 },
                    { 2, "BMW", "1 Series", "118d M Sport 3 Door HatchBack", 2013 },
                    { 3, "BMW", "2 Series", "228i Sport Convertible", 2015 },
                    { 4, "BMW", "3 Series", "328i HatchBack", 2016 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
