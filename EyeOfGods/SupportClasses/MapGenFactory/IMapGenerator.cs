using EyeOfGods.Models.MapModels;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace EyeOfGods.SupportClasses.MapGenFactory
{
    public interface IMapGenerator
    {
        InterestPoint CreateCity(MapSchemePoint point);
        Terrain CreateForest(InterestPoint point, List<Rectangle> forbidPos, MapScheme scheme);
        InterestPoint CreateReasourse(MapSchemePoint point);
        Terrain CreateSwamp(InterestPoint point, List<Rectangle> forbidPos, MapScheme scheme);
        InterestPoint CreateTreasury(MapSchemePoint point);
        Terrain CreateWater(InterestPoint point, List<Rectangle> forbidPos, MapScheme scheme);
        Map GenerateMap(MapScheme scheme, TerrainOptions options, TerrainDensity density, QuestLevel qLevel);
        List<InterestPoint> GenInterestPoints(MapScheme scheme, Random rnd);
        List<Terrain> GenTerrForPoints(List<InterestPoint> intPoints, Random rnd, TerrainOptions options,
            MapScheme scheme, TerrainDensity density);
        List<Terrain> PlaceGodTokens(int godPresence, Random rnd, List<Terrain> terrains);
    }
}