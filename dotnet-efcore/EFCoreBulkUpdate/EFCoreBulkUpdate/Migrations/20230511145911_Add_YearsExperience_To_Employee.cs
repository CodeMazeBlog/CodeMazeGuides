using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreBulkUpdate.Migrations
{
    /// <inheritdoc />
    public partial class Add_YearsExperience_To_Employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YearsExperience",
                table: "Referees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearsExperience",
                table: "Organizers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearsExperience",
                table: "Referees");

            migrationBuilder.DropColumn(
                name: "YearsExperience",
                table: "Organizers");
        }
    }
}
