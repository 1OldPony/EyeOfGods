using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class schemeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MapSchemes",
                columns: new[] { "Id", "GodPresense", "MapHeight", "MapWidth", "MaxDensityAvail", "Name", "NumbOfCities", "NumbOfResources", "NumbOfTreasuries", "QuestLevel" },
                values: new object[,]
                {
                    { 1, 4, 12, 12, 2, "6 точек: 2 Города, 2 Ресурса, 2 Сокровищницы", 2, 2, 2, 0 },
                    { 2, 4, 8, 8, 2, "7 точек: Тестовая", 3, 2, 2, 0 },
                    { 3, 4, 8, 8, 2, "8 точек: Тестовая", 3, 2, 2, 0 },
                    { 4, 4, 12, 12, 2, "5 точек: Тестовая", 3, 2, 2, 0 },
                    { 5, 4, 12, 12, 2, "6-ТЕСТ!: 1 Город, 1 Ресурс, 4 Сокровищницы", 1, 1, 4, 0 },
                    { 6, 4, 8, 12, 2, "6-ТЕСТ!: 1 Город, 3 Ресурса, 2 Сокровищницы", 1, 3, 2, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
