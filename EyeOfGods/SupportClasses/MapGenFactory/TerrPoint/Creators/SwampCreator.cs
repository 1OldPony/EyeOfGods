using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Linq;

namespace EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators
{
    public class SwampCreator : TerrCreator
    {
        public SwampCreator(MapSchemePoint point, List<Rectangle> forbidPos, MapScheme scheme) : base(point, forbidPos, scheme){}

        public override Terrain Create()
        {
            Random rnd = new Random();

            Swamp swamp = new(_point.PointNumber);

            List<Rectangle> finPossPos = GenPossiblePositions(swamp);

            if (finPossPos.Count != 0)
            {
                Rectangle finalPos = finPossPos.ElementAt(rnd.Next(0, finPossPos.Count));
                swamp.XCoordinate = finalPos.X;
                swamp.YCoordinate = finalPos.Y;
                return swamp;
            }
            else
            {
                return null;
            }
        }
    }
}
