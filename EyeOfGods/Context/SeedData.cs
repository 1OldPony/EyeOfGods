using EyeOfGods.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace EyeOfGods.Context
{
    public class SeedData
    {
        public List<DefensiveAbilities> defensiveAbilities = new() {
            new() { Id = 1, CharacteristicName = "Броня", MinValue = 3, MaxValue = 6, NoDoubleActionAt = 5, Step = 1, BlocksArmorPierce = false },
            new() { Id = 2, CharacteristicName = "Материальность", MinValue = 3, MaxValue = 6, NoDoubleActionAt = 7, Step = 1, BlocksArmorPierce = true },
            new() { Id = 3, CharacteristicName = "Шкура", MinValue = 3, MaxValue = 5, NoDoubleActionAt = 5, Step = 1, BlocksArmorPierce = false }
        };

        public List<EnduranceAbilities> enduranceAbilities = new() {
                new EnduranceAbilities { Id = 1, CharacteristicName = "Выносливость", MinValue = 4, MaxValue = 16, Step = 2 },
                new EnduranceAbilities { Id = 2, CharacteristicName = "Целостность", MinValue = 4, MaxValue = 16, Step = 2 }
        };

        public List<MentalAbilities> mentalAbilities = new() {
                new MentalAbilities { Id = 1, CharacteristicName = "Отвага", MinValue = 2, MaxValue = 6, Step = 2 },
                new MentalAbilities { Id = 2, CharacteristicName = "Ярость", MinValue = 1, MaxValue = 3, Step = 1 }
        };

        public List<MeleeWeapon> meleeWeapon = new() {
                new MeleeWeapon { Id = 1, MWName = "Меч", WeaponType = MeleeWeaponTypes.Одноручное},
                new MeleeWeapon { Id = 2, MWName = "Пика", WeaponType = MeleeWeaponTypes.Пика },
                new MeleeWeapon { Id = 3, MWName = "Алебарда", WeaponType = MeleeWeaponTypes.Алебарда }
        };

        public List<RangeWeapon> rangeWeapon = new() {
                new RangeWeapon { Id = 1, RWName = "Лук", RangeOfShooting = 12},
                new RangeWeapon { Id = 2, RWName = "Аркебуза", RangeOfShooting = 18},
                new RangeWeapon { Id = 3, RWName = "Пухандрий", RangeOfShooting = 18 }
        };

        public List<RangeWeaponsType> rangeWeaponsType = new() {
                new RangeWeaponsType{Id = 1,RWTypeName = "Легкое стрелковое вооружение",MinDistance = 8,MaxDistance = 14,DistanceStep = 2,
                    FirstRWTypeProperty = "Стреляет без лоса",SecondRWTypeProperty = ""},
                new RangeWeaponsType{Id = 2,RWTypeName = "Тяжелое стрелковое вооружение",MinDistance = 14,MaxDistance = 20,DistanceStep = 2,
                    FirstRWTypeProperty = "-2 к броне",SecondRWTypeProperty = "Только прямая стрельба"},
                new RangeWeaponsType{Id = 3,RWTypeName = "Артиллерийское вооружение",MinDistance = 24,MaxDistance = 30,DistanceStep = 2,
                    FirstRWTypeProperty = "Всегда 4+",SecondRWTypeProperty = "Каждый успех-усталость"}
        };

        public List<Shield> shield = new() {
                new Shield { Id=1, ShieldName = "Баклер"}
        };

        public List<UnitType> unitType = new() {
                new UnitType { Id = 1, UnitTypeName = "Пехота", BarricadeAssault="+2", BarricadeForcedMove="3", BarricadeGoThrough="2",
                 CliffAssault="+2", CliffForcedMove="4", CliffGoThrough="2", ForestAssault="0", ForestForcedMove="1", ForestGoThrough="0",
                 SettelmentAssault="0", SettelmentForcedMove="2", SettelmentGoThrough="0", SwampAssault="0", SwampForcedMove="1", SwampGoThrough="0",
                 WaterAssault="+2", WaterForcedMove="3", WaterGoThrough="2", MinSpeed = 4, MaxSpeed = 8 },
                new UnitType { Id = 2, UnitTypeName = "Кавалерия", BarricadeAssault="+2", BarricadeForcedMove="3", BarricadeGoThrough="2",
                 CliffAssault="Х", CliffForcedMove="6", CliffGoThrough="Х", ForestAssault="+2", ForestForcedMove="3", ForestGoThrough="2",
                 SettelmentAssault="0", SettelmentForcedMove="2", SettelmentGoThrough="0", SwampAssault="+2", SwampForcedMove="3", SwampGoThrough="2",
                 WaterAssault="+2", WaterForcedMove="3", WaterGoThrough="1", MinSpeed = 8, MaxSpeed = 14 }
        };

        public List<UnitOrder> unitOrder = new() {
                new UnitOrder { Id = 1, OrderName = "Прорыв", OrderType = "Атака", OrderDescrption = "Совершите обычное движение от любой точки побежденного отряда",
                    SituationBonus = "Если в эту фазу активаций отряд проводил чардж - отнимите 2 от брони противника", DoubleWeaponsBonus = "+4 к боеспособности",
                    GreatWeaponBonus = "-1 к броне противника", HalberdBonus = "-1 к броне противника", OneHandBonus = "+2 к боеспособности", PikeBonus = "0",
                    SpearBonus = "0"},
                new UnitOrder { Id = 2, OrderName = "Наскок", OrderType = "Атака", OrderDescrption = "Отойдите на 4\" от побежденного отряда",
                    SituationBonus = "Если в эту фазу активаций отряд проводил чардж - добавьте 1 к своей броне", DoubleWeaponsBonus = "0",
                    GreatWeaponBonus = "-1 к броне противника", HalberdBonus = "+2 к боеспособности", OneHandBonus = "0",PikeBonus = "+4 к боеспособности",
                    SpearBonus = "+2 к боеспособности"
                },
                new UnitOrder { Id = 3, OrderName = "Отступление", OrderType = "Оборона", OrderDescrption = "+2 брони каждому отряду, после этого отступающий отступает на свое движение. Противник может преследовать",
                    SituationBonus = "Если ваша скорость выше, чем у противника - добавьте 1 к своей броне", DoubleWeaponsBonus = "0", GreatWeaponBonus = "-1 к броне противника",
                    HalberdBonus = "0", OneHandBonus = "0", PikeBonus = "0", SpearBonus = "0" }
        };
    }
}
