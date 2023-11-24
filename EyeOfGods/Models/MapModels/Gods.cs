namespace EyeOfGods.Models.MapModels
{
    public enum GodNames { 
        Шутник, Справедливость, Доблесть, Время, Знания
    }
    public class Gods
    {
        public int Id { get; set; }
        public GodNames Name { get; set; }
        public string Description { get; set; }
        public string FighterAbilityDesc { get; set; }
        public string MageAbilityDesc { get; set; }
        public string UltimateAbilityDesc { get; set; }

    }
}
