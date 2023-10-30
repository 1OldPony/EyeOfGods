using EyeOfGods.Context;
using EyeOfGods.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Moq.EntityFrameworkCore;

namespace NUnitTests.FakeDb
{
    public static class Db_Moq
    {
        public static Mock<MyWargameContext> Context()
        {
            var mockContext = new Mock<MyWargameContext>();
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
                    MentalAbilities = MentalAbilitiesList().Object.ElementAt(1), MeleeWeapons = {MeleeWeaponsList().Object.ElementAt(2),MeleeWeaponsList().Object.ElementAt(0)},
                    UnitType = UnitTypesList().Object.ElementAt(0), UnitName = "Test_Halberdier_NoShield_NoRange_NoFuture",
                    Speed = 8, Defense = 4, Endurance = 8, Mental = 2, RangeWeapon = RangeWeaponsList().Object.ElementAt(0)
                }
            }.AsQueryable();

            var unitsList = new Mock<DbSet<Unit>>();
            unitsList.As<IQueryable<Unit>>().Setup(m => m.Provider).Returns(data.Provider);
            unitsList.As<IQueryable<Unit>>().Setup(m => m.Expression).Returns(data.Expression);
            unitsList.As<IQueryable<Unit>>().Setup(m => m.ElementType).Returns(data.ElementType);
            unitsList.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            //unitsList.As<IQueryable<Unit>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return unitsList;
        }

        public static Mock<DbSet<DefensiveAbilities>> DefensiveAbilitiesList()
        {
            SeedData seedData = new();
            var data = new List<DefensiveAbilities>{seedData.defensiveAbilities[0], seedData.defensiveAbilities[1], seedData.defensiveAbilities[2]}.AsQueryable();

            var defensiveAbilities = new Mock<DbSet<DefensiveAbilities>>();
            defensiveAbilities.As<IQueryable<DefensiveAbilities>>().Setup(m => m.Provider).Returns(data.Provider);
            defensiveAbilities.As<IQueryable<DefensiveAbilities>>().Setup(m => m.Expression).Returns(data.Expression);
            defensiveAbilities.As<IQueryable<DefensiveAbilities>>().Setup(m => m.ElementType).Returns(data.ElementType);
            defensiveAbilities.As<IQueryable<DefensiveAbilities>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return defensiveAbilities;
        }
        public static Mock<DbSet<EnduranceAbilities>> EnduranceAbilitiesList()
        {
            SeedData seedData = new();
            var data = new List<EnduranceAbilities>{seedData.enduranceAbilities[0], seedData.enduranceAbilities[1]}.AsQueryable();

            var enduranceAbilities = new Mock<DbSet<EnduranceAbilities>>();
            enduranceAbilities.As<IQueryable<EnduranceAbilities>>().Setup(m => m.Provider).Returns(data.Provider);
            enduranceAbilities.As<IQueryable<EnduranceAbilities>>().Setup(m => m.Expression).Returns(data.Expression);
            enduranceAbilities.As<IQueryable<EnduranceAbilities>>().Setup(m => m.ElementType).Returns(data.ElementType);
            enduranceAbilities.As<IQueryable<EnduranceAbilities>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return enduranceAbilities;
        }
        public static Mock<DbSet<MentalAbilities>> MentalAbilitiesList()
        {
            SeedData seedData = new();
            var data = new List<MentalAbilities>{ seedData.mentalAbilities[0], seedData.mentalAbilities[1] }.AsQueryable();

            var mentalAbilities = new Mock<DbSet<MentalAbilities>>();
            mentalAbilities.As<IQueryable<MentalAbilities>>().Setup(m => m.Provider).Returns(data.Provider);
            mentalAbilities.As<IQueryable<MentalAbilities>>().Setup(m => m.Expression).Returns(data.Expression);
            mentalAbilities.As<IQueryable<MentalAbilities>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mentalAbilities.As<IQueryable<MentalAbilities>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mentalAbilities;
        }
        public static Mock<DbSet<MeleeWeapon>> MeleeWeaponsList()
        {
            SeedData seedData = new();
            seedData.meleeWeapon[0].Units.Add(new Unit { Id = 1 });
            seedData.meleeWeapon[2].Units.Add(new Unit { Id = 1 });
            var data = new List<MeleeWeapon>{ seedData.meleeWeapon[0], seedData.meleeWeapon[1], seedData.meleeWeapon[2] }.AsQueryable();

            var meleeWeapons = new Mock<DbSet<MeleeWeapon>>();
            meleeWeapons.As<IQueryable<MeleeWeapon>>().Setup(m => m.Provider).Returns(data.Provider);
            meleeWeapons.As<IQueryable<MeleeWeapon>>().Setup(m => m.Expression).Returns(data.Expression);
            meleeWeapons.As<IQueryable<MeleeWeapon>>().Setup(m => m.ElementType).Returns(data.ElementType);
            meleeWeapons.As<IQueryable<MeleeWeapon>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return meleeWeapons;
        }
        public static Mock<DbSet<RangeWeapon>> RangeWeaponsList()
        {
            SeedData seedData = new();
            seedData.rangeWeapon[0].RangeWeaponsType = seedData.rangeWeaponsType[0];
            seedData.rangeWeapon[1].RangeWeaponsType = seedData.rangeWeaponsType[1];
            seedData.rangeWeapon[2].RangeWeaponsType = seedData.rangeWeaponsType[2];

            var data = new List<RangeWeapon> { seedData.rangeWeapon[0], seedData.rangeWeapon[1], seedData.rangeWeapon[2] }.AsQueryable();

            var rangeWeapons = new Mock<DbSet<RangeWeapon>>();
            rangeWeapons.As<IQueryable<RangeWeapon>>().Setup(m => m.Provider).Returns(data.Provider);
            rangeWeapons.As<IQueryable<RangeWeapon>>().Setup(m => m.Expression).Returns(data.Expression);
            rangeWeapons.As<IQueryable<RangeWeapon>>().Setup(m => m.ElementType).Returns(data.ElementType);
            rangeWeapons.As<IQueryable<RangeWeapon>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return rangeWeapons;
        }
        public static Mock<DbSet<RangeWeaponsType>> RangeWeaponsTypeList()
        {
            SeedData seedData = new();
            var data = new List<RangeWeaponsType> { seedData.rangeWeaponsType[0], seedData.rangeWeaponsType[1], seedData.rangeWeaponsType[2] }.AsQueryable();

            var rangeWeaponsType = new Mock<DbSet<RangeWeaponsType>>();
            rangeWeaponsType.As<IQueryable<RangeWeaponsType>>().Setup(m => m.Provider).Returns(data.Provider);
            rangeWeaponsType.As<IQueryable<RangeWeaponsType>>().Setup(m => m.Expression).Returns(data.Expression);
            rangeWeaponsType.As<IQueryable<RangeWeaponsType>>().Setup(m => m.ElementType).Returns(data.ElementType);
            rangeWeaponsType.As<IQueryable<RangeWeaponsType>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return rangeWeaponsType;
        }
        public static Mock<DbSet<Shield>> ShieldsList()
        {
            SeedData seedData = new();
            var data = new List<Shield> { seedData.shield[0] }.AsQueryable();

            var shields = new Mock<DbSet<Shield>>();
            shields.As<IQueryable<Shield>>().Setup(m => m.Provider).Returns(data.Provider);
            shields.As<IQueryable<Shield>>().Setup(m => m.Expression).Returns(data.Expression);
            shields.As<IQueryable<Shield>>().Setup(m => m.ElementType).Returns(data.ElementType);
            shields.As<IQueryable<Shield>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return shields;
        }
        public static Mock<DbSet<UnitType>> UnitTypesList()
        {
            SeedData seedData = new();
            seedData.unitType[0].UnitTypeOrders.Add(seedData.unitOrder[2]);
            seedData.unitType[1].UnitTypeOrders.AddRange(new List<UnitOrder> { seedData.unitOrder[0], seedData.unitOrder[1] });

            var data = new List<UnitType>{ seedData.unitType[0], seedData.unitType[1] }.AsQueryable();

            var unitTypes = new Mock<DbSet<UnitType>>();
            unitTypes.As<IQueryable<UnitType>>().Setup(m => m.Provider).Returns(data.Provider);
            unitTypes.As<IQueryable<UnitType>>().Setup(m => m.Expression).Returns(data.Expression);
            unitTypes.As<IQueryable<UnitType>>().Setup(m => m.ElementType).Returns(data.ElementType);
            unitTypes.As<IQueryable<UnitType>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return unitTypes;
        }
        public static Mock<DbSet<UnitOrder>> UnitOrdersList()
        {
            SeedData seedData = new();
            var data = new List<UnitOrder>{ seedData.unitOrder[0], seedData.unitOrder[1], seedData.unitOrder[2] }.AsQueryable();

            var unitOrders = new Mock<DbSet<UnitOrder>>();
            unitOrders.As<IQueryable<UnitOrder>>().Setup(m => m.Provider).Returns(data.Provider);
            unitOrders.As<IQueryable<UnitOrder>>().Setup(m => m.Expression).Returns(data.Expression);
            unitOrders.As<IQueryable<UnitOrder>>().Setup(m => m.ElementType).Returns(data.ElementType);
            unitOrders.As<IQueryable<UnitOrder>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return unitOrders;
        }
    }
}
