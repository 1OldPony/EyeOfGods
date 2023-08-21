using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class AdditionalProperty
    {
        public int Id { get; set; }
        public string PropertyName { get; set; } = "Дополнительное свойство 1";
        public string PropertyDescription { get; set; } = "Описание";
        //для какой характеристики
        public string PropertyType { get; set; } = "Тип свойства";
    }
}
