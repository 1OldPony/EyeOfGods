using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.Models
{
    public class UnitOrder
    {
        public int Id { get; set; }
        public string OrderName { get; set; } = "Название приказа";
        public string OrderDescrption { get; set; } = "Описание приказа";
        public string SituationBonus { get; set; } = "Ситуативный бонус";
        public string OrderType { get; set; } = "Тип приказа";

        public string SpearBonus { get; set; } = "Бонус копья";
        public string PikeBonus { get; set; } = "Бонус пики";
        public string OneHandBonus { get; set; } = "Бонус одноручного оружия";
        public string DoubleWeaponsBonus { get; set; } = "Бонус парного оружия";
        public string GreatWeaponBonus { get; set; } = "Бонус двуручного оружия";
        public string HalberdBonus { get; set; } = "Бонус алебарды";

        public List<UnitType> UnitTypes { get; set; } = new List<UnitType>();
    }
}
