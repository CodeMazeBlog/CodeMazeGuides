using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SpeakersInMillions" },
                values: new object[] { 1, "English", 1132 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SpeakersInMillions" },
                values: new object[] { 2, "Mandarin", 1117 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SpeakersInMillions" },
                values: new object[] { 3, "Hindi", 665 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SpeakersInMillions" },
                values: new object[] { 4, "Spanish", 534 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SpeakersInMillions" },
                values: new object[] { 5, "French", 280 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SpeakersInMillions" },
                values: new object[] { 6, "Arabic", 274 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SpeakersInMillions" },
                values: new object[] { 7, "Bengali", 265 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SpeakersInMillions" },
                values: new object[] { 8, "Russian", 258 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SpeakersInMillions" },
                values: new object[] { 9, "Portuguese", 234 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name", "SpeakersInMillions" },
                values: new object[] { 10, "Indonesian", 198 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
