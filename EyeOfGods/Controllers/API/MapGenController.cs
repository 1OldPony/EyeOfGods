using EyeOfGods.Models;
using EyeOfGods.Models.MapModels;
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
        public async Task<Map> GenMap(int schemeId, int optionsId)
        {
            var scheme = await _context.MapSchemes.FindAsync(schemeId);
            var terrOpt = await _context.TerrainOptions.FindAsync(optionsId);

            //MapGenerator gen = new(_logger);
            var map = _gen.GenerateMap(scheme, terrOpt);

            return map;
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
