using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class DefensiveAbilities
    {
        public int Id { get; set; }
        public string CharacteristicName { get; set; } = "Характеристика защиты";
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int NoDoubleActionAt { get; set; }
        public int Step { get; set; }
        public string DefenseAddProperty { get; set; } = "Дополнительное свойство";
        public bool BlocksArmorPierce { get; set; } = false;
    }
}
