using System.Collections.Generic;

namespace EyeOfGods.Models.MapModels
{
    public class TerrainOptions
    {
        public int Id {  get; set; }
        public string OptionsSetName { get; set; }
        public int ForestDensity { get; set; }
        public int SwampDensity { get; set; }
        public int WaterDensity { get; set; }

        //public List<MapScheme> Schemes { get; set; }
        public List<Map> Maps { get; set; }
    }
}