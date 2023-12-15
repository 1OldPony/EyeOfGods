using EyeOfGods.Models.MapModels;
using System.Drawing;

namespace EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Products
{
    public class Resource : InterestPoint
    {
        public Resource(MapSchemePoint point)
        {
            PointHeight = 2;
            PointWidth = 2;
            PointNumber = point.PointNumber;
            PareWhithPoint = point.PareWhithPoint;

            XCoordinate = point.XCoordinate;
            YCoordinate = point.YCoordinate;

            Type = InterestPointsTypes.Ресурсы;
            Description = $"Месторождение ресурсов, пока контролируете его - каждый ход получайте по 1 очку";
        }
    }
}
