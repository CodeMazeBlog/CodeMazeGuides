using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BogusNugetPackage.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsOld = table.Column<int>(type: "int", nullable: false),
                    Personality = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AboutMe", "Address", "Email", "FirstName", "LastName", "Personality", "YearsOld" },
                values: new object[,]
                {
                    { new Guid("1c612c96-19d0-490e-adec-60e85260344e"), "Repudiandae atque perferendis hic delectus ab accusamus delectus. Adipisci nihil voluptas distinctio et repellat dolor est et quo.", "85838 Torphy Cliff, South Ben, Martinique", "Brennan_Huel@yahoo.com", "Brennan", "Huel", 1, 25 },
                    { new Guid("20874be0-9d4a-4f5a-8234-67a8a481e8c3"), "Odio quod voluptas quibusdam amet enim. Ipsam quas itaque unde.", "056 Abdullah Fork, Jasenfort, Norfolk Island", "Winnifred81@yahoo.com", "Winnifred", "Hilpert", 2, 45 },
                    { new Guid("4f0bc77c-9d5b-4f74-b669-a83bca677607"), "Ea aut est nemo.", "6820 Amber Field, North Eulaliamouth, Palestinian Territory", "Griffin.Langworth@hotmail.com", "Griffin", "Langworth", 1, 68 },
                    { new Guid("6ca12bcd-32a8-49a2-8968-2537adbffae6"), "Est in odit minus et ducimus repudiandae sunt. Corrupti quidem quasi maxime molestias quidem.", "854 Hamill Forest, Willchester, Holy See (Vatican City State)", "Aileen_Thiel38@yahoo.com", "Aileen", "Thiel", 1, 30 },
                    { new Guid("8efb3e7d-7085-4a45-8d42-440213e1c6ee"), "Et repellat nihil recusandae non quibusdam accusantium.", "966 Felipe Vista, North Tialand, Azerbaijan", "Rory_Larkin96@gmail.com", "Rory", "Larkin", 1, 31 },
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "EmployeeId", "Fuel", "Manufacturer" },
                values: new object[,]
                {
                    { new Guid("0cba016f-8cde-462b-bb60-0276ace7a5ff"), new Guid("4f0bc77c-9d5b-4f74-b669-a83bca677607"), "Electric", "Smart" },
                    { new Guid("65d71047-dff2-4157-b35f-69ce69256060"), new Guid("20874be0-9d4a-4f5a-8234-67a8a481e8c3"), "Gasoline", "Rolls Royce" },
                    { new Guid("6c5b9c00-8c76-46c2-8323-24fe5d9452a8"), new Guid("6ca12bcd-32a8-49a2-8968-2537adbffae6"), "Electric", "Nissan" },
                    { new Guid("7ca5101f-1ecd-45dd-a4a4-1519b8bc0449"), new Guid("20874be0-9d4a-4f5a-8234-67a8a481e8c3"), "Diesel", "Bentley" },
                    { new Guid("8f4f91f7-64bc-4076-b14a-514b7d0aa78a"), new Guid("4f0bc77c-9d5b-4f74-b669-a83bca677607"), "Electric", "Jeep" },
                    { new Guid("a4c71bdf-c213-473b-be69-6b6b8fed681b"), new Guid("6ca12bcd-32a8-49a2-8968-2537adbffae6"), "Hybrid", "Jaguar" },
                    { new Guid("d46b8ab8-b908-42c5-b95b-bd35bc9ad04f"), new Guid("1c612c96-19d0-490e-adec-60e85260344e"), "Gasoline", "Rolls Royce" },
                    { new Guid("d6ca0659-814f-43ba-a32a-7a1af0aa5467"), new Guid("8efb3e7d-7085-4a45-8d42-440213e1c6ee"), "Electric", "Volvo" },
                    { new Guid("db85c546-072a-407c-a7cd-093d31d9bb0d"), new Guid("1c612c96-19d0-490e-adec-60e85260344e"), "Hybrid", "Bentley" },
                    { new Guid("e7614f08-a682-4557-8fff-98889ab39980"), new Guid("8efb3e7d-7085-4a45-8d42-440213e1c6ee"), "Diesel", "Bentley" },
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EmployeeId",
                table: "Vehicles",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
