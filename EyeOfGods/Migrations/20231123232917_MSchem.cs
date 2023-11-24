using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class MSchem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MapSchemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumbOfCities = table.Column<int>(type: "int", nullable: false),
                    NumbOfResources = table.Column<int>(type: "int", nullable: false),
                    NumbOfTreasuries = table.Column<int>(type: "int", nullable: false),
                    MapHeight = table.Column<int>(type: "int", nullable: false),
                    MapWidth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapSchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsWin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsDraw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsLoose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchemeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Map_MapSchemes_SchemeId",
                        column: x => x.SchemeId,
                        principalTable: "MapSchemes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MapSchemePoint",
                columns: table => new
                {
                    MapSchemeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointNumber = table.Column<int>(type: "int", nullable: false),
                    PointHeight = table.Column<int>(type: "int", nullable: false),
                    PointWidth = table.Column<int>(type: "int", nullable: false),
                    XCoordinate = table.Column<int>(type: "int", nullable: false),
                    YCoordinate = table.Column<int>(type: "int", nullable: false),
                    PareWhithPoint = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapSchemePoint", x => new { x.MapSchemeId, x.Id });
                    table.ForeignKey(
                        name: "FK_MapSchemePoint_MapSchemes_MapSchemeId",
                        column: x => x.MapSchemeId,
                        principalTable: "MapSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestId = table.Column<int>(type: "int", nullable: true),
                    MapId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterestPoint_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InterestPoint_Quest_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Terrain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GodToken = table.Column<bool>(type: "bit", nullable: false),
                    MapId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terrain_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestPoint_MapId",
                table: "InterestPoint",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPoint_QuestId",
                table: "InterestPoint",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Map_SchemeId",
                table: "Map",
                column: "SchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Terrain_MapId",
                table: "Terrain",
                column: "MapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestPoint");

            migrationBuilder.DropTable(
                name: "MapSchemePoint");

            migrationBuilder.DropTable(
                name: "Terrain");

            migrationBuilder.DropTable(
                name: "Quest");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "MapSchemes");
        }
    }
}
