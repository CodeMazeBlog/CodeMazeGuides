using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptimisticConcurrency.Migrations
{
    /// <inheritdoc />
    public partial class addedversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Product");

            migrationBuilder.AddColumn<Guid>(
                name: "Version",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Product");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Product",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }
    }
}
