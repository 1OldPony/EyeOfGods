using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Creators
{
    public class TreasuryCreator : IntPointCreator
    {
        public TreasuryCreator(MapSchemePoint point): base(point)
        {}

        public override InterestPoint Create()
        {
            return new Treasury(_point);
        }
    }
}
