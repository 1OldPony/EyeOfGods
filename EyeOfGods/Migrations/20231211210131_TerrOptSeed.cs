using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class TerrOptSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapSchemeTerrainOptions");

            migrationBuilder.RenameColumn(
                name: "density",
                table: "TerrainOptions",
                newName: "Density");

            migrationBuilder.AddColumn<int>(
                name: "TerrainOptionsId",
                table: "Map",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuestLevel",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuestLevel",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 3,
                column: "QuestLevel",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 4,
                column: "QuestLevel",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MapHeight", "MapWidth", "Name", "NumbOfCities", "NumbOfResources", "NumbOfTreasuries", "QuestLevel" },
                values: new object[] { 8, 8, "6 точек: 2 Города, 2 Ресурса, 2 Сокровищницы", 2, 2, 2, 1 });

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 6,
                column: "QuestLevel",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Quests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Level",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ForestDensity", "OptionsSetName" },
                values: new object[] { 34, "Затопленная низина" });

            migrationBuilder.InsertData(
                table: "TerrainOptions",
                columns: new[] { "Id", "Density", "ForestDensity", "OptionsSetName", "SwampDensity", "WaterDensity" },
                values: new object[,]
                {
                    { 2, 2, 66, "Низина", 22, 12 },
                    { 3, 2, 66, "Болотистые леса", 34, 0 },
                    { 4, 2, 88, "Лесистая местность", 12, 0 },
                    { 5, 2, 22, "Тысячезерье", 12, 66 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Map_TerrainOptionsId",
                table: "Map",
                column: "TerrainOptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Map_TerrainOptions_TerrainOptionsId",
                table: "Map",
                column: "TerrainOptionsId",
                principalTable: "TerrainOptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Map_TerrainOptions_TerrainOptionsId",
                table: "Map");

            migrationBuilder.DropIndex(
                name: "IX_Map_TerrainOptionsId",
                table: "Map");

            migrationBuilder.DeleteData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "TerrainOptionsId",
                table: "Map");

            migrationBuilder.RenameColumn(
                name: "Density",
                table: "TerrainOptions",
                newName: "density");

            migrationBuilder.CreateTable(
                name: "MapSchemeTerrainOptions",
                columns: table => new
                {
                    SchemesId = table.Column<int>(type: "int", nullable: false),
                    TerrainOptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapSchemeTerrainOptions", x => new { x.SchemesId, x.TerrainOptionsId });
                    table.ForeignKey(
                        name: "FK_MapSchemeTerrainOptions_MapSchemes_SchemesId",
                        column: x => x.SchemesId,
                        principalTable: "MapSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapSchemeTerrainOptions_TerrainOptions_TerrainOptionsId",
                        column: x => x.TerrainOptionsId,
                        principalTable: "TerrainOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuestLevel",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuestLevel",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 3,
                column: "QuestLevel",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 4,
                column: "QuestLevel",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MapHeight", "MapWidth", "Name", "NumbOfCities", "NumbOfResources", "NumbOfTreasuries", "QuestLevel" },
                values: new object[] { 12, 12, "6-ТЕСТ!: 1 Город, 1 Ресурс, 4 Сокровищницы", 1, 1, 4, 0 });

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 6,
                column: "QuestLevel",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Quests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Level",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ForestDensity", "OptionsSetName" },
                values: new object[] { 33, "Тестовая" });

            migrationBuilder.CreateIndex(
                name: "IX_MapSchemeTerrainOptions_TerrainOptionsId",
                table: "MapSchemeTerrainOptions",
                column: "TerrainOptionsId");
        }
    }
}
