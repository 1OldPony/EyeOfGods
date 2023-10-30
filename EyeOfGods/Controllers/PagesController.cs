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
