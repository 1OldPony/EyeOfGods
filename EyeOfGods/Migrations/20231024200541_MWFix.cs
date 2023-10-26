using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class MWFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeleeWeapons_Units_UnitId",
                table: "MeleeWeapons");

            migrationBuilder.DropIndex(
                name: "IX_MeleeWeapons_UnitId",
                table: "MeleeWeapons");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "MeleeWeapons");

            migrationBuilder.CreateTable(
                name: "MeleeWeaponUnit",
                columns: table => new
                {
                    MeleeWeaponsId = table.Column<int>(type: "int", nullable: false),
                    UnitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeleeWeaponUnit", x => new { x.MeleeWeaponsId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_MeleeWeaponUnit_MeleeWeapons_MeleeWeaponsId",
                        column: x => x.MeleeWeaponsId,
                        principalTable: "MeleeWeapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeleeWeaponUnit_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeleeWeaponUnit_UnitsId",
                table: "MeleeWeaponUnit",
                column: "UnitsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeleeWeaponUnit");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "MeleeWeapons",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MeleeWeapons",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnitId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MeleeWeapons",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnitId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MeleeWeapons",
                keyColumn: "Id",
                keyValue: 3,
                column: "UnitId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_MeleeWeapons_UnitId",
                table: "MeleeWeapons",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeleeWeapons_Units_UnitId",
                table: "MeleeWeapons",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
