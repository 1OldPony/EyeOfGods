using EyeOfGods.Models;
using EyeOfGods.Models.MapModels;
using EyeOfGods.Models.ViewModels;
using EyeOfGods.SupportClasses.MapGenFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Controllers.API
{
    [Route("api/MapGen")]
    [ApiController]
    public class MapGenController : ControllerBase
    {
        private readonly MyWargameContext _context;
        private readonly ILogger<MapGenController> _logger;
        private readonly IMapGenerator _gen;
        public MapGenController(MyWargameContext context, ILogger<MapGenController> logger, IMapGenerator gen)
        {
            _context = context;
            _logger = logger;
            _gen = gen;
        }

        [HttpGet("GenMap")]
        public async Task<Map> GenMap(int schemeId, int optionsId, TerrainDensity terrDensity, QuestLevel qLevel)
        {
            var scheme = await _context.MapSchemes.FindAsync(schemeId);
            var terrOpt = await _context.TerrainOptions.FindAsync(optionsId);

            var map = _gen.GenerateMap(scheme, terrOpt, terrDensity, qLevel);

            return map;
        }

        [HttpPost("SaveMap")]
        public async Task<IActionResult> SaveMap([FromBody] MapForm mapForm)
        {
            List<Terrain> terrain = FormTerrList(mapForm.Terrains);
            List<InterestPoint> intPoints = FormIntPointsList(mapForm.InterestPoints);

            var scheme = await _context.MapSchemes.FindAsync(mapForm.SchemeId);
            var terOpt = await _context.TerrainOptions.FindAsync(mapForm.TerrainOptionsId);

            Map map = new() {
                Scheme = scheme,
                TerrainOptions = terOpt,
                Name = mapForm.MapName,
                QuestLevel = (QuestLevel)mapForm.QuestLevel,
                Density = (TerrainDensity)mapForm.Density,
                InterestPoints = intPoints,
                Terrains = terrain
            };
            try
            {
                await _context.Maps.AddAsync(map);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {
                _logger.LogCritical(e, "Не удалось сохранить карту");
                throw new System.Exception($"Не удалось сохранить карту, {e.Message}, {e.StackTrace}");
            }

            return Ok();
        }

        [HttpPost("RegenTerr")]
        public async Task<List<Terrain>> GenTerrain([FromBody] MapForm mapForm)
        {
            Random rnd = new();

            List<InterestPoint> intPoints = FormIntPointsList(mapForm.InterestPoints);

            var scheme = await _context.MapSchemes.FindAsync(mapForm.SchemeId);
            var terOpt = await _context.TerrainOptions.FindAsync(mapForm.TerrainOptionsId);

            var terr = _gen.GenTerrForPoints(intPoints, rnd, terOpt, scheme, (TerrainDensity)mapForm.Density);

            return terr;
        }

        [HttpGet("RegenIntPoints/{schemeId}")]
        public async Task<List<InterestPoint>> GenIntPoints(int schemeId)
        {
            Random rnd = new();
            var scheme = await _context.MapSchemes.FindAsync(schemeId);

            var intP = _gen.GenInterestPoints(scheme, rnd);

            return intP;
        }

        public List<Terrain> FormTerrList(List<Terr> terrains)
        {
            List<Terrain> terrain = new();
            foreach (var ter in terrains)
            {
                Terrain newTerr = new()
                {
                    XCoordinate = ter.xCoordinate,
                    YCoordinate = ter.yCoordinate,
                    PointHeight = ter.pointHeight,
                    PointWidth = ter.pointWidth,
                    Description = ter.description,
                    ReferenceTo = ter.referenceTo,
                    Type = (TerrainTypes)ter.pointType
                };

                if (ter.hasGodToken == "true")
                    newTerr.HasGodToken = true;
                else
                    newTerr.HasGodToken = false;

                terrain.Add(newTerr);
            }
            return terrain;
        }

        public List<InterestPoint> FormIntPointsList(List<IntP> intP)
        {
            List<InterestPoint> intPoints = new();
            foreach (var iP in intP)
            {
                InterestPoint newPoint = new()
                {
                    PointNumber = iP.pointNumber,
                    XCoordinate = iP.xCoordinate,
                    YCoordinate = iP.yCoordinate,
                    PointHeight = iP.pointHeight,
                    PointWidth = iP.pointWidth,
                    Description = iP.description,
                    PareWhithPoint = iP.pareWhithPoint,
                    Type = (InterestPointsTypes)iP.pointType
                };
                intPoints.Add(newPoint);
            }
            return intPoints;
        }

        [HttpGet("GetMapSchemes")]
        public async Task<List<IGrouping<string,MapScheme>>> GetMapSchemes() 
        {
            var schemes = await _context.MapSchemes.GroupBy(s=>s.Name).ToListAsync();
            return schemes;
        }

        [HttpGet("GetMapScheme/{id}")]
        public async Task<MapScheme> GetMapSchemes(int id)
        {
            var schemes = await _context.MapSchemes.FindAsync(id);
            return schemes;
        }

        [HttpGet("GetTerrOptions")]
        public async Task<List<TerrainOptions>> GetTerrOptions()
        {
            var options = await _context.TerrainOptions.ToListAsync();
            return options;
        }

        [HttpGet("GetTerrOption/{id}")]
        public async Task<TerrainOptions> GetTerrOption(int id)
        {
            var option = await _context.TerrainOptions.FindAsync(id);
            return option;
        }
    }
}
