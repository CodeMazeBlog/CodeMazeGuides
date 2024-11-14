using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptimisticVsPessimisticLocking.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemsWithConcurrencyToken",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemsWithConcurrencyToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemsWithRowVersion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemsWithRowVersion", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "Id", "AssignedTo", "Description", "DueDate", "Status", "Title" },
                values: new object[] { 1L, null, "Write an article about optimistic and pessimistic database locking", new DateTime(2024, 10, 25, 21, 55, 13, 332, DateTimeKind.Local).AddTicks(7509), "Open", "Optimistic vs Pessimistic locking" });

            migrationBuilder.InsertData(
                table: "WorkItemsWithConcurrencyToken",
                columns: new[] { "Id", "AssignedTo", "Description", "DueDate", "Status", "Title", "Version" },
                values: new object[] { 3L, null, "Write an article about optimistic and pessimistic database locking", new DateTime(2024, 10, 25, 21, 55, 13, 332, DateTimeKind.Local).AddTicks(7725), "Open", "Optimistic vs Pessimistic locking", 0L });

            migrationBuilder.InsertData(
                table: "WorkItemsWithRowVersion",
                columns: new[] { "Id", "AssignedTo", "Description", "DueDate", "Status", "Title" },
                values: new object[] { 2L, null, "Write an article about optimistic and pessimistic database locking", new DateTime(2024, 10, 25, 21, 55, 13, 332, DateTimeKind.Local).AddTicks(7699), "Open", "Optimistic vs Pessimistic locking" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkItems");

            migrationBuilder.DropTable(
                name: "WorkItemsWithConcurrencyToken");

            migrationBuilder.DropTable(
                name: "WorkItemsWithRowVersion");
        }
    }
}
