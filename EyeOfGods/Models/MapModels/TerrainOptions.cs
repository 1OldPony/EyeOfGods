using System.Collections.Generic;

namespace EyeOfGods.Models.MapModels
{
    public class TerrainOptions
    {
        public int Id {  get; set; }
        /// <summary>
        /// А мне не надо, чтоб название сета и было ключем???
        /// </summary>
        public string OptionsSetName { get; set; }
        public TerrainDensity Density { get; set; } = TerrainDensity.Средняя;
        public int ForestDensity { get; set; }
        public int SwampDensity { get; set; }
        public int WaterDensity { get; set; }

        //public List<MapScheme> Schemes { get; set; }
        public List<Map> Maps { get; set; }
    }
}