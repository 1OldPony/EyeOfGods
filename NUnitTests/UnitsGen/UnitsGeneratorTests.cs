using EyeOfGods.Controllers;
using EyeOfGods.Models;
using EyeOfGods.SupportClasses;
using Moq;
using static NUnitTests.FakeDb.Db_Moq;

namespace NUnitTests.UnitsGen
{
    [TestFixture]
    internal class UnitsGeneratorTests
    {
        UnitGenerator uGenerator = new();
        Random rnd = new();
        private Mock<MyWargameContext> _fakeDb;

        [SetUp]
        public void Setup()
        {
            _fakeDb = Context();
        }

        [Test]
        public void DOES_GenUnitName_generate_NEW_NAME()
        {
            var oldName = _fakeDb.Object.Units.FirstOrDefault().UnitName;
            var newName = uGenerator.GenUnitName(_fakeDb.Object.Units.FirstOrDefault()).Result;

            Assert.That(newName, Is.Not.EqualTo(oldName));
        }
        [Test]
        public void DOES_GenUnitName_generate_RIGHT_NAME()
        {
            var newName = uGenerator.GenUnitName(_fakeDb.Object.Units.FirstOrDefault()).Result;

            Assert.That(newName, Is.EqualTo("Легк. Пехота c Алебарда"));
        }
        [Test]
        public void DOES_GetUnitRangeWeap_generate_RangeWeapType_for_it()
        {
            var newWeapon = uGenerator.GetUnitRangeWeap(rnd, _fakeDb.Object.RangeWeapons.ToList()).Result;

            Assert.That(newWeapon.RangeWeaponsType, Is.Not.Null);
        }
        [Test]
        public void DOES_GetMentalValue_generate_IN_RIGHT_RANGE()
        {
            List<int> statsValue = new();
            MentalAbilities unitMental = new MentalAbilities { MinValue = 1, MaxValue = 7 };

            for (int i = 0; i < 200; i++)
            {
                statsValue.Add(uGenerator.GetMentalValue(rnd, unitMental).Result);
            }

            Assert.That(statsValue.Contains(unitMental.MinValue), Is.True);
            Assert.That(statsValue.Contains(unitMental.MinValue - 1), Is.False);
            Assert.That(statsValue.Contains(unitMental.MaxValue), Is.True);
            Assert.That(statsValue.Contains(unitMental.MaxValue+1), Is.False);
        }
        [Test]
        public void DOES_GetMentalValue_generate_Abil()
        {
            var newAbil = uGenerator.GetUnitMentalAbil(rnd, _fakeDb.Object.MentalAbilities.ToList()).Result;

            Assert.That(newAbil, Is.Not.Null);
        }
        [Test]
        public void DOES_GetEnduranceValue_generate_IN_RIGHT_RANGE()
        {
            List<int> statsValue = new();
            EnduranceAbilities unitEndu = new EnduranceAbilities { MinValue = 1, MaxValue = 7 };

            for (int i = 0; i < 200; i++)
            {
                statsValue.Add(uGenerator.GetEnduranceValue(rnd, unitEndu).Result);
            }

            Assert.That(statsValue.Contains(unitEndu.MinValue), Is.True);
            Assert.That(statsValue.Contains(unitEndu.MinValue - 1), Is.False);
            Assert.That(statsValue.Contains(unitEndu.MaxValue), Is.True);
            Assert.That(statsValue.Contains(unitEndu.MaxValue + 1), Is.False);
        }
        [Test]
        public void DOES_GetUnitEnduranceAbil_generate_Abil()
        {
            var newAbil = uGenerator.GetUnitEnduranceAbil(rnd, _fakeDb.Object.EnduranceAbilities.ToList()).Result;

            Assert.That(newAbil, Is.Not.Null);
        }
        [Test]
        public void DOES_GetDefenseValue_generate_IN_RIGHT_RANGE()
        {
            List<int> statsValue = new();
            DefensiveAbilities unitDef = new DefensiveAbilities { MinValue = 1, MaxValue = 7 };

            for (int i = 0; i < 200; i++)
            {
                statsValue.Add(uGenerator.GetDefenseValue(rnd, unitDef).Result);
            }

            Assert.That(statsValue.Contains(unitDef.MinValue), Is.True);
            Assert.That(statsValue.Contains(unitDef.MinValue - 1), Is.False);
            Assert.That(statsValue.Contains(unitDef.MaxValue), Is.True);
            Assert.That(statsValue.Contains(unitDef.MaxValue + 1), Is.False);
        }
        [Test]
        public void DOES_GetUnitDefensiveAbil_generate_Abil()
        {
            var newAbil = uGenerator.GetUnitDefensiveAbil(rnd, _fakeDb.Object.DefensiveAbilities.ToList()).Result;

            Assert.That(newAbil, Is.Not.Null);
        }
        [Test]
        public void DOES_GetSpeedValue_generate_IN_RIGHT_RANGE()
        {
            List<int> statsValue = new();
            UnitType unitType = new UnitType { MinSpeed = 1, MaxSpeed = 7 };

            for (int i = 0; i < 200; i++)
            {
                statsValue.Add(uGenerator.GetSpeedValue(rnd, unitType).Result);
            }

            Assert.That(statsValue.Contains(unitType.MinSpeed), Is.True);
            Assert.That(statsValue.Contains(unitType.MinSpeed - 1), Is.False);
            Assert.That(statsValue.Contains(unitType.MaxSpeed), Is.True);
            Assert.That(statsValue.Contains(unitType.MaxSpeed + 1), Is.False);
        }
        [Test]
        public void DOES_GetUnitType_generate_Orders_for_it()
        {
            var newType = uGenerator.GetUnitType(rnd, _fakeDb.Object.UnitTypes.ToList()).Result;

            Assert.That(newType.UnitTypeOrders, Is.Not.Null);
        }
        [Test]
        public void DOES_GetUnitShield_generate_Shield()
        {
            var newShield = uGenerator.GetUnitShield(rnd, _fakeDb.Object.Shields.ToList()).Result;

            Assert.That(newShield, Is.Not.Null);
        }
        [Test]
        public void DOES_GenUnits_generate_ALL_stats()
        {
            var newUnit = uGenerator.GenUnits(1, _fakeDb.Object.UnitTypes.ToList(), _fakeDb.Object.RangeWeapons.ToList(),
                _fakeDb.Object.MeleeWeapons.ToList(), _fakeDb.Object.Shields.ToList(), _fakeDb.Object.MentalAbilities.ToList(),
                _fakeDb.Object.DefensiveAbilities.ToList(), _fakeDb.Object.EnduranceAbilities.ToList()).Result.FirstOrDefault();

            Assert.That(newUnit.Defense, Is.Not.EqualTo(0));
            Assert.That(newUnit.DefensiveAbilities, Is.Not.Null);
            Assert.That(newUnit.Endurance, Is.Not.EqualTo(0));
            Assert.That(newUnit.EnduranceAbilities, Is.Not.Null);
            Assert.That(newUnit.MeleeWeapons.Count, Is.Not.EqualTo(0));
            Assert.That(newUnit.Mental, Is.Not.EqualTo(0));
            Assert.That(newUnit.MentalAbilities, Is.Not.Null);
            Assert.That(newUnit.Speed, Is.Not.EqualTo(0));
            Assert.That(newUnit.UnitName, Is.Not.EqualTo("Название отряда"));
            Assert.That(newUnit.UnitType, Is.Not.Null);
            Assert.That(newUnit.UnitType.UnitTypeOrders, Is.Not.Null);
        }
        [TestCase (2)]
        [TestCase(4)]
        [TestCase(1)]
        public void DOES_GenUnits_generate_RIGHT_number_of_Units(int count)
        {
            var newUnit = uGenerator.GenUnits(count, _fakeDb.Object.UnitTypes.ToList(), _fakeDb.Object.RangeWeapons.ToList(),
                _fakeDb.Object.MeleeWeapons.ToList(), _fakeDb.Object.Shields.ToList(), _fakeDb.Object.MentalAbilities.ToList(),
                _fakeDb.Object.DefensiveAbilities.ToList(), _fakeDb.Object.EnduranceAbilities.ToList()).Result;

            Assert.That(newUnit.Count, Is.EqualTo(count));
        }
    }
}
