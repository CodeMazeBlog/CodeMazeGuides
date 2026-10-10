using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevertMigration.Migrations
{
    /// <inheritdoc />
    public partial class Hangar_HasDoors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasDoors",
                table: "Hangars",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasDoors",
                table: "Hangars");
        }
    }
}
