using EyeOfGods.Models.MapModels;
using System.Drawing;

namespace EyeOfGods.SupportClasses.MapGenFactory.Creators
{
    public abstract class Creator
    {
        public MapSchemePoint _point;
        public Creator(MapSchemePoint point)
        {
            _point = point;
        }
        abstract public MapSchemePoint Create();
    }
}
