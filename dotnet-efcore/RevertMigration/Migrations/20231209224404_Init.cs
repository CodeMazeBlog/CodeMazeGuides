using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevertMigration.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hangars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HangarNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hangars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TailNumber = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfEngines = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxAirSpeed = table.Column<double>(type: "REAL", nullable: false),
                    RunsOnJetFuel = table.Column<bool>(type: "INTEGER", nullable: false),
                    HangarId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airplanes_Hangars_HangarId",
                        column: x => x.HangarId,
                        principalTable: "Hangars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airplanes_HangarId",
                table: "Airplanes",
                column: "HangarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "Hangars");
        }
    }
}
