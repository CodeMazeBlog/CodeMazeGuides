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
                    { new Guid("01df40e2-a098-462b-a42f-50a88ae8927f"), "Voluptatem distinctio exercitationem commodi excepturi inventore. Accusantium dolores consequuntur. Ipsa aut enim voluptatibus sint eos.", "231 Larkin Loaf, Daphneechester, Aruba", "Warren_Rodriguez24@hotmail.com", "Warren", "Rodriguez", 0, 37 },
                    { new Guid("197f4bb5-04d3-41c8-9e6a-7d5e71003ee1"), "Voluptatum eum animi. Voluptate sint enim esse optio. Excepturi asperiores dolorem. Nesciunt assumenda omnis repudiandae fugiat consequuntur et impedit.", "119 Efren Knolls, East Vicenta, United Kingdom", "Rashad95@gmail.com", "Rashad", "McDermott", 0, 36 },
                    { new Guid("1ce4c6f0-a08c-4bea-a7c6-0e5bbf43b6b8"), "Sed enim soluta facere sequi corrupti temporibus possimus ex. Optio ad quis minima doloremque placeat et nam ipsa reiciendis.", "876 Kavon Mountain, New Fredericborough, Botswana", "Alvah58@hotmail.com", "Alvah", "Dicki", 1, 27 },
                    { new Guid("38886041-4440-4f44-9177-acb509de7610"), "Aut odio libero aperiam. Sequi officiis autem molestiae excepturi repellat est molestiae harum et.", "20926 Katelin Centers, New Rileyport, Bangladesh", "Mittie30@hotmail.com", "Mittie", "Greenfelder", 1, 60 },
                    { new Guid("8abcd94b-490d-4e5e-9c6e-4caeefd89d8c"), "Voluptas expedita dolor pariatur. Amet ea animi doloremque voluptatum consectetur quia dolorem ut explicabo.", "89201 Muller Village, Koeppview, Brunei Darussalam", "Joesph.Schoen78@hotmail.com", "Joesph", "Schoen", 1, 52 },
                    { new Guid("8fc9af11-7c57-4967-a18e-eaee2b57dfe7"), "Rerum voluptates voluptatibus impedit. Esse quod placeat earum. Minima enim laboriosam laborum. Illum ipsa animi aliquid.", "7877 Konopelski Village, Roweside, Somalia", "Alessandra.Murray@yahoo.com", "Alessandra", "Murray", 1, 46 },
                    { new Guid("a58e9c9e-45a2-489e-88d2-4554b585dce1"), "Exercitationem consequatur hic. Quos possimus pariatur facilis illum non quis.", "9466 Abshire Wall, West Crawfordbury, Mozambique", "Clemmie_Nader10@yahoo.com", "Clemmie", "Nader", 0, 84 },
                    { new Guid("b000ed0a-2921-4708-ad31-0cc0bd8766d6"), "Qui et dolorum a. Sunt quos beatae ad consectetur laborum voluptatem quis possimus et.", "09720 Pattie Isle, Jaskolskifort, Vietnam", "Alessandra.Volkman49@gmail.com", "Alessandra", "Volkman", 0, 79 },
                    { new Guid("dca79394-4910-4111-aba5-6b780a16b537"), "Ut asperiores fugiat rerum. Mollitia sapiente nostrum et enim excepturi optio. Dolorem expedita voluptas quia dolor rerum tempora cupiditate quas.", "2005 Maximo Drive, Baumbachshire, Republic of Korea", "Ross.Zemlak67@hotmail.com", "Ross", "Zemlak", 1, 24 },
                    { new Guid("e45cae6a-9067-4de6-b623-a0a05252ef56"), "Alias omnis aut quisquam aut eligendi et quae quae. Nostrum ab natus. Velit aut vel dicta esse nobis eos.", "982 McClure Cliffs, Lednerton, Czech Republic", "Raleigh_Fisher@hotmail.com", "Raleigh", "Fisher", 2, 62 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "EmployeeId", "Fuel", "Manufacturer" },
                values: new object[,]
                {
                    { new Guid("02472ac2-e5be-4b58-b020-cadcb3df4fcd"), new Guid("01df40e2-a098-462b-a42f-50a88ae8927f"), "Hybrid", "Hyundai" },
                    { new Guid("0393fcb8-8949-4643-81f5-a155de8318d7"), new Guid("38886041-4440-4f44-9177-acb509de7610"), "Hybrid", "Porsche" },
                    { new Guid("34ec95ff-bd85-4dcb-9d8a-885214b42658"), new Guid("b000ed0a-2921-4708-ad31-0cc0bd8766d6"), "Gasoline", "Nissan" },
                    { new Guid("38cd29d8-70ad-429d-bfad-e9f027616aa0"), new Guid("01df40e2-a098-462b-a42f-50a88ae8927f"), "Electric", "Cadillac" },
                    { new Guid("4134a7e1-550f-4516-9b62-e0a39238fa31"), new Guid("8fc9af11-7c57-4967-a18e-eaee2b57dfe7"), "Hybrid", "Volvo" },
                    { new Guid("48eb6671-c070-4d4a-a261-e32f89027b31"), new Guid("8fc9af11-7c57-4967-a18e-eaee2b57dfe7"), "Gasoline", "Porsche" },
                    { new Guid("4f4bd1a7-1140-458f-92ad-bf635b4757a7"), new Guid("197f4bb5-04d3-41c8-9e6a-7d5e71003ee1"), "Gasoline", "Maserati" },
                    { new Guid("54326028-31f7-426b-be1f-a40c6092f3b6"), new Guid("01df40e2-a098-462b-a42f-50a88ae8927f"), "Gasoline", "Fiat" },
                    { new Guid("67d44350-56ed-4a3c-b481-a01e45368535"), new Guid("dca79394-4910-4111-aba5-6b780a16b537"), "Electric", "Honda" },
                    { new Guid("6e9523ae-81f8-4d91-a19c-2ffa21e71f67"), new Guid("1ce4c6f0-a08c-4bea-a7c6-0e5bbf43b6b8"), "Diesel", "Land Rover" },
                    { new Guid("71332782-1ecb-4c1a-889c-badb0be910a2"), new Guid("a58e9c9e-45a2-489e-88d2-4554b585dce1"), "Electric", "Toyota" },
                    { new Guid("76aebab7-5e11-49ff-a766-3df00130f6c2"), new Guid("8abcd94b-490d-4e5e-9c6e-4caeefd89d8c"), "Electric", "Porsche" },
                    { new Guid("83e68c03-48e8-40e9-b841-a86dbf6c6fcb"), new Guid("e45cae6a-9067-4de6-b623-a0a05252ef56"), "Gasoline", "Land Rover" },
                    { new Guid("88b7786e-c5fb-490a-b4b8-20f43398972e"), new Guid("8abcd94b-490d-4e5e-9c6e-4caeefd89d8c"), "Electric", "BMW" },
                    { new Guid("9342ea97-0fe2-49cb-a473-f150d9f4542e"), new Guid("197f4bb5-04d3-41c8-9e6a-7d5e71003ee1"), "Electric", "Fiat" },
                    { new Guid("94142ea2-3e00-4a55-950e-76a4e7233661"), new Guid("b000ed0a-2921-4708-ad31-0cc0bd8766d6"), "Gasoline", "Dodge" },
                    { new Guid("99b5ddf9-946e-434a-9c59-6a01e3bba937"), new Guid("b000ed0a-2921-4708-ad31-0cc0bd8766d6"), "Gasoline", "Bentley" },
                    { new Guid("9aadb057-2f6c-43bd-99ee-77bc0ab232f0"), new Guid("1ce4c6f0-a08c-4bea-a7c6-0e5bbf43b6b8"), "Hybrid", "Mazda" },
                    { new Guid("9f0a4d1d-2835-4fd6-9b16-11074068adf1"), new Guid("197f4bb5-04d3-41c8-9e6a-7d5e71003ee1"), "Hybrid", "Chevrolet" },
                    { new Guid("9fcb53a1-523e-4a20-96c4-60a66dfbc477"), new Guid("dca79394-4910-4111-aba5-6b780a16b537"), "Diesel", "Cadillac" },
                    { new Guid("a66d700f-4637-4b31-9678-df8e0aa58a1d"), new Guid("dca79394-4910-4111-aba5-6b780a16b537"), "Gasoline", "Toyota" },
                    { new Guid("adbfd39a-3538-47ef-9e73-0de9fb970bb4"), new Guid("8fc9af11-7c57-4967-a18e-eaee2b57dfe7"), "Electric", "Audi" },
                    { new Guid("b39f687d-fce5-4551-90bd-d90fa2076e82"), new Guid("8abcd94b-490d-4e5e-9c6e-4caeefd89d8c"), "Gasoline", "BMW" },
                    { new Guid("b8697d0d-f1e8-4caf-982e-ef0b36bafd0b"), new Guid("a58e9c9e-45a2-489e-88d2-4554b585dce1"), "Diesel", "Jaguar" },
                    { new Guid("c50c2862-3d6e-4874-97af-3de6227f15a7"), new Guid("a58e9c9e-45a2-489e-88d2-4554b585dce1"), "Hybrid", "Land Rover" },
                    { new Guid("cb35986c-b53d-48a4-ad5f-0dbead96deeb"), new Guid("38886041-4440-4f44-9177-acb509de7610"), "Diesel", "Volkswagen" },
                    { new Guid("d2227cb4-2f68-4f89-b6fe-6771d70a5225"), new Guid("1ce4c6f0-a08c-4bea-a7c6-0e5bbf43b6b8"), "Diesel", "Hyundai" },
                    { new Guid("d97fa1a3-cc99-485a-9074-c3e040e52973"), new Guid("e45cae6a-9067-4de6-b623-a0a05252ef56"), "Hybrid", "Ford" },
                    { new Guid("e2c1ef24-2635-49ff-a943-f535f4c39016"), new Guid("e45cae6a-9067-4de6-b623-a0a05252ef56"), "Electric", "Volvo" },
                    { new Guid("fc03210d-9322-4be5-bdfc-12c31733a706"), new Guid("38886041-4440-4f44-9177-acb509de7610"), "Diesel", "Maserati" }
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
