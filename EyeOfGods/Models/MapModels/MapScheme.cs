using System.Collections.Generic;

namespace EyeOfGods.Models.MapModels
{
    public class MapScheme
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int NumbOfCities { get; set; }
        public int NumbOfResources { get; set; }
        public int NumbOfTreasuries { get; set; }
        public QuestLevel QuestLevel { get; set; }



        public int MapHeight { get; set; }
        public int MapWidth { get; set; }

        
        public List<MapSchemePoint> Points { get; set; }



        public List<Map> Maps { get; set; } = new();
    }
}
