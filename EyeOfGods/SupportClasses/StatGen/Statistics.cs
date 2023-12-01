using EyeOfGods.Models;
using EyeOfGods.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.SupportClasses.StatGen
{
    public class Statistics : IStatistics
    {
        public Task<StatisticsViewModel> GetUnitsStatistics(List<Unit> allUnits)
        {
            StatisticsViewModel statistics = new();

            //Учитываем юнитов и их типы
            var uCount = UnitsCount(allUnits).Result;
            statistics.UnitsCount = uCount.unitsCount;
            statistics.InfantryCount = uCount.infantryCount;
            statistics.CavaleryCount = uCount.cavaleryCount;
            statistics.MonsterCount = uCount.monsterCount;
            statistics.GiantsCount = uCount.giantsCount;
            statistics.ArtilleryCount = uCount.artilleryCount;
            statistics.VenicleCount = uCount.venicleCount;
            statistics.AviationCount = uCount.aviationCount;

            //учитываем защитные характеристики
            statistics.DefenceChars.AddRange(UnitsDefenceCharsCount(allUnits).Result);

            //учитываем характеристики выносливости
            statistics.EnduranceChars.AddRange(UnitsEnduranceCharsCount(allUnits).Result);

            //учитываем ментальные характеристики
            statistics.MentalChars.AddRange(UnitsMentalCharsCount(allUnits).Result);

            //учитываем оружие ближнего боя
            var meleeCount = UnitsMeleeWeaponsCount(allUnits).Result;
            statistics.MeleeWeaponsCount = meleeCount.meleeWeaponsCount;
            statistics.MeleeWeaponsTypes.AddRange(meleeCount.meleeWeaponsStat);

            //учитываем оружие дальнего боя
            var rangeCount = UnitsRangeWeaponsCount(allUnits).Result;
            statistics.RangeWeaponsCount = rangeCount.rangeWeaponsCount;
            statistics.RangeWeaponsTypes.AddRange(rangeCount.rangeWeaponsStat);

            //учитываем щиты
            statistics.ShieldsCount = UnitsShieldsCount(allUnits).Result;

            return Task.FromResult(statistics);
        }

        public Task<(int unitsCount, int infantryCount, int cavaleryCount, int monsterCount, int giantsCount,
            int artilleryCount, int venicleCount, int aviationCount)> UnitsCount(List<Unit> allUnits)
        {
            int unitsCount = 0;
            int infantryCount = 0;
            int cavaleryCount = 0;
            int monsterCount = 0;
            int giantsCount = 0;
            int artilleryCount = 0;
            int venicleCount = 0;
            int aviationCount = 0;

            foreach (var unit in allUnits)
            {
                unitsCount++;

                switch (unit.UnitType.UnitTypeName)
                {
                    case "Пехота":
                        infantryCount++;
                        break;
                    case "Кавалерия":
                        cavaleryCount++;
                        break;
                    case "Монстры":
                        monsterCount++;
                        break;
                    case "Гиганты":
                        giantsCount++;
                        break;
                    case "Артиллерия":
                        artilleryCount++;
                        break;
                    case "Техника":
                        venicleCount++;
                        break;
                    case "Авиация":
                        aviationCount++;
                        break;
                    default:
                        break;
                }
            }
            return Task.FromResult((unitsCount, infantryCount, cavaleryCount, monsterCount, giantsCount, artilleryCount, venicleCount, aviationCount));
        }

        public Task<List<DefenceChars>> UnitsDefenceCharsCount(List<Unit> allUnits)
        {
            List<DefenceChars> all = new();

            foreach (var unit in allUnits)
            {
                if (!all.Any(x => x.Name == unit.DefensiveAbilities.CharacteristicName))
                {
                    all.Add(new DefenceChars() { Name = unit.DefensiveAbilities.CharacteristicName, UsageCount = 1 });
                }
                else
                {
                    all.First(x => x.Name == unit.DefensiveAbilities.CharacteristicName).UsageCount++;
                }
            }
            return Task.FromResult(all);
        }

        public Task<List<EnduranceChars>> UnitsEnduranceCharsCount(List<Unit> allUnits)
        {
            List<EnduranceChars> all = new();

            foreach (var unit in allUnits)
            {
                if (!all.Any(x => x.Name == unit.EnduranceAbilities.CharacteristicName))
                {
                    all.Add(new EnduranceChars() { Name = unit.EnduranceAbilities.CharacteristicName, UsageCount = 1 });
                }
                else
                {
                    all.First(x => x.Name == unit.EnduranceAbilities.CharacteristicName).UsageCount++;
                }
            }
            return Task.FromResult(all);
        }

        public Task<List<MentalChars>> UnitsMentalCharsCount(List<Unit> allUnits)
        {
            List<MentalChars> all = new();

            foreach (var unit in allUnits)
            {
                if (!all.Any(x => x.Name == unit.MentalAbilities.CharacteristicName))
                {
                    all.Add(new MentalChars() { Name = unit.MentalAbilities.CharacteristicName, UsageCount = 1 });
                }
                else
                {
                    all.First(x => x.Name == unit.MentalAbilities.CharacteristicName).UsageCount++;
                }
            }
            return Task.FromResult(all);
        }

        public Task<(List<MeleeWeaponsStat> meleeWeaponsStat, int meleeWeaponsCount)> UnitsMeleeWeaponsCount(List<Unit> allUnits)
        {
            List<MeleeWeaponsStat> all = new();
            int meleeWeaponsCount = 0;

            foreach (var unit in allUnits)
            {
                foreach (var weapon in unit.MeleeWeapons)
                {
                    meleeWeaponsCount++;
                    if (!all.Any(x => x.Name == weapon.WeaponType.ToString()))
                    {
                        all.Add(new MeleeWeaponsStat() { Name = weapon.WeaponType.ToString(), UsageCount = 1 });
                    }
                    else
                    {
                        all.First(x => x.Name == weapon.WeaponType.ToString()).UsageCount++;
                    }
                }
            }

            var result = (all, meleeWeaponsCount);

            return Task.FromResult(result);
        }

        public Task<(List<RangeWeaponsStat> rangeWeaponsStat, int rangeWeaponsCount)> UnitsRangeWeaponsCount(List<Unit> allUnits)
        {
            List<RangeWeaponsStat> all = new();
            int rangeWeaponsCount = 0;

            foreach (var unit in allUnits)
            {
                if (unit.RangeWeapon!=null)
                {
                    rangeWeaponsCount++;
                    if (!all.Any(x => x.Name == unit.RangeWeapon.RangeWeaponsType.RWTypeName))
                    {
                        all.Add(new RangeWeaponsStat() { Name = unit.RangeWeapon.RangeWeaponsType.RWTypeName, UsageCount = 1 });
                    }
                    else
                    {
                        all.First(x => x.Name == unit.RangeWeapon.RangeWeaponsType.RWTypeName).UsageCount++;
                    }
                }
            }

            return Task.FromResult((all, rangeWeaponsCount));
        }

        public Task<int> UnitsShieldsCount(List<Unit> allUnits)
        {
            int shieldsCount = 0;

            foreach (var unit in allUnits)
            {
                if (unit.Shield!=null)
                {
                    shieldsCount++;
                }
            }
            return Task.FromResult(shieldsCount);
        }
    }
}
