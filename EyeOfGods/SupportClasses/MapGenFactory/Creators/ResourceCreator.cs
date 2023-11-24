using EyeOfGods.Models.MapModels;
using EyeOfGods.Models;
using EyeOfGods.SupportClasses.MapGenFactory.Products;
using System.Collections.Generic;
using System;

namespace EyeOfGods.SupportClasses.MapGenFactory.Creators
{
    public class ResourceCreator : Creator
    {
        public ResourceCreator(MapSchemePoint point) : base(point){}

        public override MapSchemePoint Create()
        {
            return new Resource(_point);
        }
    }
}
