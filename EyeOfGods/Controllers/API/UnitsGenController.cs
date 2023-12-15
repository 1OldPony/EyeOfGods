using EyeOfGods.Models;
using EyeOfGods.SupportClasses.UniGen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EyeOfGods.Controllers.API
{
    [Route("api/UnitsGen")]
    [ApiController]
    public class UnitsGenController : ControllerBase
    {
        private readonly MyWargameContext _context;
        private readonly IUnitGenerator _unitGen;
        ILogger<UnitsGenController> _logger;
        public UnitsGenController(MyWargameContext context, IUnitGenerator unitGen, ILogger<UnitsGenController> logger)
        {
            _context = context;
            _unitGen = unitGen;
            _logger = logger;
        }

        [HttpPost("GenRndUnit")]
        public async Task<IActionResult> GenerateRndUnits(int count)
        {
            _logger.LogWarning("GenRndUnit запущен");

            List<UnitType> allTypes = await _context.UnitTypes.ToListAsync();
            List<RangeWeapon> allRangeWeapons = await _context.RangeWeapons.ToListAsync();
            List<MeleeWeapon> allMeleeWeapons = await _context.MeleeWeapons.ToListAsync();
            List<Shield> allShields = await _context.Shields.ToListAsync();
            List<MentalAbilities> allMental = await _context.MentalAbilities.ToListAsync();
            List<DefensiveAbilities> allDefense = await _context.DefensiveAbilities.ToListAsync();
            List<EnduranceAbilities> allEndurance = await _context.EnduranceAbilities.ToListAsync();

            List<Unit> allUnits = await _unitGen.GenRndUnits(count, allTypes, allRangeWeapons, allMeleeWeapons,
                allShields, allMental, allDefense, allEndurance);

            await _context.Units.AddRangeAsync(allUnits);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("ClearUnits")]
        public async Task<IActionResult> DeleteAllUnits()
        {
            _logger.LogWarning("GenRndUnit запущен");
            List<Unit> allUnits = await _context.Units.ToListAsync();

            _context.Units.RemoveRange(allUnits);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
