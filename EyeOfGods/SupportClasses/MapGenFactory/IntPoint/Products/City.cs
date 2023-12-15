using EyeOfGods.Models.MapModels;

namespace EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Products
{
    public class City : InterestPoint
    {
        public City(MapSchemePoint point)
        {
            PointHeight = 2;
            PointWidth = 2;
            PointNumber = point.PointNumber;
            PareWhithPoint = point.PareWhithPoint;

            XCoordinate = point.XCoordinate;
            YCoordinate = point.YCoordinate;

            Type = InterestPointsTypes.Город;
            Description = $"Город, при первом захвате каждой из площадей игрок получает 1 очко(могут получить оба игрока)," +
                $" в конце игры каждая контроллируемая площадь дает 2 очка";
        }
    }
}
