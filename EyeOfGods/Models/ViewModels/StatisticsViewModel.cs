using System.Collections.Generic;

namespace EyeOfGods.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public int UnitsCount { get; set; }
        public int InfantryCount { get; set; }
        public int CavaleryCount { get; set; }
        public int MonsterCount { get; set; }
        public int ArtilleryCount { get; set; }
        public int GiantsCount { get; set; }
        public int VenicleCount { get; set; }
        public int AviationCount { get; set; }


        public List<DefenceChars> DefenceChars { get; set; }
        public List<EnduranceChars> EnduranceChars { get; set; }
        public List<MentalChars> MentalChars { get; set; }

        public int MeleeWeaponsCount { get; set; }
        public List<MeleeWeaponsStat> MeleeWeaponsTypes { get; set; }

        public int RangeWeaponsCount { get; set; }
        public List<RangeWeaponsStat> RangeWeaponsTypes { get; set; }

        public int ShieldsCount { get; set; }
        //List<ShieldsStat> Shieldes { get; set; }

    }
    public class DefenceChars
    {
        public string CharacteristicName { get; set; }
        public int UsageCount { get; set; }
    }
    public class EnduranceChars
    {
        public string CharacteristicName { get; set; }
        public int UsageCount { get; set; }
    }
    public class MentalChars
    {
        public string CharacteristicName { get; set; }
        public int UsageCount { get; set; }
    }
    public class MeleeWeaponsStat
    {
        public string WeaponStatName { get; set; }
        public int UsageCount { get; set; }
    }
    public class RangeWeaponsStat
    {
        public string WeaponStatName { get; set; }
        public int UsageCount { get; set; }
    }
    public class ShieldsStat
    {
        public string ShieldtName { get; set; }
        public int UsageCount { get; set; }
    }
}
