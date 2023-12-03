using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators
{
    public class ForestCreator : TerrCreator
    {
        //List<Rectangle> _forbidPos;
        //List<Rectangle> allPossibPos = new();
        //MapScheme _scheme;
        public ForestCreator(MapSchemePoint point, List<Rectangle> forbidPos, MapScheme scheme) : base(point, forbidPos, scheme) { }

        public override Terrain Create()
        {
            Random rnd = new Random();

            Forest forest = new(_point.PointNumber);

            List<Rectangle> finPossPos = GenPossiblePositions(forest);

            if (finPossPos.Count != 0)
            {
                Rectangle finalPos = finPossPos.ElementAt(rnd.Next(0, finPossPos.Count));
                forest.XCoordinate = finalPos.X;
                forest.YCoordinate = finalPos.Y;
                return forest;
            }
            else
            {
                return null;
            }
        }
    }
}
