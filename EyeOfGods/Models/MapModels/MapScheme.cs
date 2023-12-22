using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyeOfGods.Models.MapModels
{
    public class MapScheme
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int NumbOfCities { get; set; }
        public int NumbOfResources { get; set; }
        public int NumbOfTreasuries { get; set; }
        public int MaxDensityAvail { get; set; }
        public int GodPresense { get; set; }


        public int MapHeight{ get; set; }
        public int MapWidth { get; set; }


        public List<MapSchemePoint> Points { get; set; }

        //public List<TerrainOptions> TerrainOptions { get; set; }

        public List<Map> Maps { get; set; } = new();
    }
}
