using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.Products;

namespace EyeOfGods.SupportClasses.MapGenFactory.Creators
{
    public class CityCreator : Creator
    {
        public CityCreator(MapSchemePoint point) : base(point) { }

        public override MapSchemePoint Create()
        {
            return new City(_point);
        }
    }
}
