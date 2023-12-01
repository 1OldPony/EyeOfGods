using EyeOfGods.Models.MapModels;

namespace EyeOfGods.SupportClasses.MapGenFactory.Creators
{
    public abstract class IntPointCreator
    {
        private protected MapSchemePoint _point;
        public IntPointCreator(MapSchemePoint point)
        {
            _point = point;
        }
        abstract public InterestPoint Create();
    }
}
