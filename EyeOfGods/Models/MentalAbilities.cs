using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class MentalAbilities
    {
        public int Id { get; set; }
        public string CharacteristicName { get; set; } = "Характкристика стойкости";
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int Step { get; set; }
        public string SpiritAddProperty { get; set; } = "Дополнительное свойство";

        //public List<Unit> UnitsList { get; set; }
    }
}
