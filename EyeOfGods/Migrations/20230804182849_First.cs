using Microsoft.EntityFrameworkCore.Migrations;

namespace EyeOfGods.Migrations
{
    public partial class First : Migration
    {
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
                    HalberdBonus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOrders", x => x.Id);
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
                    RangeWeaponsTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeWeapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RangeWeapons_RangeWeaponsTypes_RangeWeaponsTypeId",
                        column: x => x.RangeWeaponsTypeId,
                        principalTable: "RangeWeaponsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    RangeWeaponId = table.Column<int>(type: "int", nullable: true),
                    ShiedId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_EnduranceAbilities_EnduranceAbilitiesId",
                        column: x => x.EnduranceAbilitiesId,
                        principalTable: "EnduranceAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_MentalAbilities_MentalAbilitiesId",
                        column: x => x.MentalAbilitiesId,
                        principalTable: "MentalAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_RangeWeapons_RangeWeaponId",
                        column: x => x.RangeWeaponId,
                        principalTable: "RangeWeapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_Shields_ShiedId",
                        column: x => x.ShiedId,
                        principalTable: "Shields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, "Мечь", null, 2 },
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
                columns: new[] { "Id", "RWName", "RangeWeaponsTypeId" },
                values: new object[,]
                {
                    { 2, "Аркебуза", null },
                    { 3, "Пухандрий", null },
                    { 1, "Лук", null }
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
                columns: new[] { "Id", "DoubleWeaponsBonus", "GreatWeaponBonus", "HalberdBonus", "OneHandBonus", "OrderDescrption", "OrderName", "OrderType", "PikeBonus", "SituationBonus", "SpearBonus" },
                values: new object[,]
                {
                    { 1, "+4 к боеспособности", "-1 к броне противника", "-1 к броне противника", "+2 к боеспособности", "Совершите обычное движение от любой точки побежденного отряда", "Прорыв", "Атака", "0", "Если в эту фазу активаций отряд проводил чардж - отнимите 2 от брони противника", "0" },
                    { 2, "0", "-1 к броне противника", "+2 к боеспособности", "0", "Отойдите на 4\" от побежденного отряда", "Наскок", "Атака", "+4 к боеспособности", "Если в эту фазу активаций отряд проводил чардж - добавьте 1 к своей броне", "+2 к боеспособности" },
                    { 3, "0", "-1 к броне противника", "0", "0", "+2 брони каждому отряду, после этого отступающий отступает на свое движение. Противник может преследовать", "Отступление", "Оборона", "0", "Если ваша скорость выше, чем у противника - добавьте 1 к своей броне", "0" }
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "BarricadeAssault", "BarricadeForcedMove", "BarricadeGoThrough", "CliffAssault", "CliffForcedMove", "CliffGoThrough", "ForestAssault", "ForestForcedMove", "ForestGoThrough", "MaxSpeed", "MinSpeed", "SettelmentAssault", "SettelmentForcedMove", "SettelmentGoThrough", "SwampAssault", "SwampForcedMove", "SwampGoThrough", "UnitTypeName", "WaterAssault", "WaterForcedMove", "WaterGoThrough" },
                values: new object[,]
                {
                    { 1, "+2", "3", "2", "+2", "4", "2", "0", "1", "0", 8, 4, "0", "2", "0", "0", "1", "0", "Пехота", "+2", "3", "2" },
                    { 2, "+2", "3", "2", "Х", "6", "Х", "+2", "3", "2", 14, 8, "0", "2", "0", "+2", "3", "2", "Кавалерия", "+2", "3", "1" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "DefensiveAbilitiesId", "EnduranceAbilitiesId", "MentalAbilitiesId", "RangeWeaponId", "ShiedId", "Speed", "UnitName", "UnitTypeId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, 6, "Копейщик", null },
                    { 2, null, null, null, null, null, 6, "Алебардист", null },
                    { 3, null, null, null, null, null, 12, "Кавалерист", null }
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
                name: "IX_UnitOrderUnitType_UnitTypesId",
                table: "UnitOrderUnitType",
                column: "UnitTypesId");

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
                name: "IX_Units_ShiedId",
                table: "Units",
                column: "ShiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units",
                column: "UnitTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeleeWeapons");

            migrationBuilder.DropTable(
                name: "UnitOrderUnitType");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "UnitOrders");

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
