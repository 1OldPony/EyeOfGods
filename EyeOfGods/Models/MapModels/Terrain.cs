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
        /// <summary>
        /// Припиши, чтоб при создании проверялось - нет ли уже такого, и если есть - записывало его
        /// </summary>

        public int Id { get; set; }
        public TerrainTypes Type { get; set; }
        public string Description { get; set; }
        public bool GodToken { get; set; }
    }
}
