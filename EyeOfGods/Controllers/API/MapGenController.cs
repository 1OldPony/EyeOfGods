using EyeOfGods.Models;
using EyeOfGods.Models.MapModels;
using EyeOfGods.Models.ViewModels;
using EyeOfGods.SupportClasses.MapGenFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

            //MapGenerator gen = new(_logger);
            var map = _gen.GenerateMap(scheme, terrOpt, /*(TerrainDensity)*/terrDensity, /*(QuestLevel)*/qLevel);

            return map;
        }

        [HttpPost("SaveMap")]
        public async Task<IActionResult> SaveMap([FromBody] SaveMapForm mapForm)
        {

            List<Terrain> terrain = new();
            foreach (var ter in mapForm.Terrains)
            {
                Terrain newTerr = new()
                {
                    XCoordinate = ter.yCoordinate,
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

            List<InterestPoint> intPoints = new();
            foreach (var intP in mapForm.InterestPoints)
            {
                InterestPoint newPoint = new()
                {
                    XCoordinate = intP.yCoordinate,
                    YCoordinate = intP.yCoordinate,
                    PointHeight = intP.pointHeight,
                    PointWidth = intP.pointWidth,
                    Description = intP.description,
                    PareWhithPoint = intP.pareWhithPoint,
                    Type = (InterestPointsTypes)intP.pointType
                };
                intPoints.Add(newPoint);
            }

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

            await _context.Maps.AddAsync(map);
            await _context.SaveChangesAsync();

            return Ok();
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
