using Microsoft.EntityFrameworkCore.Migrations;

namespace EyeOfGods.Migrations
{
    public partial class newCharsToUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RangeWeapons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RangeWeapons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RangeWeapons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "Defense",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Endurance",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mental",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RangeOfShooting",
                table: "RangeWeapons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Endurance",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Mental",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "RangeOfShooting",
                table: "RangeWeapons");

            migrationBuilder.InsertData(
                table: "RangeWeapons",
                columns: new[] { "Id", "RWName", "RangeWeaponsTypeId" },
                values: new object[,]
                {
                    { 1, "Лук", null },
                    { 2, "Аркебуза", null },
                    { 3, "Пухандрий", null }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "DefensiveAbilitiesId", "EnduranceAbilitiesId", "MentalAbilitiesId", "RangeWeaponId", "ShieldId", "Speed", "UnitName", "UnitTypeId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, 6, "Копейщик", null },
                    { 2, null, null, null, null, null, 6, "Алебардист", null },
                    { 3, null, null, null, null, null, 12, "Кавалерист", null }
                });
        }
    }
}
