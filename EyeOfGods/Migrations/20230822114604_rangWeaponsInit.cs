using Microsoft.EntityFrameworkCore.Migrations;

namespace EyeOfGods.Migrations
{
    public partial class rangWeaponsInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RangeWeapons",
                columns: new[] { "Id", "RWName", "RangeOfShooting", "RangeWeaponsTypeId" },
                values: new object[] { 1, "Лук", 0, null });

            migrationBuilder.InsertData(
                table: "RangeWeapons",
                columns: new[] { "Id", "RWName", "RangeOfShooting", "RangeWeaponsTypeId" },
                values: new object[] { 2, "Аркебуза", 0, null });

            migrationBuilder.InsertData(
                table: "RangeWeapons",
                columns: new[] { "Id", "RWName", "RangeOfShooting", "RangeWeaponsTypeId" },
                values: new object[] { 3, "Пухандрий", 0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
