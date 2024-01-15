namespace EyeOfGods.Models.MapModels
{
    public enum TerrainTypes { 
        Лес, Болото, Вода
    }
    public enum TerrainDensity
    {
        Низкая = 1, Средняя, Высокая
    }
    public class Terrain : MapSchemePoint
    {
        public TerrainTypes Type { get; set; }
        public string Description { get; set; }
        public bool GodFrendly { get; set; }
        public bool HasGodToken { get; set; }
    }
}
