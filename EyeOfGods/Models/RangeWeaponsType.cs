using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class RangeWeaponsType
    {
        public int Id { get; set; }
        public string RWTypeName { get; set; } = "Тип оружия дальнего боя";
        public int MinDistance { get; set; }
        public int MaxDistance { get; set; }
        public int DistanceStep { get; set; }
        /// <summary>
        /// ////////////////////////////////////
        /// ПО СВОЙСТВАМ - НУЖНА КОЛЛЕКЦИЯ СВОЙСТВ, ИХ МОЖЕТ БЫТЬ БОЛЬШЕ 2(НЕТ РЕАКЦИИ - 3-Е ДЛЯ АРТЫ)
        /// </summary>
        public string FirstRWTypeProperty { get; set; } = "Первое свойство";
        public string SecondRWTypeProperty { get; set; } = "Второе свойство";

        public List<RangeWeapon> RangeWeapons { get; set; }
    }
}
