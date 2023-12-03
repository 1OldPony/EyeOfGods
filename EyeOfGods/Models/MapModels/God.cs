using System.ComponentModel.DataAnnotations;

namespace EyeOfGods.Models.MapModels
{
    public enum GodNames { 
        Шутник, Справедливость, Доблесть, Время, Знания
    }
    public class God
    {
        //public int Id { get; set; }
        [Key]
        public string GodName { get; set; }
        public string Description { get; set; }
        public string FighterAbilityDesc { get; set; }
        public string MageAbilityDesc { get; set; }
        public string UltimateAbilityDesc { get; set; }

    }
}
