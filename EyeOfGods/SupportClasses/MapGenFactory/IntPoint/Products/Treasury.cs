using EyeOfGods.Models.MapModels;

namespace EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Products
{
    public class Treasury : InterestPoint
    {
        public Treasury(MapSchemePoint point)
        {
            PointHeight = 2;
            PointWidth = 2;
            PointNumber = point.PointNumber;
            PareWhithPoint = point.PareWhithPoint;

            XCoordinate = point.XCoordinate;
            YCoordinate = point.YCoordinate;

            Type = InterestPointsTypes.Сокровищница;
            Description = $"Сокровищница, получи плюшку/очки или по шее";
        }
    }
}