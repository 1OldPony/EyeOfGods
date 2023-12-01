using EyeOfGods.Models.MapModels;
using EyeOfGods.Models;
using EyeOfGods.SupportClasses.MapGenFactory.Products;
using System.Collections.Generic;
using System;

namespace EyeOfGods.SupportClasses.MapGenFactory.Creators
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
