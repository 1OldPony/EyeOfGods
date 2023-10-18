using EyeOfGods.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EyeOfGods.SupportClasses
{
    public interface IUnitGenerator
    {
        Task<DefensiveAbilities> GetUnitDefensiveAbil(Random randomNumber, List<DefensiveAbilities> allDefense);
        Task<EnduranceAbilities> GetUnitEnduranceAbil(Random randomNumber, List<EnduranceAbilities> allEndurance);
        Task<MeleeWeapon> GetUnitMeleeWeap(Random randomNumber, List<MeleeWeapon> allMeleeWeapons);
        Task<MentalAbilities> GetUnitMentalAbil(Random randomNumber, List<MentalAbilities> allMental);
        Task<RangeWeapon> GetUnitRangeWeap(Random randomNumber, List<RangeWeapon> allRangeWeapons);
        Task<Shield> GetUnitShield(Random randomNumber, List<Shield> allShields);
        Task<string> GenUnitName(Unit newUnit);
        Task<List<Unit>> GenUnits(int count, List<UnitType> allTypes, List<RangeWeapon> allRangeWeapons, List<MeleeWeapon> allMeleeWeapons, List<Shield> allShields, List<MentalAbilities> allMental, List<DefensiveAbilities> allDefense, List<EnduranceAbilities> allEndurance);
        Task<UnitType> GetUnitType(Random randomNumber, List<UnitType> allTypes);
        Task<int> GetDefenseValue(Random randomNumber, DefensiveAbilities defOfUnit);
        Task<int> GetEnduranceValue(Random randomNumber, EnduranceAbilities endOfUnit);
        Task<int> GetMentalValue(Random randomNumber, MentalAbilities mentOfUnit);
        Task<int> GetSpeedValue(Random randomNumber, UnitType typeOfUnit);
    }
}