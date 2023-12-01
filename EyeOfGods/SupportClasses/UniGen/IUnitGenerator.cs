using EyeOfGods.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EyeOfGods.SupportClasses.UniGen
{
    public interface IUnitGenerator
    {
        Task<DefensiveAbilities> GetRndUnitDefensiveAbil(Random randomNumber, List<DefensiveAbilities> allDefense);
        Task<EnduranceAbilities> GetRndUnitEnduranceAbil(Random randomNumber, List<EnduranceAbilities> allEndurance);
        Task<MeleeWeapon> GetRndUnitMeleeWeap(Random randomNumber, List<MeleeWeapon> allMeleeWeapons);
        Task<MentalAbilities> GetRndUnitMentalAbil(Random randomNumber, List<MentalAbilities> allMental);
        Task<RangeWeapon> GetRndUnitRangeWeap(Random randomNumber, List<RangeWeapon> allRangeWeapons);
        Task<Shield> GetRndUnitShield(Random randomNumber, List<Shield> allShields);
        Task<string> GenUnitName(Unit newUnit);
        Task<List<Unit>> GenRndUnits(int count, List<UnitType> allTypes, List<RangeWeapon> allRangeWeapons, List<MeleeWeapon> allMeleeWeapons, List<Shield> allShields, List<MentalAbilities> allMental, List<DefensiveAbilities> allDefense, List<EnduranceAbilities> allEndurance);
        Task<UnitType> GetRndUnitType(Random randomNumber, List<UnitType> allTypes);
        Task<int> GetRndDefenseValue(Random randomNumber, DefensiveAbilities defOfUnit);
        Task<int> GetRndEnduranceValue(Random randomNumber, EnduranceAbilities endOfUnit);
        Task<int> GetRndMentalValue(Random randomNumber, MentalAbilities mentOfUnit);
        Task<int> GetRndSpeedValue(Random randomNumber, UnitType typeOfUnit);
    }
}