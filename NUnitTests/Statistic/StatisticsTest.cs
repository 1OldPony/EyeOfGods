using EyeOfGods.Models;
using EyeOfGods.Models.ViewModels;
using EyeOfGods.SupportClasses;
using EyeOfGods.SupportClasses.StatGen;
using Moq;
using static NUnitTests.FakeDb.Db_Moq;

namespace NUnitTests.Statistic
{
    [TestFixture]
    internal class StatisticsTest
    {
        StatisticsGen _stat;
        Mock<MyWargameContext> _fakeDb;

        [SetUp]
        public void Setup()
        {
            _stat = new StatisticsGen();
            _fakeDb = Context();
        }
        [Test]
        public void GetUnitsStatistics_Test()
        {
            var unitsInDb = _fakeDb.Object.Units.ToList();
            var x = _stat.GetUnitsStatistics(unitsInDb).Result;

            Assume.That(x.UnitsCount, Is.Not.EqualTo(0));
        }

        [Test]
        public void UnitsCount_count_Units_RIGHT()
        {
            var unitsInDb = _fakeDb.Object.Units.ToList().Count;
            var statData = _stat.UnitsCount(_fakeDb.Object.Units.Where(u=>u.UnitName!="").ToList()).Result.unitsCount;

            Assume.That(unitsInDb, Is.EqualTo(statData));
        }

        [Test]
        public void UnitsCount_count_infantry_RIGHT()
        {
            var infntryInDb = _fakeDb.Object.Units.Where(u => u.UnitType.UnitTypeName == "Пехота").ToList().Count;
            var statData = _stat.UnitsCount(_fakeDb.Object.Units.ToList()).Result.infantryCount;

            Assume.That(infntryInDb, Is.EqualTo(statData));
        }

        [Test]
        public void UnitsCount_count_cavalery_RIGHT()
        {
            var cavaleryInDb = _fakeDb.Object.Units.Where(u => u.UnitType.UnitTypeName == "Кавалерия").ToList().Count;
            var statData = _stat.UnitsCount(_fakeDb.Object.Units.ToList()).Result.cavaleryCount;

            Assume.That(cavaleryInDb, Is.EqualTo(statData));
        }

        [Test]
        public void UnitsDefenceCharsCount_count_Characteristics_RIGHT()
        {
            int allArmor = _fakeDb.Object.Units.Where(a => a.DefensiveAbilities.CharacteristicName == "Броня").ToList().Count;

            var result = _stat.UnitsDefenceCharsCount(_fakeDb.Object.Units.ToList()).Result;
            int statArmorCount = result.Where(a => a.Name == "Броня").FirstOrDefault().UsageCount;

            Assume.That(statArmorCount, Is.EqualTo(allArmor));
        }

        [Test]
        public void UnitsEnduranceCharsCount_count_Characteristics_RIGHT()
        {
            int allEndur = _fakeDb.Object.Units.Where(a => a.EnduranceAbilities.CharacteristicName == "Выносливость").ToList().Count;
            int allCel = _fakeDb.Object.Units.Where(a => a.EnduranceAbilities.CharacteristicName == "Целостность").ToList().Count;

            var result = _stat.UnitsEnduranceCharsCount(_fakeDb.Object.Units.ToList()).Result;
            int statEndurCount = result.Where(a => a.Name == "Выносливость").FirstOrDefault(new EnduranceChars { UsageCount = 0 }).UsageCount;
            int statCelCount = result.Where(a => a.Name == "Целостность").FirstOrDefault(new EnduranceChars { UsageCount = 0 }).UsageCount;

            Assume.That(statEndurCount, Is.EqualTo(allEndur));
            Assume.That(statCelCount, Is.EqualTo(allCel));
        }

        [Test]
        public void UnitsMentalCharsCount_count_Characteristics_RIGHT()
        {
            int allRage = _fakeDb.Object.Units.Where(a => a.MentalAbilities.CharacteristicName == "Ярость").ToList().Count;
            int allBrave = _fakeDb.Object.Units.Where(a => a.MentalAbilities.CharacteristicName == "Отвага").ToList().Count;

            var result = _stat.UnitsMentalCharsCount(_fakeDb.Object.Units.ToList()).Result;
            int statRageCount = result.Where(a => a.Name == "Ярость").FirstOrDefault(new MentalChars { UsageCount = 0 }).UsageCount;
            int statBraveCount = result.Where(a => a.Name == "Отвага").FirstOrDefault(new MentalChars { UsageCount = 0 }).UsageCount;

            Assume.That(statRageCount, Is.EqualTo(allRage));
            Assume.That(statBraveCount, Is.EqualTo(allBrave));
        }

        [Test]
        public void UnitsMeleeWeaponsCount_count_Weapons_RIGHT()
        {
            int allMelWeap = _fakeDb.Object.MeleeWeapons.Where(m => m.Units.Count != 0).ToList().Count;

            var result = _stat.UnitsMeleeWeaponsCount(_fakeDb.Object.Units.ToList()).Result;
            int statMelWeapCount = result.meleeWeaponsCount;

            Assume.That(statMelWeapCount, Is.EqualTo(allMelWeap));
        }

        [Test]
        public void UnitsMeleeWeaponsCount_count_All_Its_Types_RIGHT()
        {
            int allOneHand = _fakeDb.Object.MeleeWeapons.Where(m => m.Units.Count != 0 && m.WeaponType == MeleeWeaponTypes.Одноручное).ToList().Count;
            int allTwoHand = _fakeDb.Object.MeleeWeapons.Where(m => m.Units.Count != 0 && m.WeaponType == MeleeWeaponTypes.Двуручное).ToList().Count;
            int allSpear = _fakeDb.Object.MeleeWeapons.Where(m => m.Units.Count != 0 && m.WeaponType == MeleeWeaponTypes.Копье).ToList().Count;
            int allHalb = _fakeDb.Object.MeleeWeapons.Where(m => m.Units.Count != 0 && m.WeaponType == MeleeWeaponTypes.Алебарда).ToList().Count;
            int allDouble = _fakeDb.Object.MeleeWeapons.Where(m => m.Units.Count != 0 && m.WeaponType == MeleeWeaponTypes.Парное).ToList().Count;
            int allPike = _fakeDb.Object.MeleeWeapons.Where(m => m.Units.Count != 0 && m.WeaponType == MeleeWeaponTypes.Пика).ToList().Count;

            var result = _stat.UnitsMeleeWeaponsCount(_fakeDb.Object.Units.ToList()).Result;
            int statOneHandCount = result.meleeWeaponsStat.Where(m => m.Name == MeleeWeaponTypes.Одноручное.ToString())
                .FirstOrDefault(new MeleeWeaponsStat { UsageCount = 0 }).UsageCount;

            int statTwoHandCount = result.meleeWeaponsStat.Where(m => m.Name == MeleeWeaponTypes.Двуручное.ToString())
                .FirstOrDefault(new MeleeWeaponsStat { UsageCount = 0 }).UsageCount;

            int statSpearCount = result.meleeWeaponsStat.Where(m => m.Name == MeleeWeaponTypes.Копье.ToString())
                .FirstOrDefault(new MeleeWeaponsStat { UsageCount = 0 }).UsageCount;

            int statHalbCount = result.meleeWeaponsStat.Where(m => m.Name == MeleeWeaponTypes.Алебарда.ToString())
                .FirstOrDefault(new MeleeWeaponsStat { UsageCount = 0 }).UsageCount;

            int statDoubleCount = result.meleeWeaponsStat.Where(m => m.Name == MeleeWeaponTypes.Парное.ToString())
                .FirstOrDefault(new MeleeWeaponsStat { UsageCount = 0 }).UsageCount;

            int statPikeCount = result.meleeWeaponsStat.Where(m => m.Name == MeleeWeaponTypes.Пика.ToString())
                .FirstOrDefault(new MeleeWeaponsStat { UsageCount = 0 }).UsageCount;

            Assume.That(statOneHandCount, Is.EqualTo(allOneHand));
            Assume.That(statTwoHandCount, Is.EqualTo(allTwoHand));
            Assume.That(statSpearCount, Is.EqualTo(allSpear));
            Assume.That(statHalbCount, Is.EqualTo(allHalb));
            Assume.That(statDoubleCount, Is.EqualTo(allDouble));
            Assume.That(statPikeCount, Is.EqualTo(allPike));
        }

        [Test]
        public void UnitsRangeWeaponsCount_count_Weapons_RIGHT()
        {
            var allRangeWeap = _fakeDb.Object.Units.Where(u => u.RangeWeapon != null).ToList().Count;

            var result = _stat.UnitsRangeWeaponsCount(_fakeDb.Object.Units.ToList()).Result;
            int statRangeWeapCount = result.rangeWeaponsCount;

            Assume.That(statRangeWeapCount, Is.EqualTo(allRangeWeap));
        }

        [Test]
        public void UnitsRangeWeaponsCount_count_All_Its_Types_RIGHT()
        {
            int allLiteRW = _fakeDb.Object.Units.Where(m => m.RangeWeapon != null && m.RangeWeapon.RangeWeaponsType.RWTypeName == "Легкое стрелковое вооружение").ToList().Count;
            int allHevyRW = _fakeDb.Object.Units.Where(m => m.RangeWeapon != null && m.RangeWeapon.RangeWeaponsType.RWTypeName == "Тяжелое стрелковое вооружение").ToList().Count;
            int allArtRW = _fakeDb.Object.Units.Where(m => m.RangeWeapon != null && m.RangeWeapon.RangeWeaponsType.RWTypeName == "Артиллерийское вооружение").ToList().Count;

            var result = _stat.UnitsRangeWeaponsCount(_fakeDb.Object.Units.ToList()).Result;
            int statLiteRWCount = result.rangeWeaponsStat.Where(m => m.Name == "Легкое стрелковое вооружение")
                .FirstOrDefault(new RangeWeaponsStat { UsageCount = 0 }).UsageCount;

            int statHevyRWCount = result.rangeWeaponsStat.Where(m => m.Name == "Тяжелое стрелковое вооружение")
                .FirstOrDefault(new RangeWeaponsStat { UsageCount = 0 }).UsageCount;

            int statArtRWCount = result.rangeWeaponsStat.Where(m => m.Name == "Артиллерийское вооружение")
                .FirstOrDefault(new RangeWeaponsStat { UsageCount = 0 }).UsageCount;

            Assume.That(statLiteRWCount, Is.EqualTo(allLiteRW));
            Assume.That(statHevyRWCount, Is.EqualTo(allHevyRW));
            Assume.That(statArtRWCount, Is.EqualTo(allArtRW));
        }

        [Test]
        public void UnitsShieldsCount_count_it_RIGHT()
        {
            var allShields = _fakeDb.Object.Units.Where(u => u.Shield != null).ToList().Count;

            var statShieldsCount = _stat.UnitsShieldsCount(_fakeDb.Object.Units.ToList()).Result;

            Assume.That(statShieldsCount, Is.EqualTo(allShields));
        }
    }
}
