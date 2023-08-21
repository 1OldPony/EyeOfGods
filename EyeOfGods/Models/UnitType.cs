using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class UnitType
    {
        [Key]
        public int Id { get; set; }
        public string UnitTypeName { get; set; } = "Род войск";

        public int MinSpeed { get; set; }
        public int MaxSpeed { get; set; }

        //Влияние местностей
        public string ForestGoThrough { get; set; } = "0";
        public string ForestForcedMove { get; set; } = "0";
        public string ForestAssault { get; set; } = "+0";

        public string SwampGoThrough { get; set; } = "0";
        public string SwampForcedMove { get; set; } = "0";
        public string SwampAssault { get; set; } = "+0";

        public string WaterGoThrough { get; set; } = "0";
        public string WaterForcedMove { get; set; } = "0";
        public string WaterAssault { get; set; } = "+0";

        public string SettelmentGoThrough { get; set; } = "0";
        public string SettelmentForcedMove { get; set; } = "0";
        public string SettelmentAssault { get; set; } = "+0";

        public string CliffGoThrough { get; set; } = "0";
        public string CliffForcedMove { get; set; } = "0";
        public string CliffAssault { get; set; } = "+0";

        public string BarricadeGoThrough { get; set; } = "0";
        public string BarricadeForcedMove { get; set; } = "0";
        public string BarricadeAssault { get; set; } = "+0";

        //Базовые приказы рода войск
        //public int UnitOrderId { get; set; }
        public List<UnitOrder> UnitTypeOrders { get; set; } = new List<UnitOrder>();
    }
}
