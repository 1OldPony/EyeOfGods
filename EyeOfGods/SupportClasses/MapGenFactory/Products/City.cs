using EyeOfGods.Models.MapModels;

namespace EyeOfGods.SupportClasses.MapGenFactory.Products
{
    public class City : InterestPoint
    {
        public City(MapSchemePoint point)
        {
            PointHeight = 3;
            PointWidth = 3;
            PointNumber = point.PointNumber;
            PareWhithPoint = point.PareWhithPoint;

            XCoordinate = point.XCoordinate;
            YCoordinate = point.YCoordinate;

            Type = InterestPointsTypes.Ресурсы;
            Description = $"Город, при первом захвате каждой из площадей игрок получает 1 очко(могут получить оба игрока)," +
                $" в конце игры каждая контроллируемая площадь дает 2 очка";
        }
    }
}
