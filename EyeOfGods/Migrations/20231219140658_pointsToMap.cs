using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class pointsToMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestPoint_Map_MapId",
                table: "InterestPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestPoint_Quests_QuestId",
                table: "InterestPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_Terrain_Map_MapId",
                table: "Terrain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terrain",
                table: "Terrain");

            migrationBuilder.DropIndex(
                name: "IX_Terrain_MapId",
                table: "Terrain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestPoint",
                table: "InterestPoint");

            migrationBuilder.DropIndex(
                name: "IX_InterestPoint_MapId",
                table: "InterestPoint");

            migrationBuilder.DropIndex(
                name: "IX_InterestPoint_QuestId",
                table: "InterestPoint");

            migrationBuilder.DeleteData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Density",
                table: "TerrainOptions");

            migrationBuilder.DropColumn(
                name: "QuestLevel",
                table: "MapSchemes");

            migrationBuilder.DropColumn(
                name: "QuestId",
                table: "InterestPoint");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "Terrain",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Density",
                table: "Map",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestLevel",
                table: "Map",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "InterestPoint",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terrain",
                table: "Terrain",
                columns: new[] { "MapId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestPoint",
                table: "InterestPoint",
                columns: new[] { "MapId", "Id" });

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MapHeight", "Name" },
                values: new object[] { 12, "7 точек: фиктивная" });

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MapWidth", "Name" },
                values: new object[] { 12, "8 точек: фиктивная" });

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "7 точек: фиктивная");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPoint_Map_MapId",
                table: "InterestPoint",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Terrain_Map_MapId",
                table: "Terrain",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestPoint_Map_MapId",
                table: "InterestPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_Terrain_Map_MapId",
                table: "Terrain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terrain",
                table: "Terrain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestPoint",
                table: "InterestPoint");

            migrationBuilder.DropColumn(
                name: "Density",
                table: "Map");

            migrationBuilder.DropColumn(
                name: "QuestLevel",
                table: "Map");

            migrationBuilder.AddColumn<int>(
                name: "Density",
                table: "TerrainOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "Terrain",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QuestLevel",
                table: "MapSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "InterestPoint",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QuestId",
                table: "InterestPoint",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terrain",
                table: "Terrain",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestPoint",
                table: "InterestPoint",
                column: "Id");

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
                columns: new[] { "MapHeight", "Name", "QuestLevel" },
                values: new object[] { 8, "7 точек: Тестовая", 1 });

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MapWidth", "Name", "QuestLevel" },
                values: new object[] { 8, "8 точек: Тестовая", 1 });

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "QuestLevel" },
                values: new object[] { "5 точек: Тестовая", 1 });

            migrationBuilder.UpdateData(
                table: "MapSchemes",
                keyColumn: "Id",
                keyValue: 5,
                column: "QuestLevel",
                value: 1);

            migrationBuilder.InsertData(
                table: "MapSchemes",
                columns: new[] { "Id", "GodPresense", "MapHeight", "MapWidth", "MaxDensityAvail", "Name", "NumbOfCities", "NumbOfResources", "NumbOfTreasuries", "QuestLevel" },
                values: new object[] { 6, 4, 8, 12, 2, "6-ТЕСТ!: 1 Город, 3 Ресурса, 2 Сокровищницы", 1, 3, 2, 1 });

            migrationBuilder.UpdateData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Density",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Density",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Density",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Density",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TerrainOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Density",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Terrain_MapId",
                table: "Terrain",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPoint_MapId",
                table: "InterestPoint",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPoint_QuestId",
                table: "InterestPoint",
                column: "QuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPoint_Map_MapId",
                table: "InterestPoint",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPoint_Quests_QuestId",
                table: "InterestPoint",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Terrain_Map_MapId",
                table: "Terrain",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id");
        }
    }
}
