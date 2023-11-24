using Castle.Core.Logging;
using EyeOfGods.Context;
using EyeOfGods.Logger;
using EyeOfGods.Models;
using EyeOfGods.Models.MapModels;
using EyeOfGods.Models.ViewModels;
using EyeOfGods.SupportClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Controllers
{
    public class PagesController : Controller
    {
        private readonly MyWargameContext _context;
        private readonly /*EyeOfGodsFileLogger*/ILogger<PagesController> _logger;

        public PagesController(MyWargameContext context, /*EyeOfGodsFileLogger*/ ILogger<PagesController> logger) {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Seed()
        {

            List<UnitType> allTypes = new();
            List<UnitOrder> allOrders = new();
            List<RangeWeapon> allRangeWeapons = new();
            List<RangeWeaponsType> allRangeWeaponTypes = new();
            List<MapScheme> allMapSchemes = new();

            try
            {
                allTypes = _context.UnitTypes.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Не удалось получить список типов юнитов");
            }
            try
            {
                allOrders = _context.UnitOrders.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Не удалось получить список приказов");
            }
            try
            {
                allRangeWeapons = _context.RangeWeapons.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Не удалось получить список оружия даль. боя");
            }
            try
            {
                allRangeWeaponTypes = _context.RangeWeaponsTypes.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Не удалось получить список типов оружия даль. боя");
            }
            try
            {
                allMapSchemes = _context.MapSchemes.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Не удалось получить список схем карт");
            }

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
                }
                _context.RangeWeapons.Update(rangeWeapon);
            };

            if (allMapSchemes.Count == 0)
            {
                SeedData seedData = new();
                MapScheme scheme = seedData.mapSchemes[0];
                scheme.Points = seedData.mapSchemePoints;

                _context.MapSchemes.Add(scheme);
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Не удалось сохранить даннные");
            }

            return RedirectToAction("Start");
        }

        public IActionResult Start()
        {
            return View();
        }
    }
}
