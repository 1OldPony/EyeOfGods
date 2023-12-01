using EyeOfGods.Models;
using EyeOfGods.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EyeOfGods.SupportClasses.StatGen
{
    public interface IStatistics
    {
        Task<List<DefenceChars>> UnitsDefenceCharsCount(List<Unit> allUnits);
        Task<List<EnduranceChars>> UnitsEnduranceCharsCount(List<Unit> allUnits);
        Task<StatisticsViewModel> GetUnitsStatistics(List<Unit> allUnits);
        Task<(List<MeleeWeaponsStat> meleeWeaponsStat, int meleeWeaponsCount)> UnitsMeleeWeaponsCount(List<Unit> allUnits);
        Task<List<MentalChars>> UnitsMentalCharsCount(List<Unit> allUnits);
        Task<(List<RangeWeaponsStat> rangeWeaponsStat, int rangeWeaponsCount)> UnitsRangeWeaponsCount(List<Unit> allUnits);
        Task<int> UnitsShieldsCount(List<Unit> allUnits);
        Task<(int unitsCount, int infantryCount, int cavaleryCount, int monsterCount, int giantsCount, int artilleryCount, int venicleCount, int aviationCount)> UnitsCount(List<Unit> allUnits);
    }
}