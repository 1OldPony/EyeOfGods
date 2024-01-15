using EyeOfGods.Models;
using EyeOfGods.Models.ViewModels;
using EyeOfGods.SupportClasses.StatGen;
using EyeOfGods.SupportClasses.UniGen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EyeOfGods.Controllers.API
{
    [Route("api/Statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly MyWargameContext _context;
        private readonly IStatistics _statistics;
        private readonly ILogger<StatisticsController> _logger;
        public StatisticsController(MyWargameContext context, IStatistics statistics, ILogger<StatisticsController> logger)
        {
            _context = context;
            _statistics = statistics;
            _logger = logger;
        }

        [HttpGet("GetUnitsStat")]
        public async Task<StatisticsViewModel> GetUnitsStat()
        {
            List<Unit> units = await _context.Units.ToListAsync();

            try
            {
                StatisticsViewModel stat = await _statistics.GetUnitsStatistics(units);
                return stat;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Не удалось запустить GetUnitsStatistics");
                throw new Exception($"Не удалось запустить GetUnitsStatistics: {ex}");
            }
        }
    }
}
