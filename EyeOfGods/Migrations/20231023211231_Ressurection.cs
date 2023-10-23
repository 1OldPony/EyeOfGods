using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class Ressurection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefensiveAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacteristicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinValue = table.Column<int>(type: "int", nullable: false),
                    MaxValue = table.Column<int>(type: "int", nullable: false),
                    NoDoubleActionAt = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<int>(type: "int", nullable: false),
                    DefenseAddProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlocksArmorPierce = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefensiveAbilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnduranceAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacteristicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinValue = table.Column<int>(type: "int", nullable: false),
                    MaxValue = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<int>(type: "int", nullable: false),
                    DurabilityAddProperty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnduranceAbilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MentalAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacteristicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinValue = table.Column<int>(type: "int", nullable: false),
                    MaxValue = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<int>(type: "int", nullable: false),
                    SpiritAddProperty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentalAbilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeWeaponsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RWTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinDistance = table.Column<int>(type: "int", nullable: false),
                    MaxDistance = table.Column<int>(type: "int", nullable: false),
                    DistanceStep = table.Column<int>(type: "int", nullable: false),
                    FirstRWTypeProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondRWTypeProperty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeWeaponsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShieldName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinSpeed = table.Column<int>(type: "int", nullable: false),
                    MaxSpeed = table.Column<int>(type: "int", nullable: false),
                    ForestGoThrough = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForestForcedMove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForestAssault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwampGoThrough = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwampForcedMove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwampAssault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterGoThrough = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterForcedMove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterAssault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettelmentGoThrough = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettelmentForcedMove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettelmentAssault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CliffGoThrough = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CliffForcedMove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CliffAssault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarricadeGoThrough = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarricadeForcedMove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarricadeAssault = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeWeapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeOfShooting = table.Column<int>(type: "int", nullable: false),
                    RangeWeaponsTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeWeapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RangeWeapons_RangeWeaponsTypes_RangeWeaponsTypeId",
                        column: x => x.RangeWeaponsTypeId,
                        principalTable: "RangeWeaponsTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnitOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDescrption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituationBonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpearBonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PikeBonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OneHandBonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoubleWeaponsBonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GreatWeaponBonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HalberdBonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitOrders_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Endurance = table.Column<int>(type: "int", nullable: false),
                    Mental = table.Column<int>(type: "int", nullable: false),
                    RangeWeaponId = table.Column<int>(type: "int", nullable: true),
                    ShieldId = table.Column<int>(type: "int", nullable: true),
                    DefensiveAbilitiesId = table.Column<int>(type: "int", nullable: true),
                    EnduranceAbilitiesId = table.Column<int>(type: "int", nullable: true),
                    MentalAbilitiesId = table.Column<int>(type: "int", nullable: true),
                    UnitTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_DefensiveAbilities_DefensiveAbilitiesId",
                        column: x => x.DefensiveAbilitiesId,
                        principalTable: "DefensiveAbilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_EnduranceAbilities_EnduranceAbilitiesId",
                        column: x => x.EnduranceAbilitiesId,
                        principalTable: "EnduranceAbilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_MentalAbilities_MentalAbilitiesId",
                        column: x => x.MentalAbilitiesId,
                        principalTable: "MentalAbilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_RangeWeapons_RangeWeaponId",
                        column: x => x.RangeWeaponId,
                        principalTable: "RangeWeapons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_Shields_ShieldId",
                        column: x => x.ShieldId,
                        principalTable: "Shields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeleeWeapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeaponType = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeleeWeapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeleeWeapons_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DefensiveAbilities",
                columns: new[] { "Id", "BlocksArmorPierce", "CharacteristicName", "DefenseAddProperty", "MaxValue", "MinValue", "NoDoubleActionAt", "Step" },
                values: new object[,]
                {
                    { 1, false, "Броня", "Дополнительное свойство", 6, 3, 5, 1 },
                    { 2, true, "Материальность", "Дополнительное свойство", 6, 3, 7, 1 },
                    { 3, false, "Шкура", "Дополнительное свойство", 5, 3, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "EnduranceAbilities",
                columns: new[] { "Id", "CharacteristicName", "DurabilityAddProperty", "MaxValue", "MinValue", "Step" },
                values: new object[,]
                {
                    { 1, "Выносливость", "Дополнительное свойство", 16, 4, 2 },
                    { 2, "Целостность", "Дополнительное свойство", 16, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "MeleeWeapons",
                columns: new[] { "Id", "MWName", "UnitId", "WeaponType" },
                values: new object[,]
                {
                    { 1, "Меч", null, 2 },
                    { 2, "Пика", null, 1 },
                    { 3, "Алебарда", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "MentalAbilities",
                columns: new[] { "Id", "CharacteristicName", "MaxValue", "MinValue", "SpiritAddProperty", "Step" },
                values: new object[,]
                {
                    { 1, "Отвага", 6, 2, "Дополнительное свойство", 2 },
                    { 2, "Ярость", 3, 1, "Дополнительное свойство", 1 }
                });

            migrationBuilder.InsertData(
                table: "RangeWeapons",
                columns: new[] { "Id", "RWName", "RangeOfShooting", "RangeWeaponsTypeId" },
                values: new object[,]
                {
                    { 1, "Лук", 12, null },
                    { 2, "Аркебуза", 18, null },
                    { 3, "Пухандрий", 18, null }
                });

            migrationBuilder.InsertData(
                table: "RangeWeaponsTypes",
                columns: new[] { "Id", "DistanceStep", "FirstRWTypeProperty", "MaxDistance", "MinDistance", "RWTypeName", "SecondRWTypeProperty" },
                values: new object[,]
                {
                    { 1, 2, "Стреляет без лоса", 14, 8, "Легкое стрелковое вооружение", "" },
                    { 2, 2, "-2 к броне", 20, 14, "Тяжелое стрелковое вооружение", "Только прямая стрельба" },
                    { 3, 2, "Всегда 4+", 30, 24, "Артиллерийское вооружение", "Каждый успех-усталость" }
                });

            migrationBuilder.InsertData(
                table: "Shields",
                columns: new[] { "Id", "ShieldName" },
                values: new object[] { 1, "Баклер" });

            migrationBuilder.InsertData(
                table: "UnitOrders",
                columns: new[] { "Id", "DoubleWeaponsBonus", "GreatWeaponBonus", "HalberdBonus", "OneHandBonus", "OrderDescrption", "OrderName", "OrderType", "PikeBonus", "SituationBonus", "SpearBonus", "UnitTypeId" },
                values: new object[,]
                {
                    { 1, "+4 к боеспособности", "-1 к броне противника", "-1 к броне противника", "+2 к боеспособности", "Совершите обычное движение от любой точки побежденного отряда", "Прорыв", "Атака", "0", "Если в эту фазу активаций отряд проводил чардж - отнимите 2 от брони противника", "0", null },
                    { 2, "0", "-1 к броне противника", "+2 к боеспособности", "0", "Отойдите на 4\" от побежденного отряда", "Наскок", "Атака", "+4 к боеспособности", "Если в эту фазу активаций отряд проводил чардж - добавьте 1 к своей броне", "+2 к боеспособности", null },
                    { 3, "0", "-1 к броне противника", "0", "0", "+2 брони каждому отряду, после этого отступающий отступает на свое движение. Противник может преследовать", "Отступление", "Оборона", "0", "Если ваша скорость выше, чем у противника - добавьте 1 к своей броне", "0", null }
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "BarricadeAssault", "BarricadeForcedMove", "BarricadeGoThrough", "CliffAssault", "CliffForcedMove", "CliffGoThrough", "ForestAssault", "ForestForcedMove", "ForestGoThrough", "MaxSpeed", "MinSpeed", "SettelmentAssault", "SettelmentForcedMove", "SettelmentGoThrough", "SwampAssault", "SwampForcedMove", "SwampGoThrough", "UnitTypeName", "WaterAssault", "WaterForcedMove", "WaterGoThrough" },
                values: new object[,]
                {
                    { 1, "+2", "3", "2", "+2", "4", "2", "0", "1", "0", 8, 4, "0", "2", "0", "0", "1", "0", "Пехота", "+2", "3", "2" },
                    { 2, "+2", "3", "2", "Х", "6", "Х", "+2", "3", "2", 14, 8, "0", "2", "0", "+2", "3", "2", "Кавалерия", "+2", "3", "1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeleeWeapons_UnitId",
                table: "MeleeWeapons",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RangeWeapons_RangeWeaponsTypeId",
                table: "RangeWeapons",
                column: "RangeWeaponsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOrders_UnitTypeId",
                table: "UnitOrders",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_DefensiveAbilitiesId",
                table: "Units",
                column: "DefensiveAbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_EnduranceAbilitiesId",
                table: "Units",
                column: "EnduranceAbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_MentalAbilitiesId",
                table: "Units",
                column: "MentalAbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_RangeWeaponId",
                table: "Units",
                column: "RangeWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ShieldId",
                table: "Units",
                column: "ShieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units",
                column: "UnitTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeleeWeapons");

            migrationBuilder.DropTable(
                name: "UnitOrders");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "DefensiveAbilities");

            migrationBuilder.DropTable(
                name: "EnduranceAbilities");

            migrationBuilder.DropTable(
                name: "MentalAbilities");

            migrationBuilder.DropTable(
                name: "RangeWeapons");

            migrationBuilder.DropTable(
                name: "Shields");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropTable(
                name: "RangeWeaponsTypes");
        }
    }
}
