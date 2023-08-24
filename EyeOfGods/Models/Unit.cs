using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string UnitName { get; set; } = "Название отряда";
        public int Speed { get; set; } = 1;
        public int Defense { get; set; } = 1;
        public int Endurance { get; set; } = 1;
        public int Mental { get; set; } = 1;


        public List<MeleeWeapon> MeleeWeapons { get; set; } = new ();
        public RangeWeapon RangeWeapon { get; set; }/* = new RangeWeapon();*/
        public Shield Shield { get; set; }/* = new Shield();*/
        public DefensiveAbilities DefensiveAbilities { get; set; }/* = new DefensiveAbilities();*/
        public EnduranceAbilities EnduranceAbilities { get; set; } /*= new EnduranceAbilities();*/
        public MentalAbilities MentalAbilities { get; set; } /*= new MentalAbilities();*/
        public UnitType UnitType { get; set; }/* = new UnitType();*/

    }
}
