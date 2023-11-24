namespace EyeOfGods.Models.MapModels
{
    public enum QuestLevel
    {
        легкий, средний, сложный, случайный
    }
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConsWin { get; set; }
        public string ConsDraw { get; set; }
        public string ConsLoose { get; set; }
        public QuestLevel Level { get; set; }

    }
}
