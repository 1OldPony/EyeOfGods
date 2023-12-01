using EyeOfGods.Models.MapModels;

namespace EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products
{
    public class Forest : Terrain
    {
        public Forest(int refPoint) {
            Type = TerrainTypes.Лес;
            Description = "+2 к броне в ближнем бою и от стрельбы";

            ReferenceTo = refPoint;
            PointWidth = 2;
            PointHeight = 2;
        }
    }
}

//public int Id { get; set; }
//public TerrainTypes Type { get; set; }
//public string Description { get; set; }
//public bool GodToken { get; set; }


//public int PointNumber { get; set; }
//public int PointHeight { get; set; }
//public int PointWidth { get; set; }
//public int? ReferenceTo { get; set; }