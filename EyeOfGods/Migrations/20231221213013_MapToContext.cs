using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class MapToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestPoint_Map_MapId",
                table: "InterestPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_Map_MapSchemes_SchemeId",
                table: "Map");

            migrationBuilder.DropForeignKey(
                name: "FK_Map_TerrainOptions_TerrainOptionsId",
                table: "Map");

            migrationBuilder.DropForeignKey(
                name: "FK_Terrain_Map_MapId",
                table: "Terrain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Map",
                table: "Map");

            migrationBuilder.RenameTable(
                name: "Map",
                newName: "Maps");

            migrationBuilder.RenameIndex(
                name: "IX_Map_TerrainOptionsId",
                table: "Maps",
                newName: "IX_Maps_TerrainOptionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Map_SchemeId",
                table: "Maps",
                newName: "IX_Maps_SchemeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maps",
                table: "Maps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPoint_Maps_MapId",
                table: "InterestPoint",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_MapSchemes_SchemeId",
                table: "Maps",
                column: "SchemeId",
                principalTable: "MapSchemes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_TerrainOptions_TerrainOptionsId",
                table: "Maps",
                column: "TerrainOptionsId",
                principalTable: "TerrainOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Terrain_Maps_MapId",
                table: "Terrain",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestPoint_Maps_MapId",
                table: "InterestPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_MapSchemes_SchemeId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_TerrainOptions_TerrainOptionsId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Terrain_Maps_MapId",
                table: "Terrain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maps",
                table: "Maps");

            migrationBuilder.RenameTable(
                name: "Maps",
                newName: "Map");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_TerrainOptionsId",
                table: "Map",
                newName: "IX_Map_TerrainOptionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_SchemeId",
                table: "Map",
                newName: "IX_Map_SchemeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Map",
                table: "Map",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPoint_Map_MapId",
                table: "InterestPoint",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Map_MapSchemes_SchemeId",
                table: "Map",
                column: "SchemeId",
                principalTable: "MapSchemes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Map_TerrainOptions_TerrainOptionsId",
                table: "Map",
                column: "TerrainOptionsId",
                principalTable: "TerrainOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Terrain_Map_MapId",
                table: "Terrain",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
