using EyeOfGods.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace NUnitTests.FakeDb
{
    public static class Db_Moq
    {
        public interface IContext
        {
            public abstract DbSet<DefensiveAbilities> DefensiveAbilities { get; set; }
            public abstract DbSet<EnduranceAbilities> EnduranceAbilities { get; set; }
            public abstract DbSet<MentalAbilities> MentalAbilities { get; set; }
            public abstract DbSet<MeleeWeapon> MeleeWeapons { get; set; }
            public abstract DbSet<RangeWeapon> RangeWeapons { get; set; }
            public abstract DbSet<RangeWeaponsType> RangeWeaponsTypes { get; set; }
            public abstract DbSet<Shield> Shields { get; set; }
            public abstract DbSet<Unit> Units { get; set; }
            public abstract DbSet<UnitOrder> UnitOrders { get; set; }
            public abstract DbSet<UnitType> UnitTypes { get; set; }
        }
        public static Mock<IContext> Context()
        {
            //var mockContext = new Mock<MyWargameContext>();
            var mockContext = new Mock<IContext>();
            mockContext.Setup(m => m.DefensiveAbilities).Returns(DefensiveAbilitiesList().Object);
            mockContext.Setup(m => m.EnduranceAbilities).Returns(EnduranceAbilitiesList().Object);
            mockContext.Setup(m => m.MentalAbilities).Returns(MentalAbilitiesList().Object);
            mockContext.Setup(m => m.MeleeWeapons).Returns(MeleeWeaponsList().Object);
            mockContext.Setup(m => m.RangeWeapons).Returns(RangeWeaponsList().Object);
            mockContext.Setup(m => m.RangeWeaponsTypes).Returns(RangeWeaponsTypeList().Object);
            mockContext.Setup(m => m.Shields).Returns(ShieldsList().Object);
            mockContext.Setup(m => m.UnitOrders).Returns(UnitOrdersList().Object);
            mockContext.Setup(m => m.UnitTypes).Returns(UnitTypesList().Object);
            mockContext.Setup(m => m.Units).Returns(UnitsList().Object);

            return mockContext;
        }

        public static Mock<DbSet<Unit>> UnitsList()
        {
            var data = new List<Unit>
            {
                new Unit
                {
                    Id = 1, DefensiveAbilities = DefensiveAbilitiesList().Object.ElementAt(0), EnduranceAbilities = EnduranceAbilitiesList().Object.ElementAt(0),
                    MentalAbilities = MentalAbilitiesList().Object.ElementAt(1), MeleeWeapons = {MeleeWeaponsList().Object.ElementAt(2)}, UnitType = UnitTypesList().Object.ElementAt(0),
                    UnitName = "Test_Halberdier_NoShield_NoRange_NoFuture", Speed = 8, Defense = 4, Endurance = 8, Mental = 2
                }
            }.AsQueryable();


            var unitsList = new Mock<DbSet<Unit>>();
            unitsList.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(data.Provider);
            unitsList.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(data.Expression);
            unitsList.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(data.ElementType);
            unitsList.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return unitsList;
        }

        public static Mock<DbSet<DefensiveAbilities>> DefensiveAbilitiesList()
        {
            var data = new List<DefensiveAbilities>
            {
                new DefensiveAbilities { Id = 1, CharacteristicName = "Броня", MinValue = 3, MaxValue = 6, NoDoubleActionAt = 5, Step = 1, BlocksArmorPierce = false },
                new DefensiveAbilities { Id = 2, CharacteristicName = "Материальность", MinValue = 3, MaxValue = 6, NoDoubleActionAt = 7, Step = 1, BlocksArmorPierce = true },
                new DefensiveAbilities { Id = 3, CharacteristicName = "Шкура", MinValue = 3, MaxValue = 5, NoDoubleActionAt = 5, Step = 1, BlocksArmorPierce = false }
            }.AsQueryable();

            var defensiveAbilities = new Mock<DbSet<DefensiveAbilities>>();
            defensiveAbilities.As<IQueryable<DefensiveAbilities>>().Setup(m => m.Provider).Returns(data.Provider);
            defensiveAbilities.As<IQueryable<DefensiveAbilities>>().Setup(m => m.Expression).Returns(data.Expression);
            defensiveAbilities.As<IQueryable<DefensiveAbilities>>().Setup(m => m.ElementType).Returns(data.ElementType);
            defensiveAbilities.As<IQueryable<DefensiveAbilities>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return defensiveAbilities;
        }
        public static Mock<DbSet<EnduranceAbilities>> EnduranceAbilitiesList()
        {
            var data = new List<EnduranceAbilities>
            {
                new EnduranceAbilities { Id = 1, CharacteristicName = "Выносливость", MinValue = 4, MaxValue = 16, Step = 2 },
                new EnduranceAbilities { Id = 2, CharacteristicName = "Целостность", MinValue = 4, MaxValue = 16, Step = 2 }
            }.AsQueryable();

            var enduranceAbilities = new Mock<DbSet<EnduranceAbilities>>();
            enduranceAbilities.As<IQueryable<EnduranceAbilities>>().Setup(m => m.Provider).Returns(data.Provider);
            enduranceAbilities.As<IQueryable<EnduranceAbilities>>().Setup(m => m.Expression).Returns(data.Expression);
            enduranceAbilities.As<IQueryable<EnduranceAbilities>>().Setup(m => m.ElementType).Returns(data.ElementType);
            enduranceAbilities.As<IQueryable<EnduranceAbilities>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return enduranceAbilities;
        }
        public static Mock<DbSet<MentalAbilities>> MentalAbilitiesList()
        {
            var data = new List<MentalAbilities>
            {
                new MentalAbilities { Id = 1, CharacteristicName = "Отвага", MinValue = 2, MaxValue = 6, Step = 2 },
                new MentalAbilities { Id = 2, CharacteristicName = "Ярость", MinValue = 1, MaxValue = 3, Step = 1 }
            }.AsQueryable();

            var mentalAbilities = new Mock<DbSet<MentalAbilities>>();
            mentalAbilities.As<IQueryable<MentalAbilities>>().Setup(m => m.Provider).Returns(data.Provider);
            mentalAbilities.As<IQueryable<MentalAbilities>>().Setup(m => m.Expression).Returns(data.Expression);
            mentalAbilities.As<IQueryable<MentalAbilities>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mentalAbilities.As<IQueryable<MentalAbilities>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mentalAbilities;
        }
        public static Mock<DbSet<MeleeWeapon>> MeleeWeaponsList()
        {
            var data = new List<MeleeWeapon>
            {
                new MeleeWeapon { Id = 1, MWName = "Меч", WeaponType = MeleeWeaponTypes.Одноручное},
                new MeleeWeapon { Id = 2, MWName = "Пика", WeaponType = MeleeWeaponTypes.Пика },
                new MeleeWeapon { Id = 3, MWName = "Алебарда", WeaponType = MeleeWeaponTypes.Алебарда }
            }.AsQueryable();

            var meleeWeapons = new Mock<DbSet<MeleeWeapon>>();
            meleeWeapons.As<IQueryable<MeleeWeapon>>().Setup(m => m.Provider).Returns(data.Provider);
            meleeWeapons.As<IQueryable<MeleeWeapon>>().Setup(m => m.Expression).Returns(data.Expression);
            meleeWeapons.As<IQueryable<MeleeWeapon>>().Setup(m => m.ElementType).Returns(data.ElementType);
            meleeWeapons.As<IQueryable<MeleeWeapon>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return meleeWeapons;
        }
        public static Mock<DbSet<RangeWeapon>> RangeWeaponsList()
        {
            var data = new List<RangeWeapon>
            {
                new RangeWeapon { Id = 1, RWName = "Лук", RangeWeaponsType = RangeWeaponsTypeList().Object.ElementAt(0) },
                new RangeWeapon { Id = 2, RWName = "Аркебуза", RangeWeaponsType = RangeWeaponsTypeList().Object.ElementAt(1) },
                new RangeWeapon { Id = 3, RWName = "Пухандрий", RangeWeaponsType = RangeWeaponsTypeList().Object.ElementAt(2) }
            }.AsQueryable();

            var rangeWeapons = new Mock<DbSet<RangeWeapon>>();
            rangeWeapons.As<IQueryable<RangeWeapon>>().Setup(m => m.Provider).Returns(data.Provider);
            rangeWeapons.As<IQueryable<RangeWeapon>>().Setup(m => m.Expression).Returns(data.Expression);
            rangeWeapons.As<IQueryable<RangeWeapon>>().Setup(m => m.ElementType).Returns(data.ElementType);
            rangeWeapons.As<IQueryable<RangeWeapon>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());



            return rangeWeapons;
        }
        public static Mock<DbSet<RangeWeaponsType>> RangeWeaponsTypeList()
        {
            var data = new List<RangeWeaponsType>
            {
                new RangeWeaponsType{Id = 1,RWTypeName = "Легкое стрелковое вооружение",MinDistance = 8,MaxDistance = 14,DistanceStep = 2,
                    FirstRWTypeProperty = "Стреляет без лоса",SecondRWTypeProperty = ""},
                new RangeWeaponsType{Id = 2,RWTypeName = "Тяжелое стрелковое вооружение",MinDistance = 14,MaxDistance = 20,DistanceStep = 2,
                    FirstRWTypeProperty = "-2 к броне",SecondRWTypeProperty = "Только прямая стрельба"},
                new RangeWeaponsType{Id = 3,RWTypeName = "Артиллерийское вооружение",MinDistance = 24,MaxDistance = 30,DistanceStep = 2,
                    FirstRWTypeProperty = "Всегда 4+",SecondRWTypeProperty = "Каждый успех-усталость"}
            }.AsQueryable();

            var rangeWeaponsType = new Mock<DbSet<RangeWeaponsType>>();
            rangeWeaponsType.As<IQueryable<RangeWeaponsType>>().Setup(m => m.Provider).Returns(data.Provider);
            rangeWeaponsType.As<IQueryable<RangeWeaponsType>>().Setup(m => m.Expression).Returns(data.Expression);
            rangeWeaponsType.As<IQueryable<RangeWeaponsType>>().Setup(m => m.ElementType).Returns(data.ElementType);
            rangeWeaponsType.As<IQueryable<RangeWeaponsType>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return rangeWeaponsType;
        }
        public static Mock<DbSet<Shield>> ShieldsList()
        {
            var data = new List<Shield>
            {
                new Shield { Id=1, ShieldName = "Баклер"}
            }.AsQueryable();

            var shields = new Mock<DbSet<Shield>>();
            shields.As<IQueryable<Shield>>().Setup(m => m.Provider).Returns(data.Provider);
            shields.As<IQueryable<Shield>>().Setup(m => m.Expression).Returns(data.Expression);
            shields.As<IQueryable<Shield>>().Setup(m => m.ElementType).Returns(data.ElementType);
            shields.As<IQueryable<Shield>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return shields;
        }
        public static Mock<DbSet<UnitType>> UnitTypesList()
        {
            var data = new List<UnitType>
            {
                new UnitType { Id = 1, UnitTypeName = "Пехота", BarricadeAssault="+2", BarricadeForcedMove="3", BarricadeGoThrough="2",
                 CliffAssault="+2", CliffForcedMove="4", CliffGoThrough="2", ForestAssault="0", ForestForcedMove="1", ForestGoThrough="0",
                 SettelmentAssault="0", SettelmentForcedMove="2", SettelmentGoThrough="0", SwampAssault="0", SwampForcedMove="1", SwampGoThrough="0",
                 WaterAssault="+2", WaterForcedMove="3", WaterGoThrough="2", MinSpeed = 4, MaxSpeed = 8, UnitTypeOrders = { UnitOrdersList().Object.ElementAt(2) } },
                new UnitType { Id = 2, UnitTypeName = "Кавалерия", BarricadeAssault="+2", BarricadeForcedMove="3", BarricadeGoThrough="2",
                 CliffAssault="Х", CliffForcedMove="6", CliffGoThrough="Х", ForestAssault="+2", ForestForcedMove="3", ForestGoThrough="2",
                 SettelmentAssault="0", SettelmentForcedMove="2", SettelmentGoThrough="0", SwampAssault="+2", SwampForcedMove="3", SwampGoThrough="2",
                 WaterAssault="+2", WaterForcedMove="3", WaterGoThrough="1", MinSpeed = 8, MaxSpeed = 14, UnitTypeOrders = { UnitOrdersList().Object.ElementAt(0), UnitOrdersList().Object.ElementAt(1) }}
            }.AsQueryable();

            var unitTypes = new Mock<DbSet<UnitType>>();
            unitTypes.As<IQueryable<UnitType>>().Setup(m => m.Provider).Returns(data.Provider);
            unitTypes.As<IQueryable<UnitType>>().Setup(m => m.Expression).Returns(data.Expression);
            unitTypes.As<IQueryable<UnitType>>().Setup(m => m.ElementType).Returns(data.ElementType);
            unitTypes.As<IQueryable<UnitType>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return unitTypes;
        }
        public static Mock<DbSet<UnitOrder>> UnitOrdersList()
        {
            var data = new List<UnitOrder>
            {
                new UnitOrder { Id = 1, OrderName = "Прорыв", OrderType = "Атака", OrderDescrption = "Совершите обычное движение от любой точки побежденного отряда",
                    SituationBonus = "Если в эту фазу активаций отряд проводил чардж - отнимите 2 от брони противника", DoubleWeaponsBonus = "+4 к боеспособности",
                    GreatWeaponBonus = "-1 к броне противника", HalberdBonus = "-1 к броне противника", OneHandBonus = "+2 к боеспособности", PikeBonus = "0",
                    SpearBonus = "0"},
                new UnitOrder { Id = 2, OrderName = "Наскок", OrderType = "Атака", OrderDescrption = "Отойдите на 4\" от побежденного отряда",
                    SituationBonus = "Если в эту фазу активаций отряд проводил чардж - добавьте 1 к своей броне", DoubleWeaponsBonus = "0",
                    GreatWeaponBonus = "-1 к броне противника", HalberdBonus = "+2 к боеспособности", OneHandBonus = "0",PikeBonus = "+4 к боеспособности",
                    SpearBonus = "+2 к боеспособности"},
                new UnitOrder { Id = 3, OrderName = "Отступление", OrderType = "Оборона", OrderDescrption = "+2 брони каждому отряду, после этого отступающий отступает на свое движение. Противник может преследовать",
                    SituationBonus = "Если ваша скорость выше, чем у противника - добавьте 1 к своей броне", DoubleWeaponsBonus = "0", GreatWeaponBonus = "-1 к броне противника",
                    HalberdBonus = "0", OneHandBonus = "0", PikeBonus = "0", SpearBonus = "0" }
            }.AsQueryable();

            var unitOrders = new Mock<DbSet<UnitOrder>>();
            unitOrders.As<IQueryable<UnitOrder>>().Setup(m => m.Provider).Returns(data.Provider);
            unitOrders.As<IQueryable<UnitOrder>>().Setup(m => m.Expression).Returns(data.Expression);
            unitOrders.As<IQueryable<UnitOrder>>().Setup(m => m.ElementType).Returns(data.ElementType);
            unitOrders.As<IQueryable<UnitOrder>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return unitOrders;
        }
    }
}
