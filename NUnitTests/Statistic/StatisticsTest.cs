using EyeOfGods.Models;
using EyeOfGods.Models.ViewModels;
using EyeOfGods.SupportClasses;
using Moq;
using static NUnitTests.FakeDb.Db_Moq;

namespace NUnitTests.Statistic
{
    [TestFixture]
    internal class StatisticsTest
    {
        Statistics _stat;
        Mock<MyWargameContext> _fakeDb;

        [SetUp]
        public void Setup()
        {
            _stat = new Statistics();
            _fakeDb = Context();
        }

        [Test]
        public void DOES_UnitsCount_count_Units_RIGHT()
        {
            var unitsInDb = _fakeDb.Object.Units.ToList().Count;
            var statData = _stat.UnitsCount(_fakeDb.Object.Units.Where(u=>u.UnitName!="").ToList()).Result.unitsCount;

            Assume.That(unitsInDb, Is.EqualTo(statData));
        }

        [Test]
        public void DOES_UnitsCount_count_infantry_RIGHT()
        {
            var infntryInDb = _fakeDb.Object.Units.Where(u => u.UnitType.UnitTypeName == "Пехота").ToList().Count;
            var statData = _stat.UnitsCount(_fakeDb.Object.Units.ToList()).Result.infantryCount;

            Assume.That(infntryInDb, Is.EqualTo(statData));
        }

        [Test]
        public void DOES_UnitsCount_count_cavalery_RIGHT()
        {
            var cavaleryInDb = _fakeDb.Object.Units.Where(u => u.UnitType.UnitTypeName == "Кавалерия").ToList().Count;
            var statData = _stat.UnitsCount(_fakeDb.Object.Units.ToList()).Result.cavaleryCount;

            Assume.That(cavaleryInDb, Is.EqualTo(statData));
        }

        [Test]
        public void DefenceChars_Characteristics_RIGHT()
        {
            int allArmor = _fakeDb.Object.Units.Where(a => a.DefensiveAbilities.CharacteristicName == "Броня").ToList().Count;

            var result = _stat.UnitsDefenceCharsCount(_fakeDb.Object.Units.ToList()).Result;
            int statArmor = result.Where(a => a.CharacteristicName == "Броня").FirstOrDefault().UsageCount;

            Assume.That(statArmor, Is.EqualTo(allArmor));
        }

        [Test]
        public void DOES_EnduranceCharsCount_count_Characteristics_RIGHT()
        {
            int allEndur = _fakeDb.Object.Units.Where(a => a.EnduranceAbilities.CharacteristicName == "Выносливость").ToList().Count;

            var result = _stat.UnitsEnduranceCharsCount(_fakeDb.Object.Units.ToList()).Result;
            int statEndur = result.Where(a => a.CharacteristicName == "Выносливость").FirstOrDefault().UsageCount;

            Assume.That(statEndur, Is.EqualTo(allEndur));
        }

        [Test]
        public void DOES_MentalCharsCount_count_Characteristics_RIGHT()
        {
            int allRage = _fakeDb.Object.Units.Where(a => a.MentalAbilities.CharacteristicName == "Ярость").ToList().Count;
            
            var result = _stat.UnitsMentalCharsCount(_fakeDb.Object.Units.ToList()).Result;
            int statRage = result.Where(a => a.CharacteristicName == "Ярость").FirstOrDefault().UsageCount;

            Assume.That(statRage, Is.EqualTo(allRage));
        }

        //[Test]
        //public void DOES_MeleeWeaponsCount_count_Weapons_RIGHT()
        //{
        //    int allRage = _fakeDb.Object.Units.Where(a => a..CharacteristicName == "Ярость").ToList().Count;

        //    var result = _stat.UnitsMentalCharsCount(_fakeDb.Object.Units.ToList()).Result;
        //    int statRage = result.Where(a => a.CharacteristicName == "Ярость").FirstOrDefault().UsageCount;

        //    Assume.That(statRage, Is.EqualTo(allRage));
        //}
    }
}
