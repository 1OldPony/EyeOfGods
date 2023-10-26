using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public enum MeleeWeaponTypes
    {
        Копье, Пика, Одноручное, Парное, Двуручное, Алебарда
    }

    public class MeleeWeapon
    {
        public int Id { get; set; }
        public string MWName { get; set; } = "Оружие ближнего боя";

        public MeleeWeaponTypes WeaponType { get; set; } = new MeleeWeaponTypes();
        public List<Unit> Units { get; set; } = new();

    }
}
