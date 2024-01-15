using EyeOfGods.Models.MapModels;
using System.Collections.Generic;

namespace EyeOfGods.Models.ViewModels
{
    public class MapForm
    {
        public string MapName { get; set; }
        public int QuestLevel { get; set; }
        public int Density { get; set; }

        public int TerrainOptionsId { get; set; }
        public int SchemeId { get; set; }

        public List<IntP> InterestPoints { get; set; } = new();
        public List<Terr> Terrains { get; set; }
    }

    public class Terr
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public int pointHeight { get; set; }
        public int pointWidth { get; set; }
        public int pointType { get; set; }
        public int referenceTo { get; set; }
        public string description { get; set; }
        public string hasGodToken { get; set; }
    }
    public class IntP
    {
        public int pointNumber { get; set; }
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public int pointHeight { get; set; }
        public int pointWidth { get; set; }
        public int pointType { get; set; }
        public int pareWhithPoint { get; set; }
        public string description { get; set; }
    }
}
