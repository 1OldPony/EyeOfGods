using Microsoft.EntityFrameworkCore;

namespace EyeOfGods.Models.MapModels
{
    public class MapSchemePoint
    {
        public int PointNumber { get; set; }
        public int PointHeight { get; set; }
        public int PointWidth { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int? PareWhithPoint { get; set; }
    }
}
