using EyeOfGods.Context;
using EyeOfGods.Migrations;
using EyeOfGods.Models;
using EyeOfGods.Models.MapModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ILogger<PagesController> _logger;

        public PagesController(MyWargameContext context, ILogger<PagesController> logger) {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Seed()
        {
            List<UnitType> allTypes = await _context.UnitTypes.ToListAsync();
            List<UnitOrder> allOrders = await _context.UnitOrders.ToListAsync();
            List<RangeWeapon> allRangeWeapons = await _context.RangeWeapons.ToListAsync();
            List<RangeWeaponsType> allRangeWeaponTypes = await _context.RangeWeaponsTypes.ToListAsync();
            List<MapScheme> allMapSchemes = await _context.MapSchemes.ToListAsync();

            Random rnd = new();

            foreach (var unitType in allTypes)
            {
                if (unitType.UnitTypeOrders == null)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        unitType.UnitTypeOrders.Add(allOrders.ElementAt(rnd.Next(0, allOrders.Count)));
                    };
                    _context.UnitTypes.Update(unitType);
                }
            };

            foreach (var rangeWeapon in allRangeWeapons)
            {
                if (rangeWeapon.RangeWeaponsType == null)
                {
                    rangeWeapon.RangeWeaponsType = allRangeWeaponTypes.ElementAt(rnd.Next(0, allRangeWeaponTypes.Count));
                }
                _context.RangeWeapons.Update(rangeWeapon);
            };

            foreach (var scheme in allMapSchemes)
            {
                SeedData seedData = new();
                scheme.Points = seedData.mapSchemePoints;

                _context.MapSchemes.Update(scheme);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Не удалось сохранить даннные в seed");
            }

            return RedirectToAction("Statistics");
        }

        public IActionResult Statistics()
        {
            return View();
        }
        public async Task<IActionResult> Map()
        {
            var schemesMaxWidth = await _context.MapSchemes.OrderByDescending(s => s.MapWidth).ToListAsync();
            string value;
            string text;

            List<SelectListItem> sizes = new();
            foreach (var scheme in schemesMaxWidth)
            {
                value = scheme.MapWidth.ToString() + "x" + scheme.MapHeight.ToString();
                text = (scheme.MapWidth * 4).ToString() + "\"" + "x" + (scheme.MapHeight * 4).ToString() + "\"";

                if (!sizes.Any(s => s.Value == value))
                {
                    sizes.Add(new() { Value = value, Text = text });
                }
            }
            ViewBag.MapSizes = sizes;

            return View();
        }
    }
}

