using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Products;

namespace EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Creators
{
    public class ResourceCreator : IntPointCreator
    {
        public ResourceCreator(MapSchemePoint point) : base(point){}

        public override InterestPoint Create()
        {
            return new Resource(_point);
        }
    }
}
