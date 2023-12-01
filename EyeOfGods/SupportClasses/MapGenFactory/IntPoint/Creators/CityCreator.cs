using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.Products;
using System.Collections.Generic;

namespace EyeOfGods.SupportClasses.MapGenFactory.Creators
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
