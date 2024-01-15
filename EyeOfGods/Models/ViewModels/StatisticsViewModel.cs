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


        public List<DefenceChars> DefenceChars { get; set; } = new();
        public List<EnduranceChars> EnduranceChars { get; set; } = new();
        public List<MentalChars> MentalChars { get; set; } = new();

        public int MeleeWeaponsCount { get; set; }
        public List<MeleeWeaponsStat> MeleeWeaponsTypes { get; set; } = new();

        public int RangeWeaponsCount { get; set; }
        public List<RangeWeaponsStat> RangeWeaponsTypes { get; set; } = new();

        public int ShieldsCount { get; set; }

    }
    public class DefenceChars
    {
        public string Name { get; set; }
        public int UsageCount { get; set; }
    }
    public class EnduranceChars
    {
        public string Name { get; set; }
        public int UsageCount { get; set; }
    }
    public class MentalChars
    {
        public string Name { get; set; }
        public int UsageCount { get; set; }
    }
    public class MeleeWeaponsStat
    {
        public string Name { get; set; }
        public int UsageCount { get; set; }
    }
    public class RangeWeaponsStat
    {
        public string Name { get; set; }
        public int UsageCount { get; set; }
    }
    public class ShieldsStat
    {
        public string Name { get; set; }
        public int UsageCount { get; set; }
    }
}
