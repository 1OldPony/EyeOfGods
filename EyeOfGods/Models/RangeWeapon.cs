using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class RangeWeapon
    {
        public int Id { get; set; }
        public string RWName { get; set; } = "Оружие дальнего боя";

        public int RangeOfShooting { get; set; } = 1;

        //[ForeignKey(nameof(RangeWeaponsType))]
        //public int RWtypeId { get; set; }
        public RangeWeaponsType RangeWeaponsType { get; set; }/* = new RangeWeaponsType();*/
    }
}
