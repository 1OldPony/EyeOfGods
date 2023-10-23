using EyeOfGods.Context;
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
    public class PagesController : Controller
    {
        private readonly MyWargameContext _context;

        public PagesController(MyWargameContext context) {
            _context = context;
        }

        public async Task<IActionResult> Seed()
        {
            List<UnitType> allTypes = _context.UnitTypes.ToList();
            List<UnitOrder> allOrders = _context.UnitOrders.ToList();
            List<RangeWeapon> allRangeWeapons = _context.RangeWeapons.ToList();
            List<RangeWeaponsType> allRangeWeaponTypes = _context.RangeWeaponsTypes.ToList();

            Random randomNumber = new();


            foreach (var unitType in allTypes)
            {
                if (unitType.UnitTypeOrders == null)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        unitType.UnitTypeOrders.Add(allOrders.ElementAt(randomNumber.Next(0, allOrders.Count - 1)));
                    };
                    _context.UnitTypes.Update(unitType);
                }
            };

            foreach (var rangeWeapon in allRangeWeapons)
            {
                if (rangeWeapon.RangeWeaponsType == null)
                {
                    rangeWeapon.RangeWeaponsType = allRangeWeaponTypes.ElementAt(randomNumber.Next(0, allRangeWeaponTypes.Count - 1));
                    rangeWeapon.RWName = rangeWeapon.RangeWeaponsType.RWTypeName;
                }
                _context.RangeWeapons.Update(rangeWeapon);
            };
            await _context.SaveChangesAsync();

            return RedirectToAction("Start");
        }

        public async Task<IActionResult> Start()
        {
            /////////////////////////////////////////////////////
            ///ТЕПЕРЬ ДЕЛАЕМ ТРАНИЦУ СТАТИСТИКИ И ВЫЗЫВАЕМ ОТТУДА API ВЕРСИЮ СБОРА СТАТИСТИКИ
            /////////////////////////////////////////////////////



            List<Unit> allUnits = await _context.Units.ToListAsync();

            StatisticsViewModel statistics = new();

            foreach (var unit in allUnits)
            {
                statistics.UnitsCount++;

                switch (unit.UnitType.UnitTypeName)
                {
                    case "Пехота":
                        statistics.InfantryCount++;
                        break;
                    case "Кавалерия":
                        statistics.CavaleryCount++;
                        break;
                    case "Монстры":
                        statistics.MonsterCount++;
                        break;
                    case "Гиганты":
                        statistics.GiantsCount++;
                        break;
                    case "Артиллерия":
                        statistics.ArtilleryCount++;
                        break;
                    case "Техника":
                        statistics.VenicleCount++;
                        break;
                    case "Авиация":
                        statistics.AviationCount++;
                        break;
                    default:
                        break;
                }


                //учитываем защитные характеристики
                if (statistics.DefenceChars.Count == 0)
                {
                    statistics.DefenceChars.Add(new DefenceChars() { CharacteristicName = unit.DefensiveAbilities.CharacteristicName, UsageCount = 1 });

                }
                else
                {
                    if (!statistics.DefenceChars.Any(x => x.CharacteristicName == unit.DefensiveAbilities.CharacteristicName))
                    {
                        statistics.DefenceChars.Add(new DefenceChars() { CharacteristicName = unit.DefensiveAbilities.CharacteristicName, UsageCount = 1 });
                    }
                    else
                    {
                        statistics.DefenceChars.First(x => x.CharacteristicName == unit.DefensiveAbilities.CharacteristicName).UsageCount++;
                    }
                }

                //учитываем характеристики выносливости
                if (statistics.EnduranceChars.Count == 0)
                {
                    statistics.EnduranceChars.Add(new EnduranceChars() { CharacteristicName = unit.EnduranceAbilities.CharacteristicName, UsageCount = 1 });
                }
                else
                {
                    if (!statistics.EnduranceChars.Any(x => x.CharacteristicName == unit.EnduranceAbilities.CharacteristicName))
                    {
                        statistics.EnduranceChars.Add(new EnduranceChars() { CharacteristicName = unit.EnduranceAbilities.CharacteristicName, UsageCount = 1 });
                    }
                    else
                    {
                        statistics.EnduranceChars.First(x => x.CharacteristicName == unit.EnduranceAbilities.CharacteristicName).UsageCount++;
                    }
                }

                //учитываем ментальные характеристики
                if (statistics.MentalChars.Count == 0)
                {
                    statistics.MentalChars.Add(new MentalChars() { CharacteristicName = unit.MentalAbilities.CharacteristicName, UsageCount = 1 });
                }
                else
                {
                    if (!statistics.MentalChars.Any(x => x.CharacteristicName == unit.MentalAbilities.CharacteristicName))
                    {
                        statistics.MentalChars.Add(new MentalChars() { CharacteristicName = unit.MentalAbilities.CharacteristicName, UsageCount = 1 });
                    }
                    else
                    {
                        statistics.MentalChars.First(x => x.CharacteristicName == unit.MentalAbilities.CharacteristicName).UsageCount++;
                    }
                }

                //учитываем оружие ближнего боя
                foreach (var weapon in unit.MeleeWeapons)
                {
                    statistics.MeleeWeaponsCount++;
                    if (!statistics.MeleeWeaponsTypes.Any(x => x.WeaponStatName == weapon.WeaponType.ToString()))
                    {
                        statistics.MeleeWeaponsTypes.Add(new MeleeWeaponsStat() { WeaponStatName = weapon.WeaponType.ToString(), UsageCount = 1 });
                    }
                    else
                    {
                        statistics.MeleeWeaponsTypes.First(x => x.WeaponStatName == weapon.WeaponType.ToString()).UsageCount++;
                    }
                }

                //учитываем оружие дальнего боя
                if (unit.RangeWeapon != null)
                {
                    statistics.RangeWeaponsCount++;
                    if (!statistics.RangeWeaponsTypes.Any(x => x.WeaponStatName == unit.RangeWeapon.RangeWeaponsType.RWTypeName))
                    {
                        statistics.RangeWeaponsTypes.Add(new RangeWeaponsStat() { WeaponStatName = unit.RangeWeapon.RangeWeaponsType.RWTypeName, UsageCount = 1 });
                    }
                    else
                    {
                        statistics.RangeWeaponsTypes.First(x => x.WeaponStatName == unit.RangeWeapon.RangeWeaponsType.RWTypeName).UsageCount++;
                    }
                }

                //учитываем щиты
                if (unit.Shield != null)
                {
                    statistics.ShieldsCount++;
                }
            }
            return View(statistics);
            //return View();
        }

        public IActionResult Units()
        {
            List<Unit> units = _context.Units.ToList();

            return View();
        }
        public IActionResult MapGenerator()
        {
            return View();
        }

        public IActionResult Balance()
        {
            return View();
        }
        public IActionResult UserProfile()
        {
            return View();
        }

    }
}
