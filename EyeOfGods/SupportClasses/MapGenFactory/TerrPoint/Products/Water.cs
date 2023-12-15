using EyeOfGods.Models.MapModels;
using System;

namespace EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products
{
    public class Water : Terrain
    {
        public Water(int refPoint)
        {
            Type = TerrainTypes.Вода;
            Description = "Невозможно занять";

            ReferenceTo = refPoint;
            PointWidth = 2;
            PointHeight = 2;
            GodFrendly = false;
        }
    }
}
