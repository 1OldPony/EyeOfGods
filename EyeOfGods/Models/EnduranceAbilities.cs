using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class EnduranceAbilities
    {
        public int Id { get; set; }
        public string CharacteristicName { get; set; } = "Характеристика выносливости";
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int Step { get; set; }
        public string DurabilityAddProperty { get; set; } = "Дополнительное свойство";
    }
}
