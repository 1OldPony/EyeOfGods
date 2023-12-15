using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators
{
    public class WaterCreator : TerrCreator
    {
        public WaterCreator(MapSchemePoint point, List<Rectangle> forbidPos, MapScheme scheme) : base(point, forbidPos, scheme) { }

        public override Terrain Create()
        {
            Random rnd = new Random();

            Water water = new(_point.PointNumber);

            List<Rectangle> finPossPos = /*await*/ GenPossiblePositions(water);

            if (finPossPos.Count != 0)
            {
                Rectangle finalPos = finPossPos.ElementAt(rnd.Next(0, finPossPos.Count));
                water.XCoordinate = finalPos.X;
                water.YCoordinate = finalPos.Y;
                return water;
            }
            else
            {
                return null;
            }
        }
    }
}
