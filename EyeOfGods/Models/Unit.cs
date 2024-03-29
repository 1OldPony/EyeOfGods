﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public enum UnitSize { Малый, Базовый, Усиленный};
    public class Unit
    {
        public int Id { get; set; }
        public string UnitName { get; set; } = "Название отряда";
        public int Speed { get; set; }
        public int Defense { get; set; }
        public int Vigor { get; set; }
        public int Endurance { get; set; }
        public int Damage { get; set; }
        public int Mental { get; set; }
        public int BreakPoint { get; set; }
        public UnitSize Size { get; set; } = UnitSize.Базовый;


        public List<MeleeWeapon> MeleeWeapons { get; set; } = new ();
        public RangeWeapon RangeWeapon { get; set; }
        public Shield Shield { get; set; }
        public DefensiveAbilities DefensiveAbilities { get; set; }
        public EnduranceAbilities EnduranceAbilities { get; set; }
        public MentalAbilities MentalAbilities { get; set; }
        public UnitType UnitType { get; set; }

    }
}
