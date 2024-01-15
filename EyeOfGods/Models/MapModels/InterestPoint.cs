using System.Collections.Generic;

namespace EyeOfGods.Models.MapModels
{
    public enum InterestPointsTypes {
        Город, Ресурсы, Сокровищница
    }
    public class InterestPoint : MapSchemePoint
    {
        public InterestPointsTypes Type { get; set; }
        public string Description { get; set; }
    }
}
