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
                        unitType.UnitTypeOrders.Add(allOrders.ElementAt(randomNumber.Next(0, allOrders.Count)));
                    };
                    _context.UnitTypes.Update(unitType);
                }
            };

            foreach (var rangeWeapon in allRangeWeapons)
            {
                if (rangeWeapon.RangeWeaponsType == null)
                {
                    rangeWeapon.RangeWeaponsType = allRangeWeaponTypes.ElementAt(randomNumber.Next(0, allRangeWeaponTypes.Count));
                    //rangeWeapon.RWName = rangeWeapon.RangeWeaponsType.RWTypeName;
                }
                _context.RangeWeapons.Update(rangeWeapon);
            };
            await _context.SaveChangesAsync();


            //List<UnitType> allTypes = await _context.UnitTypes.ToListAsync();
            //List<RangeWeapon> allRangeWeapons = await _context.RangeWeapons.ToListAsync();
            //UnitGenerator x = new();
            //List<MeleeWeapon> allMeleeWeapons = await _context.MeleeWeapons.ToListAsync();
            //List<Shield> allShields = await _context.Shields.ToListAsync();
            //List<MentalAbilities> allMental = await _context.MentalAbilities.ToListAsync();
            //List<DefensiveAbilities> allDefense = await _context.DefensiveAbilities.ToListAsync();
            //List<EnduranceAbilities> allEndurance = await _context.EnduranceAbilities.ToListAsync();

            //List<Unit> allUnits = await x.GenRndUnits(3, allTypes, allRangeWeapons, allMeleeWeapons, allShields, allMental, allDefense, allEndurance);

            //await _context.Units.AddRangeAsync(allUnits);
            //await _context.SaveChangesAsync();

            return RedirectToAction("Start");
        }

        public async Task<IActionResult> Start()
        {
            Statistics x = new();
            var stat = await x.GetUnitsStatistics(_context.Units.ToListAsync().Result);

            return View(stat);
        }

        //public IActionResult Units()
        //{
        //    List<Unit> units = _context.Units.ToList();

        //    return View();
        //}
        //public IActionResult MapGenerator()
        //{
        //    return View();
        //}

        //public IActionResult Balance()
        //{
        //    return View();
        //}
        //public IActionResult UserProfile()
        //{
        //    return View();
        //}

    }
}
