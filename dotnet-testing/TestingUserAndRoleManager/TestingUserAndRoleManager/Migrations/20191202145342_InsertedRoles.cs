using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingUserAndRoleManager.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e0246f5-e1b9-46ba-867e-81d1917aaaf7", "1dee1e04-abee-43db-b5d7-69c719165b88", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be7b6b91-2662-4760-8ee1-d966075e524e", "84ff6b93-365d-454a-b810-8bbe8d206491", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e0246f5-e1b9-46ba-867e-81d1917aaaf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be7b6b91-2662-4760-8ee1-d966075e524e");
        }
    }
}
