using EyeOfGods.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace EyeOfGods.SupportClasses.UniGen
{
    public class UnitGenerator : IUnitGenerator
    {
        ILittleHelper _helper;
        ILogger<UnitGenerator> _logger;
        public UnitGenerator(ILittleHelper helper, ILogger<UnitGenerator> logger)
        {
            _helper = helper;
            _logger = logger;
        }
        public async Task<List<Unit>> GenRndUnits(int count, List<UnitType> allTypes, List<RangeWeapon> allRangeWeapons, List<MeleeWeapon> allMeleeWeapons,
            List<Shield> allShields, List<MentalAbilities> allMental, List<DefensiveAbilities> allDefense, List<EnduranceAbilities> allEndurance)
        {
            Random rnd = new();
            List<Unit> allUnits = new();

            for (int i = 0; i < count; i++)
            {
                Unit newUnit = new();
                //НАЗНАЧАЕМ ОРУЖИЕ, ЩИТЫ, ТИПЫ ОСНОВНЫХ ХАРАКТЕРИСТИК И РОД ВОЙСК
                try
                {
                    newUnit.MentalAbilities = await GetRndUnitMentalAbil(rnd, allMental);
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Не удалось сгенерировать ментальную характеристику, передано {allMental.Count} хар-к");
                    throw new Exception($"Не удалось сгенерировать ментальную характеристику, передано {allMental.Count} хар-к"+
                        $" {e.Message}, {e.StackTrace}");
                }

                try
                {
                    newUnit.DefensiveAbilities = await GetRndUnitDefensiveAbil(rnd, allDefense);
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Не удалось сгенерировать защитную характеристику, передано {allDefense.Count} хар-к");
                    throw new Exception($"Не удалось сгенерировать защитную характеристику, передано {allDefense.Count} хар-к" +
                        $" {e.Message}, {e.StackTrace}");
                }

                try
                {
                    newUnit.EnduranceAbilities = await GetRndUnitEnduranceAbil(rnd, allEndurance);
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Не удалось сгенерировать характеристику выносливости, передано {allEndurance.Count} хар-к");
                    throw new Exception($"Не удалось сгенерировать характеристику выносливости, передано {allEndurance.Count} хар-к" +
                        $" {e.Message}, {e.StackTrace}");
                }

                try
                {
                    newUnit.MeleeWeapons.Add(await GetRndUnitMeleeWeap(rnd, allMeleeWeapons));
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Не удалось сгенерировать оружие бл. боя, передано {allMeleeWeapons.Count} элем.");
                    throw new Exception($"Не удалось сгенерировать оружие бл. боя, передано {allMeleeWeapons.Count} элем." +
                        $" {e.Message}, {e.StackTrace}");
                }
                //LittleHelper x = new();
                try
                {
                    if (_helper.UnitEquipRandomAssigment(newUnit, "RangeWeapon", 30.0))
                    {
                        newUnit.RangeWeapon = await GetRndUnitRangeWeap(rnd, allRangeWeapons);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Не удалось сгенерировать оружие дал. боя, передано {allRangeWeapons.Count} элем.");
                    throw new Exception($"Не удалось сгенерировать оружие дал. боя, передано {allRangeWeapons.Count} элем." +
                        $" {e.Message}, {e.StackTrace}");
                }

                try
                {
                    if (_helper.UnitEquipRandomAssigment(newUnit, "Shield", 50.0))
                    {
                        newUnit.Shield = await GetRndUnitShield(rnd, allShields);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Не удалось сгенерировать щит, передано {allShields.Count} элем.");
                    throw new Exception($"Не удалось сгенерировать щит, передано {allShields.Count} элем." +
                        $" {e.Message}, {e.StackTrace}");
                }

                try
                {
                    newUnit.UnitType = await GetRndUnitType(rnd, allTypes);
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Не удалось сгенерировать род войск, передано {allTypes.Count} элем.");
                    throw new Exception($"Не удалось сгенерировать род войск, передано {allTypes.Count} элем." +
                        $" {e.Message}, {e.StackTrace}");
                }

                //НАЗНАЧАЕМ ЦИФЕРНЫЕ ХАРАКТЕРИСТИКИ - СКОРОСТЬ И 3 ОСНОВНЫЕ
                while (newUnit.Speed % 2 == 0 && newUnit.Speed == 0)
                {
                    newUnit.Speed = await GetRndSpeedValue(rnd, newUnit.UnitType);
                }

                while (newUnit.Defense % newUnit.DefensiveAbilities.Step == 0 && newUnit.Defense == 0)
                {
                    newUnit.Defense = await GetRndDefenseValue(rnd, newUnit.DefensiveAbilities);
                }

                while (newUnit.Endurance % newUnit.EnduranceAbilities.Step == 0 && newUnit.Endurance == 0)
                {
                    newUnit.Endurance = await GetRndEnduranceValue(rnd, newUnit.EnduranceAbilities);
                }

                while (newUnit.Mental % newUnit.MentalAbilities.Step == 0 && newUnit.Mental == 0)
                {
                    newUnit.Mental = await GetRndMentalValue(rnd, newUnit.MentalAbilities);
                }

                try
                {
                    newUnit.UnitName = await GenUnitName(newUnit);
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Не удалось сгенерировать имя отряда");
                    throw new Exception($"Не удалось сгенерировать имя отряда {e.Message}, {e.StackTrace}");
                }

                allUnits.Add(newUnit);
            }
            return allUnits;
        }

        public Task<MentalAbilities> GetRndUnitMentalAbil(Random rnd, List<MentalAbilities> allMental) => Task.FromResult(allMental.ElementAt(rnd.Next(0, allMental.Count)));
        public Task<DefensiveAbilities> GetRndUnitDefensiveAbil(Random rnd, List<DefensiveAbilities> allDefense) => Task.FromResult(allDefense.ElementAt(rnd.Next(0, allDefense.Count)));
        public Task<EnduranceAbilities> GetRndUnitEnduranceAbil(Random rnd, List<EnduranceAbilities> allEndurance) => Task.FromResult(allEndurance.ElementAt(rnd.Next(0, allEndurance.Count)));
        public Task<MeleeWeapon> GetRndUnitMeleeWeap(Random rnd, List<MeleeWeapon> allMeleeWeapons) => Task.FromResult(allMeleeWeapons.ElementAt(rnd.Next(0, allMeleeWeapons.Count)));
        public Task<RangeWeapon> GetRndUnitRangeWeap(Random rnd, List<RangeWeapon> allRangeWeapons) => Task.FromResult(allRangeWeapons.ElementAt(rnd.Next(0, allRangeWeapons.Count)));
        public Task<Shield> GetRndUnitShield(Random rnd, List<Shield> allShields) => Task.FromResult(allShields.ElementAt(rnd.Next(0, allShields.Count)));
        public Task<UnitType> GetRndUnitType(Random rnd, List<UnitType> allTypes) => Task.FromResult(allTypes.ElementAt(rnd.Next(0, allTypes.Count)));
        public Task<int> GetRndSpeedValue(Random rnd, UnitType typeOfUnit) => Task.FromResult(rnd.Next(typeOfUnit.MinSpeed, typeOfUnit.MaxSpeed + 1));
        public Task<int> GetRndDefenseValue(Random rnd, DefensiveAbilities defOfUnit) => Task.FromResult(rnd.Next(defOfUnit.MinValue, defOfUnit.MaxValue + 1));
        public Task<int> GetRndEnduranceValue(Random rnd, EnduranceAbilities endOfUnit) => Task.FromResult(rnd.Next(endOfUnit.MinValue, endOfUnit.MaxValue + 1));
        public Task<int> GetRndMentalValue(Random rnd, MentalAbilities mentOfUnit) => Task.FromResult(rnd.Next(mentOfUnit.MinValue, mentOfUnit.MaxValue + 1));
        public Task<string> GenUnitName(Unit newUnit)
        {
            string unitName;
            if (newUnit.Defense < newUnit.DefensiveAbilities.NoDoubleActionAt)
                unitName = "Легк.";
            else
                unitName = "Тяж.";

            unitName = string.Concat(unitName, " ", newUnit.UnitType.UnitTypeName);

            int unitMeleeWeapon = 1;
            foreach (var item in newUnit.MeleeWeapons)
            {
                if (unitMeleeWeapon == 1)
                {
                    unitName = string.Concat(unitName, " c ", item.MWName);
                    unitMeleeWeapon++;
                }
                else
                    unitName = string.Concat(unitName, " и ", item.MWName);
            }

            return Task.FromResult(unitName);
        }
    }
}
