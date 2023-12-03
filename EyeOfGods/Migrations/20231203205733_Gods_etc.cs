using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class Gods_etc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GodToken",
                table: "Terrain",
                newName: "HasGodToken");

            migrationBuilder.AddColumn<bool>(
                name: "GodFrendly",
                table: "Terrain",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GodPresense",
                table: "MapSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gods",
                columns: table => new
                {
                    GodName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FighterAbilityDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MageAbilityDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimateAbilityDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gods", x => x.GodName);
                });

            migrationBuilder.InsertData(
                table: "Gods",
                columns: new[] { "GodName", "Description", "FighterAbilityDesc", "MageAbilityDesc", "UltimateAbilityDesc" },
                values: new object[,]
                {
                    { "Время", null, null, null, null },
                    { "Доблесть", null, null, null, null },
                    { "Знания", null, null, null, null },
                    { "Справедливость", null, null, null, null },
                    { "Шутник", null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gods");

            migrationBuilder.DropColumn(
                name: "GodFrendly",
                table: "Terrain");

            migrationBuilder.DropColumn(
                name: "GodPresense",
                table: "MapSchemes");

            migrationBuilder.RenameColumn(
                name: "HasGodToken",
                table: "Terrain",
                newName: "GodToken");
        }
    }
}
