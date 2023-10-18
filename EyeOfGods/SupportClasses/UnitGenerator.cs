using EyeOfGods.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace EyeOfGods.SupportClasses
{
    public class UnitGenerator : IUnitGenerator
    {
        public async Task<List<Unit>> GenUnits(int count, List<UnitType> allTypes, List<RangeWeapon> allRangeWeapons, List<MeleeWeapon> allMeleeWeapons,
            List<Shield> allShields, List<MentalAbilities> allMental, List<DefensiveAbilities> allDefense, List<EnduranceAbilities> allEndurance)
        {
            Random randomNumber = new();
            List<Unit> allUnits = new();

            for (int i = 0; i < count; i++)
            {
                Unit newUnit = new();

                //НАЗНАЧАЕМ ОРУЖИЕ, ЩИТЫ, ТИПЫ ОСНОВНЫХ ХАРАКТЕРИСТИК И РОД ВОЙСК
                newUnit.MentalAbilities = await GetUnitMentalAbil(randomNumber, allMental);
                newUnit.DefensiveAbilities = await GetUnitDefensiveAbil(randomNumber, allDefense);
                newUnit.EnduranceAbilities = await GetUnitEnduranceAbil(randomNumber, allEndurance);
                newUnit.MeleeWeapons.Add(await GetUnitMeleeWeap(randomNumber, allMeleeWeapons));
                if (LittleHelper.UnitEquipRandomAssigment(newUnit, "RangeWeapon", 30.0))
                {
                    newUnit.RangeWeapon = await GetUnitRangeWeap(randomNumber, allRangeWeapons);
                }
                if (LittleHelper.UnitEquipRandomAssigment(newUnit, "Shield", 50.0))
                {
                    newUnit.Shield = await GetUnitShield(randomNumber, allShields);
                }
                newUnit.UnitType = await GetUnitType(randomNumber, allTypes);

                //НАЗНАЧАЕМ ЦИФЕРНЫЕ ХАРАКТЕРИСТИКИ - СКОРОСТЬ И 3 ОСНОВНЫЕ
                while (newUnit.Speed % 2 == 0 && newUnit.Speed == 0)
                {
                    newUnit.Speed = await GetSpeedValue(randomNumber, newUnit.UnitType);
                }

                while (newUnit.Defense % newUnit.DefensiveAbilities.Step == 0 && newUnit.Defense == 0)
                {
                    newUnit.Defense = await GetDefenseValue(randomNumber, newUnit.DefensiveAbilities);
                }

                while (newUnit.Endurance % newUnit.EnduranceAbilities.Step == 0 && newUnit.Endurance == 0)
                {
                    newUnit.Endurance = await GetEnduranceValue(randomNumber, newUnit.EnduranceAbilities);
                }

                while (newUnit.Mental % newUnit.MentalAbilities.Step == 0 && newUnit.Mental == 0)
                {
                    newUnit.Mental = await GetMentalValue(randomNumber, newUnit.MentalAbilities);
                }

                newUnit.UnitName = await GenUnitName(newUnit);

                allUnits.Add(newUnit);
            }
            return allUnits;
        }

        public Task<MentalAbilities> GetUnitMentalAbil(Random randomNumber, List<MentalAbilities> allMental) => Task.FromResult(allMental.ElementAt(randomNumber.Next(0, allMental.Count)));
        public Task<DefensiveAbilities> GetUnitDefensiveAbil(Random randomNumber, List<DefensiveAbilities> allDefense) => Task.FromResult(allDefense.ElementAt(randomNumber.Next(0, allDefense.Count)));
        public Task<EnduranceAbilities> GetUnitEnduranceAbil(Random randomNumber, List<EnduranceAbilities> allEndurance) => Task.FromResult(allEndurance.ElementAt(randomNumber.Next(0, allEndurance.Count)));
        public Task<MeleeWeapon> GetUnitMeleeWeap(Random randomNumber, List<MeleeWeapon> allMeleeWeapons) => Task.FromResult(allMeleeWeapons.ElementAt(randomNumber.Next(0, allMeleeWeapons.Count)));
        public Task<RangeWeapon> GetUnitRangeWeap(Random randomNumber, List<RangeWeapon> allRangeWeapons) => Task.FromResult(allRangeWeapons.ElementAt(randomNumber.Next(0, allRangeWeapons.Count)));
        public Task<Shield> GetUnitShield(Random randomNumber, List<Shield> allShields) => Task.FromResult(allShields.ElementAt(randomNumber.Next(0, allShields.Count)));
        public Task<UnitType> GetUnitType(Random randomNumber, List<UnitType> allTypes) => Task.FromResult(allTypes.ElementAt(randomNumber.Next(0, allTypes.Count)));
        public Task<int> GetSpeedValue(Random randomNumber, UnitType typeOfUnit) => Task.FromResult(randomNumber.Next(typeOfUnit.MinSpeed, typeOfUnit.MaxSpeed + 1));
        public Task<int> GetDefenseValue(Random randomNumber, DefensiveAbilities defOfUnit) => Task.FromResult(randomNumber.Next(defOfUnit.MinValue, defOfUnit.MaxValue + 1));
        public Task<int> GetEnduranceValue(Random randomNumber, EnduranceAbilities endOfUnit) => Task.FromResult(randomNumber.Next(endOfUnit.MinValue, endOfUnit.MaxValue + 1));
        public Task<int> GetMentalValue(Random randomNumber, MentalAbilities mentOfUnit) => Task.FromResult(randomNumber.Next(mentOfUnit.MinValue, mentOfUnit.MaxValue + 1));
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
