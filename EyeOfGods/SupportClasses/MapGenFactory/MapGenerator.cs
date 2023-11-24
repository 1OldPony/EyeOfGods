using EyeOfGods.Models.MapModels;

namespace EyeOfGods.SupportClasses.MapGenFactory
{
    public class MapGenerator
    {
        MapScheme _scheme;
        public MapGenerator(MapScheme scheme)
        {
            _scheme = scheme;
        }
    }
}
