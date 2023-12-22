using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators
{
    public class ForestCreator : TerrCreator
    {
        public ForestCreator(InterestPoint point, List<Rectangle> forbidPos, MapScheme scheme) : base(point, forbidPos, scheme) { }

        public override Terrain Create()
        {
            Random rnd = new Random();

            Forest forest = new(_point.PointNumber);

            List<Rectangle> finPossPos = /*await вот тут может быть Task.Run?*/CalcPossiblePositions(forest);

            if (finPossPos.Count != 0)
            {
                //int index = rnd.Next(0, finPossPos.Count);

                //List<bool> intersects = new();
                //foreach (var item in _forbidPos)
                //{
                //    intersects.Add(finPossPos.ElementAt(index).IntersectsWith(item));
                //}
                //bool inter = intersects.Any(s=>s == true); // true - значит выбранный элемент пересекается с forbidPos, выборка не сработала


                //Rectangle finalPos = finPossPos.ElementAt(index);

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
