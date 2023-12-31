﻿using EyeOfGods.Models.MapModels;

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
            GodFrendly = true;
        }
    }
}