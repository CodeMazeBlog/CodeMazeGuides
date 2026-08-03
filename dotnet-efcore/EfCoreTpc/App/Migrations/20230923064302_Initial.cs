using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClothingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Size = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Material = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectronicItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ClothingItems",
                columns: new[] { "Id", "Color", "Description", "Material", "Price", "Size" },
                values: new object[,]
                {
                    { new Guid("674c9e27-4910-45fc-afd1-c4f0741fa33a"), "Black", "Nike Air Max", "Leather", 8000m, "M" },
                    { new Guid("75867853-938b-43d9-a966-7813c21bcf76"), "Red", "Nike Air Max-2", "Leather", 67275m, "M" }
                });

            migrationBuilder.InsertData(
                table: "ElectronicItems",
                columns: new[] { "Id", "Description", "Manufacturer", "Model", "Price" },
                values: new object[,]
                {
                    { new Guid("0672516e-15f5-4d46-a7e3-5fd024ec9505"), "Samsung Galaxy S20", "Samsung", "S20", 67275m },
                    { new Guid("8d360dbc-22ce-467c-93ac-692079ca68c5"), "Samsung Galaxy S21", "Samsung", "S21", 8000m },
                    { new Guid("f46ccdc0-f514-4834-af90-2484a8e81162"), "Samsung Galaxy S10", "Samsung", "S10", 600m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingItems");

            migrationBuilder.DropTable(
                name: "ElectronicItems");
        }
    }
}
