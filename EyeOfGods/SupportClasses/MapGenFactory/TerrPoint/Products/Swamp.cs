using EyeOfGods.Models.MapModels;

namespace EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products
{
    public class Swamp : Terrain
    {
        public Swamp(int refPoint)
        {
            Type = TerrainTypes.Болото;
            Description = "+2 к броне в ближнем бою";

            ReferenceTo = refPoint;
            PointWidth = 2;
            PointHeight = 2;
            GodFrendly = true;
        }
    }
}
