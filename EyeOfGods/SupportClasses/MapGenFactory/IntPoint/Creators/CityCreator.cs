using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Products;

namespace EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Creators
{
    public class CityCreator : IntPointCreator
    {
        public CityCreator(MapSchemePoint point) : base(point) {}

        public override InterestPoint Create()
        {
            return new City(_point);
        }
    }
}
