using EyeOfGods.Models;
using EyeOfGods.Models.ViewModels;
using EyeOfGods.SupportClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Controllers
{
    [Route("api/GensAndStat")]
    [ApiController]
    public class GensAndStat : ControllerBase
    {
        private readonly MyWargameContext _context;
        private readonly IUnitGenerator _unitGen;
        private readonly IStatistics _statistics;
        public GensAndStat(MyWargameContext context, IUnitGenerator unitGen, IStatistics statistics)
        {
            _context = context;
            _unitGen = unitGen;
            _statistics = statistics;
        }

        [HttpPost("GenRndUnit")]
        public async Task<IActionResult> GenerateRndUnits(int count)
        {
            List<UnitType> allTypes = await _context.UnitTypes.ToListAsync();
            List<RangeWeapon> allRangeWeapons = await _context.RangeWeapons.ToListAsync();
            List<MeleeWeapon> allMeleeWeapons = await _context.MeleeWeapons.ToListAsync();
            List<Shield> allShields = await _context.Shields.ToListAsync();
            List<MentalAbilities> allMental = await _context.MentalAbilities.ToListAsync();
            List<DefensiveAbilities> allDefense = await _context.DefensiveAbilities.ToListAsync();
            List<EnduranceAbilities> allEndurance = await _context.EnduranceAbilities.ToListAsync();

            List<Unit> allUnits = await _unitGen.GenRndUnits(count, allTypes, allRangeWeapons, allMeleeWeapons, allShields, allMental, allDefense, allEndurance);

            await _context.Units.AddRangeAsync(allUnits);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("ClearUnits")]
        public async Task<IActionResult> DeleteAllUnits()
        {
            List<Unit> allUnits = await _context.Units.ToListAsync();
            
            _context.Units.RemoveRange(allUnits);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("GetUnitsStat")]
        public async Task<StatisticsViewModel> GetUnitsStat()
        {
            List<Unit> units = new();
            try
            {
                units = _context.Units.ToList();
                //units = await _context.Units.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось создать лист юнитов: {ex}");
            }

            try
            {
                StatisticsViewModel stat = await _statistics.GetUnitsStatistics(units);
                return stat;
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось запустить GetUnitsStatistics: {ex}");
            }
        }

































        //[HttpGet]
        //public async Task<IActionResult> Getstatistics() 
        //{
        //    List<UnitType> allTypes = await _context.UnitTypes.ToListAsync();
        //    List<UnitOrder> allOrders = await _context.UnitOrders.ToListAsync();
        //    List<RangeWeapon> allRangeWeapons = await _context.RangeWeapons.ToListAsync();
        //    List<MeleeWeapon> allMeleeWeapons = await _context.MeleeWeapons.ToListAsync();
        //    List<Shield> allShields = await _context.Shields.ToListAsync();
        //    List<RangeWeaponsType> allRangeWeaponTypes = await _context.RangeWeaponsTypes.ToListAsync();
        //    List<Unit> allUnits = await _context.Units.ToListAsync();
        //    List<MentalAbilities> allMental = await _context.MentalAbilities.ToListAsync();
        //    List<DefensiveAbilities> allDefense = await _context.DefensiveAbilities.ToListAsync();
        //    List<EnduranceAbilities> allEndurance = await _context.EnduranceAbilities.ToListAsync();

        //    allUnits = await DbCheck(allTypes, allOrders, allRangeWeapons, allMeleeWeapons, allShields,
        //        allRangeWeaponTypes, allUnits, allMental, allDefense, allEndurance);

        //    StatisticsViewModel statistics = new();

        //    foreach (var unit in allUnits)
        //    {
        //        statistics.UnitsCount++;

        //        switch (unit.UnitType.UnitTypeName)
        //        {
        //            case "Пехота":
        //                statistics.InfantryCount++;
        //                break;
        //            case "Кавалерия":
        //                statistics.CavaleryCount++;
        //                break;
        //            case "Монстры":
        //                statistics.MonsterCount++;
        //                break;
        //            case "Гиганты":
        //                statistics.GiantsCount++;
        //                break;
        //            case "Артиллерия":
        //                statistics.ArtilleryCount++;
        //                break;
        //            case "Техника":
        //                statistics.VenicleCount++;
        //                break;
        //            case "Авиация":
        //                statistics.AviationCount++;
        //                break;
        //            default:
        //                break;
        //        }


        //        //учитываем защитные характеристики
        //        if (statistics.DefenceChars.Count == 0)
        //        {
        //            statistics.DefenceChars.Add(new DefenceChars() { CharacteristicName = unit.DefensiveAbilities.CharacteristicName, UsageCount = 1 });

        //        }
        //        else
        //        {
        //            if (!statistics.DefenceChars.Any(x => x.CharacteristicName == unit.DefensiveAbilities.CharacteristicName))
        //            {
        //                statistics.DefenceChars.Add(new DefenceChars() { CharacteristicName = unit.DefensiveAbilities.CharacteristicName, UsageCount = 1 });
        //            }
        //            else
        //            {
        //                statistics.DefenceChars.First(x => x.CharacteristicName == unit.DefensiveAbilities.CharacteristicName).UsageCount++;
        //            }
        //        }

        //        //учитываем характеристики выносливости
        //        if (statistics.EnduranceChars.Count == 0)
        //        {
        //            statistics.EnduranceChars.Add(new EnduranceChars() { CharacteristicName = unit.EnduranceAbilities.CharacteristicName, UsageCount = 1 });
        //        }
        //        else
        //        {
        //            if (!statistics.EnduranceChars.Any(x => x.CharacteristicName == unit.EnduranceAbilities.CharacteristicName))
        //            {
        //                statistics.EnduranceChars.Add(new EnduranceChars() { CharacteristicName = unit.EnduranceAbilities.CharacteristicName, UsageCount = 1 });
        //            }
        //            else
        //            {
        //                statistics.EnduranceChars.First(x => x.CharacteristicName == unit.EnduranceAbilities.CharacteristicName).UsageCount++;
        //            }
        //        }

        //        //учитываем ментальные характеристики
        //        if (statistics.MentalChars.Count == 0)
        //        {
        //            statistics.MentalChars.Add(new MentalChars() { CharacteristicName = unit.MentalAbilities.CharacteristicName, UsageCount = 1 });
        //        }
        //        else
        //        {
        //            if (!statistics.MentalChars.Any(x => x.CharacteristicName == unit.MentalAbilities.CharacteristicName))
        //            {
        //                statistics.MentalChars.Add(new MentalChars() { CharacteristicName = unit.MentalAbilities.CharacteristicName, UsageCount = 1 });
        //            }
        //            else
        //            {
        //                statistics.MentalChars.First(x => x.CharacteristicName == unit.MentalAbilities.CharacteristicName).UsageCount++;
        //            }
        //        }

        //        //учитываем оружие ближнего боя
        //        foreach (var weapon in unit.MeleeWeapons)
        //        {
        //            statistics.MeleeWeaponsCount++;
        //            if (!statistics.MeleeWeaponsTypes.Any(x => x.WeaponStatName == weapon.WeaponType.ToString()))
        //            {
        //                statistics.MeleeWeaponsTypes.Add(new MeleeWeaponsStat() { WeaponStatName = weapon.WeaponType.ToString(), UsageCount = 1 });
        //            }
        //            else
        //            {
        //                statistics.MeleeWeaponsTypes.First(x => x.WeaponStatName == weapon.WeaponType.ToString()).UsageCount++;
        //            }
        //        }

        //        //учитываем оружие дальнего боя
        //        if (unit.RangeWeapon != null)
        //        {
        //            statistics.RangeWeaponsCount++;
        //            if (!statistics.RangeWeaponsTypes.Any(x => x.WeaponStatName == unit.RangeWeapon.RangeWeaponsType.RWTypeName))
        //            {
        //                statistics.RangeWeaponsTypes.Add(new RangeWeaponsStat() { WeaponStatName = unit.RangeWeapon.RangeWeaponsType.RWTypeName, UsageCount = 1 });
        //            }
        //            else
        //            {
        //                statistics.RangeWeaponsTypes.First(x => x.WeaponStatName == unit.RangeWeapon.RangeWeaponsType.RWTypeName).UsageCount++;
        //            }
        //        }

        //        //учитываем щиты
        //        if (unit.Shield != null)
        //        {
        //            statistics.ShieldsCount++;
        //        }
        //    }
        //    //return Results.Json();
        //    return Ok(statistics);
        //}













        //public async void GenUnits(int count)
        //{
        //    Random randomNumber = new();
        //    List<Unit> allUnits = new();

        //    for (int i = 0; i <= count; i++)
        //    {
        //        Unit newUnit = new();

        //        //НАЗНАЧАЕМ ОРУЖИЕ, ЩИТЫ, ТИПЫ ОСНОВНЫХ ХАРАКТЕРИСТИК И РОД ВОЙСК
        //        newUnit.MentalAbilities = await GenMentalAbil(randomNumber);
        //        newUnit.DefensiveAbilities = await GenDefensiveAbil(randomNumber);
        //        newUnit.EnduranceAbilities = await GenEnduranceAbil(randomNumber);
        //        newUnit.MeleeWeapons.Add(await GenMeleeWeap(randomNumber));
        //        if (LittleHelper.UnitEquipRandomAssigment(newUnit, "RangeWeapon", 30.0))
        //        {
        //            newUnit.RangeWeapon = await GenRangeWeap(randomNumber);
        //        }
        //        if (LittleHelper.UnitEquipRandomAssigment(newUnit, "Shield", 50.0))
        //        {
        //            newUnit.Shield = await GenShield(randomNumber);
        //        }
        //        newUnit.UnitType = await GenUnitType(randomNumber);

        //        //НАЗНАЧАЕМ ЦИФЕРНЫЕ ХАРАКТЕРИСТИКИ - СКОРОСТЬ И 3 ОСНОВНЫЕ
        //        while (newUnit.Speed % 2 != 0 && newUnit.Speed != 0)
        //        {
        //            newUnit.Speed = await GetSpeed(randomNumber, newUnit.UnitType);
        //        }

        //        while (newUnit.Defense % newUnit.DefensiveAbilities.Step != 0 && newUnit.Defense != 0)
        //        {
        //            newUnit.Defense = await GetDefense(randomNumber, newUnit.DefensiveAbilities);
        //        }

        //        while (newUnit.Endurance % newUnit.EnduranceAbilities.Step != 0 && newUnit.Endurance != 0)
        //        {
        //            newUnit.Endurance = await GetEndurance(randomNumber, newUnit.EnduranceAbilities);
        //        }

        //        while (newUnit.Mental % newUnit.MentalAbilities.Step != 0 && newUnit.Mental != 0)
        //        {
        //            newUnit.Mental = await GetMental(randomNumber, newUnit.MentalAbilities);
        //        }

        //        newUnit.UnitName = await GenUnitName(newUnit);

        //        allUnits.Add(newUnit);
        //    }

        //    await _context.Units.AddRangeAsync(allUnits);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<MentalAbilities> GenMentalAbil(Random randomNumber)
        //{
        //    List<MentalAbilities> allMental = await _context.MentalAbilities.ToListAsync();

        //    MentalAbilities newAbility = allMental.ElementAt(randomNumber.Next(0, allMental.Count));

        //    return newAbility;
        //}
        //public async Task<DefensiveAbilities> GenDefensiveAbil(Random randomNumber)
        //{
        //    List<DefensiveAbilities> allDefense = await _context.DefensiveAbilities.ToListAsync();

        //    DefensiveAbilities newAbility = allDefense.ElementAt(randomNumber.Next(0, allDefense.Count));

        //    return newAbility;
        //}
        //public async Task<EnduranceAbilities> GenEnduranceAbil(Random randomNumber)
        //{
        //    List<EnduranceAbilities> allEndurance = await _context.EnduranceAbilities.ToListAsync();

        //    EnduranceAbilities newAbility = allEndurance.ElementAt(randomNumber.Next(0, allEndurance.Count));

        //    return newAbility;
        //}
        //public async Task<MeleeWeapon> GenMeleeWeap(Random randomNumber)
        //{
        //    List<MeleeWeapon> allMeleeWeapons = await _context.MeleeWeapons.ToListAsync();

        //    MeleeWeapon newWeapon = allMeleeWeapons.ElementAt(randomNumber.Next(0, allMeleeWeapons.Count));

        //    return newWeapon;
        //}
        //public async Task<RangeWeapon> GenRangeWeap(Random randomNumber)
        //{
        //    List<RangeWeapon> allRangeWeapons = await _context.RangeWeapons.ToListAsync();

        //    RangeWeapon newWeapon = allRangeWeapons.ElementAt(randomNumber.Next(0, allRangeWeapons.Count));

        //    return newWeapon;
        //}
        //public async Task<Shield> GenShield(Random randomNumber)
        //{
        //    List<Shield> allShields = await _context.Shields.ToListAsync();

        //    Shield newShield = allShields.ElementAt(randomNumber.Next(0, allShields.Count));

        //    return newShield;
        //}
        //public async Task<UnitType> GenUnitType(Random randomNumber)
        //{
        //    List<UnitType> allTypes = await _context.UnitTypes.ToListAsync();

        //    UnitType newType = allTypes.ElementAt(randomNumber.Next(0, allTypes.Count));

        //    return newType;
        //}
        //public Task<string> GenUnitName(Unit newUnit)
        //{
        //    string unitName;
        //    if (newUnit.Defense < newUnit.DefensiveAbilities.NoDoubleActionAt)
        //        unitName = "Легк.";
        //    else
        //        unitName = "Тяж.";

        //    unitName = string.Concat(unitName, " ", newUnit.UnitType.UnitTypeName);

        //    int unitMeleeWeapon = 1;
        //    foreach (var item in newUnit.MeleeWeapons)
        //    {
        //        if (unitMeleeWeapon == 1)
        //        {
        //            unitName = string.Concat(unitName, " c ", item.MWName);
        //            unitMeleeWeapon++;
        //        }
        //        else
        //            unitName = string.Concat(unitName, " и ", item.MWName);
        //    }

        //    return Task.FromResult(unitName);
        //}
        //public Task<int> GetSpeed(Random randomNumber, UnitType typeOfUnit) => Task.FromResult(randomNumber.Next(typeOfUnit.MinSpeed, typeOfUnit.MaxSpeed + 1));
        //public Task<int> GetDefense(Random randomNumber, DefensiveAbilities defOfUnit) => Task.FromResult(randomNumber.Next(defOfUnit.MinValue, defOfUnit.MaxValue + 1));
        //public Task<int> GetEndurance(Random randomNumber, EnduranceAbilities endOfUnit) => Task.FromResult(randomNumber.Next(endOfUnit.MinValue, endOfUnit.MaxValue + 1));
        //public Task<int> GetMental(Random randomNumber, MentalAbilities mentOfUnit) => Task.FromResult(randomNumber.Next(mentOfUnit.MinValue, mentOfUnit.MaxValue + 1));







        //public async Task<List<Unit>> DbCheck(List<UnitType> allTypes, List<UnitOrder> allOrders, List<RangeWeapon> allRangeWeapons,
        //     List<MeleeWeapon> allMeleeWeapons, List<Shield> allShields, List<RangeWeaponsType> allRangeWeaponTypes,
        //     List<Unit> allUnits, List<MentalAbilities> allMental, List<DefensiveAbilities> allDefense, List<EnduranceAbilities> allEndurance)
        //{
        //    /////////////////////////////////////////////////////////////
        //    ///ТУТ НУЖНЫ ИМЕННО ГЕНЕРАТОРЫ СТРЕЛКОВОГО И ЮНИТОВ
        //    /////////////////////////////////////////////////////////////

        //    //List<UnitType> allTypes = _context.UnitTypes.ToList();
        //    //List<UnitOrder> allOrders = _context.UnitOrders.ToList();
        //    //List<RangeWeapon> allRangeWeapons = _context.RangeWeapons.ToList();
        //    //List<MeleeWeapon> allMeleeWeapons = _context.MeleeWeapons.ToList();
        //    //List<Shield> allShields = _context.Shields.ToList();
        //    //List<RangeWeaponsType> allRangeWeaponTypes = _context.RangeWeaponsTypes.ToList();
        //    //List<Unit> allUnits = _context.Units.ToList();
        //    //List<MentalAbilities> allMental = _context.MentalAbilities.ToList();
        //    //List<DefensiveAbilities> allDefense = _context.DefensiveAbilities.ToList();
        //    //List<EnduranceAbilities> allEndurance = _context.EnduranceAbilities.ToList();

        //    Random randomNumber = new();


        //    foreach (var unitType in allTypes)
        //    {
        //        if (unitType.UnitTypeOrders == null)
        //        {
        //            for (int i = 0; i < 2; i++)
        //            {
        //                unitType.UnitTypeOrders.Add(allOrders.ElementAt(randomNumber.Next(0, allOrders.Count - 1)));
        //            };
        //            _context.UnitTypes.Update(unitType);
        //        }
        //    };

        //    foreach (var rangeWeapon in allRangeWeapons)
        //    {
        //        if (rangeWeapon.RangeWeaponsType == null)
        //        {
        //            rangeWeapon.RangeWeaponsType = allRangeWeaponTypes.ElementAt(randomNumber.Next(0, allRangeWeaponTypes.Count - 1));
        //            rangeWeapon.RWName = rangeWeapon.RangeWeaponsType.RWTypeName;
        //        }

        //        if (rangeWeapon.RangeOfShooting == 0)
        //        {
        //            while (rangeWeapon.RangeOfShooting % rangeWeapon.RangeWeaponsType.DistanceStep != 0)
        //            {
        //                rangeWeapon.RangeOfShooting = randomNumber.Next(rangeWeapon.RangeWeaponsType.MinDistance, rangeWeapon.RangeWeaponsType.MaxDistance);
        //            }
        //        }
        //        _context.RangeWeapons.Update(rangeWeapon);
        //    };


        //    if (allUnits.Count == 0)
        //    {
        //        for (int i = 0; i < 5; i++)
        //        {
        //            Unit unit = new();

        //            unit.MentalAbilities = allMental.ElementAt(randomNumber.Next(0, allMental.Count));
        //            unit.DefensiveAbilities = allDefense.ElementAt(randomNumber.Next(0, allDefense.Count));
        //            unit.EnduranceAbilities = allEndurance.ElementAt(randomNumber.Next(0, allEndurance.Count));
        //            unit.MeleeWeapons.Add(allMeleeWeapons.ElementAt(randomNumber.Next(0, allMeleeWeapons.Count)));
        //            if (LittleHelper.UnitEquipRandomAssigment(unit, "RangeWeapon", 30.0))
        //            {
        //                unit.RangeWeapon = allRangeWeapons.ElementAt(randomNumber.Next(0, allRangeWeapons.Count));
        //            }
        //            if (LittleHelper.UnitEquipRandomAssigment(unit, "Shield", 50.0))
        //            {
        //                unit.Shield = allShields.ElementAt(randomNumber.Next(0, allShields.Count));
        //            }
        //            unit.UnitType = allTypes.ElementAt(randomNumber.Next(0, allTypes.Count));


        //            while (unit.Speed % 2 != 0 && unit.Speed != 0)
        //            {
        //                unit.Speed = randomNumber.Next(unit.UnitType.MinSpeed, unit.UnitType.MaxSpeed + 1);
        //            }

        //            while (unit.Defense % unit.DefensiveAbilities.Step != 0 && unit.Defense != 0)
        //            {
        //                unit.Defense = randomNumber.Next(unit.DefensiveAbilities.MinValue, unit.DefensiveAbilities.MaxValue + 1);
        //            }

        //            while (unit.Endurance % unit.EnduranceAbilities.Step != 0 && unit.Endurance != 0)
        //            {
        //                unit.Endurance = randomNumber.Next(unit.EnduranceAbilities.MinValue, unit.EnduranceAbilities.MaxValue + 1);
        //            }

        //            while (unit.Mental % unit.MentalAbilities.Step != 0 && unit.Mental != 0)
        //            {
        //                unit.Mental = randomNumber.Next(unit.MentalAbilities.MinValue, unit.MentalAbilities.MaxValue + 1);
        //            }


        //            /////////ГЕНЕРАТОР НАЗВАНИЯ ОТРЯДА
        //            if (unit.Defense < unit.DefensiveAbilities.NoDoubleActionAt)
        //                unit.UnitName = "Легк.";
        //            else
        //                unit.UnitName = "Тяж.";

        //            unit.UnitName = string.Concat(unit.UnitName, " ", unit.UnitType.UnitTypeName);

        //            int unitMeleeWeapon = 1;
        //            foreach (var item in unit.MeleeWeapons)
        //            {
        //                if (unitMeleeWeapon == 1)
        //                    unit.UnitName = string.Concat(unit.UnitName, " c ", item.MWName);
        //                else
        //                    unit.UnitName = string.Concat(unit.UnitName, " и ", item.MWName);
        //            }

        //            allUnits.Add(unit);
        //        }
        //        await _context.Units.AddRangeAsync(allUnits);
        //    }
        //    else
        //    {
        //        foreach (var unit in allUnits)
        //        {
        //            if (unit.MeleeWeapons.Count == 0)
        //            {
        //                unit.MeleeWeapons.Add(allMeleeWeapons.ElementAt(randomNumber.Next(0, allMeleeWeapons.Count)));
        //            }

        //            if (unit.RangeWeapon == null)
        //            {
        //                if (LittleHelper.UnitEquipRandomAssigment(unit, "RangeWeapon", 30.0))
        //                {
        //                    unit.RangeWeapon = allRangeWeapons.ElementAt(randomNumber.Next(0, allRangeWeapons.Count));
        //                }
        //            }

        //            if (unit.MentalAbilities == null)
        //            {
        //                unit.MentalAbilities = allMental.ElementAt(randomNumber.Next(0, allMental.Count));
        //            }

        //            if (unit.DefensiveAbilities == null)
        //            {
        //                unit.DefensiveAbilities = allDefense.ElementAt(randomNumber.Next(0, allDefense.Count));
        //            }

        //            if (unit.EnduranceAbilities == null)
        //            {
        //                unit.EnduranceAbilities = allEndurance.ElementAt(randomNumber.Next(0, allEndurance.Count));
        //            }

        //            if (unit.Shield == null)
        //            {
        //                if (LittleHelper.UnitEquipRandomAssigment(unit, "Shield", 50.0))
        //                {
        //                    unit.Shield = allShields.ElementAt(randomNumber.Next(0, allShields.Count));
        //                }
        //            }

        //            if (unit.UnitType == null)
        //            {
        //                unit.UnitType = allTypes.ElementAt(randomNumber.Next(0, allTypes.Count));
        //            }

        //            _context.Units.Update(unit);
        //        }
        //    }
        //    _context.SaveChanges();

        //    //return RedirectToAction("Start", allUnits);
        //    //Start(allUnits);
        //    return allUnits;
        //}
    }
}
