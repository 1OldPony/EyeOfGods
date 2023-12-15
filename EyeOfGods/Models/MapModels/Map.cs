using System.Collections.Generic;

namespace EyeOfGods.Models.MapModels
{
    public class Map
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<InterestPoint> InterestPoints { get; set; } = new();
        public List<Terrain> Terrains { get; set; } = new();
        public TerrainOptions TerrainOptions { get; set; }
        public MapScheme Scheme { get; set; }
    }
}
