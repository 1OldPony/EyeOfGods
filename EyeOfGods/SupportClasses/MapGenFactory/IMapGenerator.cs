using EyeOfGods.Models.MapModels;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace EyeOfGods.SupportClasses.MapGenFactory
{
    public interface IMapGenerator
    {
        InterestPoint CreateCity(MapSchemePoint point);
        Terrain CreateForest(MapSchemePoint point, List<Rectangle> forbidPos, MapScheme scheme);
        InterestPoint CreateReasourse(MapSchemePoint point);
        Terrain CreateSwamp(MapSchemePoint point, List<Rectangle> forbidPos, MapScheme scheme);
        InterestPoint CreateTreasury(MapSchemePoint point, QuestLevel level);
        Terrain CreateWater(MapSchemePoint point, List<Rectangle> forbidPos, MapScheme scheme);
        Map GenerateMap(MapScheme scheme, TerrainOptions options);
        List<InterestPoint> GenInterestPoints(MapScheme scheme, Random rnd);
        List<Terrain> GenTerrForPoints(MapScheme scheme, Random rnd, TerrainOptions options);
        List<Terrain> PlaceGodTokens(int godPresence, Random rnd, List<Terrain> terrains);
    }
}