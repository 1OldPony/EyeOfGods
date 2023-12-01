using EyeOfGods.Models.MapModels;
using System.Collections.Generic;

namespace EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators
{
    public abstract class TerrCreator
    {
        private protected MapSchemePoint _point;
        //private protected TerrainDensity _density;
        public TerrCreator(MapSchemePoint point/*, TerrainDensity density*/)
        {
            _point = point;
            //_density = density;
        }
        abstract public Terrain Create();
    }
}