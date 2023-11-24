using System.Collections.Generic;

namespace EyeOfGods.Models.MapModels
{
    public enum InterestPointsTypes {
        Город, Ресурсы, Сокровищница
    }
    public class InterestPoint : MapSchemePoint
    {
        public int Id { get; set; }
        public InterestPointsTypes Type { get; set; }
        public string Description { get; set; }

        public Quest Quest { get; set; }
    }
}
