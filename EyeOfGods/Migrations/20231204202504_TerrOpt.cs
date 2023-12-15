using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class TerrOpt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Map",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TerrainOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionsSetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    density = table.Column<int>(type: "int", nullable: false),
                    ForestDensity = table.Column<int>(type: "int", nullable: false),
                    SwampDensity = table.Column<int>(type: "int", nullable: false),
                    WaterDensity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerrainOptions", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "TerrainOptions",
                columns: new[] { "Id", "ForestDensity", "OptionsSetName", "SwampDensity", "WaterDensity", "density" },
                values: new object[] { 1, 33, "Тестовая", 33, 33, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_MapSchemeTerrainOptions_TerrainOptionsId",
                table: "MapSchemeTerrainOptions",
                column: "TerrainOptionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapSchemeTerrainOptions");

            migrationBuilder.DropTable(
                name: "TerrainOptions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Map");
        }
    }
}
