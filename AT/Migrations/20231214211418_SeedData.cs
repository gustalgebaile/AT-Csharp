using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Jogador",
                columns: new[] { "Id", "Nome", "Data" },
                values: new object[,]
                {
                    { 1, "Vegetti", new DateTime(2023, 12, 14, 18, 14, 18, 313, DateTimeKind.Local).AddTicks(6351) },
                    { 2, "Ribamar", new DateTime(2023, 12, 14, 18, 14, 18, 313, DateTimeKind.Local).AddTicks(6352) }
                });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "Nome", "Data" },
                values: new object[,]
                {
                    { 1, "Vasco", new DateTime(2023, 12, 14, 18, 14, 18, 313, DateTimeKind.Local).AddTicks(6490) },
                    { 2, "Atlético MG", new DateTime(2023, 12, 14, 18, 14, 18, 313, DateTimeKind.Local).AddTicks(6491) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
