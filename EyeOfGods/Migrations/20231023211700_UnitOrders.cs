using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class UnitOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitOrders_UnitTypes_UnitTypeId",
                table: "UnitOrders");

            migrationBuilder.DropIndex(
                name: "IX_UnitOrders_UnitTypeId",
                table: "UnitOrders");

            migrationBuilder.DropColumn(
                name: "UnitTypeId",
                table: "UnitOrders");

            migrationBuilder.CreateTable(
                name: "UnitOrderUnitType",
                columns: table => new
                {
                    UnitTypeOrdersId = table.Column<int>(type: "int", nullable: false),
                    UnitTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOrderUnitType", x => new { x.UnitTypeOrdersId, x.UnitTypesId });
                    table.ForeignKey(
                        name: "FK_UnitOrderUnitType_UnitOrders_UnitTypeOrdersId",
                        column: x => x.UnitTypeOrdersId,
                        principalTable: "UnitOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOrderUnitType_UnitTypes_UnitTypesId",
                        column: x => x.UnitTypesId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitOrderUnitType_UnitTypesId",
                table: "UnitOrderUnitType",
                column: "UnitTypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitOrderUnitType");

            migrationBuilder.AddColumn<int>(
                name: "UnitTypeId",
                table: "UnitOrders",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UnitOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnitTypeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "UnitOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnitTypeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "UnitOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "UnitTypeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_UnitOrders_UnitTypeId",
                table: "UnitOrders",
                column: "UnitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOrders_UnitTypes_UnitTypeId",
                table: "UnitOrders",
                column: "UnitTypeId",
                principalTable: "UnitTypes",
                principalColumn: "Id");
        }
    }
}
