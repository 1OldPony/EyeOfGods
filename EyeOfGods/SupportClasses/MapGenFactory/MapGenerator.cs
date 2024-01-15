using EyeOfGods.Migrations;
using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Creators;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.SupportClasses.MapGenFactory
{
    public class MapGenerator : IMapGenerator
    {
        private readonly ILogger<MapGenerator> _logger;

        public MapGenerator(ILogger<MapGenerator> logger)
        {
            _logger = logger;
        }

        public Map GenerateMap(MapScheme scheme, TerrainOptions options, TerrainDensity density, QuestLevel qLevel)
        {
            Random rnd = new();

            Map map = new();
            map.Scheme = scheme;
            map.InterestPoints = GenInterestPoints(scheme, rnd);
            map.QuestLevel = qLevel;
            map.Terrains = GenTerrForPoints(map.InterestPoints, rnd, options, scheme, density);
            map.Density = density;
            map.TerrainOptions = options;

            return map;
        }

        public List<InterestPoint> GenInterestPoints(MapScheme scheme, Random rnd)
        {
            List<MapSchemePoint> allPoints = new();
            foreach (var item in scheme.Points)
            {
                allPoints.Add(item);
            }
            List<MapSchemePoint> cit = new();
            List<MapSchemePoint> treas = new();
            List<MapSchemePoint> res = new();
            MapSchemePoint point;
            MapSchemePoint pairPoint;

            List<InterestPoint> complete = new();

            //Рандомизируем номера точек схем под каждый из типов с учетом общего их количества
            while (cit.Count != scheme.NumbOfCities || treas.Count != scheme.NumbOfTreasuries || res.Count != scheme.NumbOfResources)
            {
                try
                {
                    point = allPoints.ElementAt(rnd.Next(0, allPoints.Count));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex, "Ошибка рандомайзера точек схем для точек интереса");
                    throw;
                }

                if (point.PareWhithPoint == null)
                {
                    if ((scheme.NumbOfCities - cit.Count) % 2 == 1 && scheme.NumbOfCities > cit.Count)
                    {
                        cit.Add(point);
                        allPoints.Remove(point);
                        continue;
                    }
                    if ((scheme.NumbOfTreasuries - treas.Count) % 2 == 1 && scheme.NumbOfTreasuries > treas.Count)
                    {
                        treas.Add(point);
                        allPoints.Remove(point);
                        continue;
                    }
                    if ((scheme.NumbOfResources - res.Count) % 2 == 1 && scheme.NumbOfResources > res.Count)
                    {
                        res.Add(point);
                        allPoints.Remove(point);
                        continue;
                    }
                }
                else
                {
                    try
                    {
                        pairPoint = allPoints.Find(p => p.PareWhithPoint == point.PointNumber);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogCritical(ex, "Ошибка рандомайзера точек схем для точек интереса");
                        throw;
                    }

                    if ((scheme.NumbOfCities - cit.Count) % 2 == 0 && scheme.NumbOfCities > cit.Count)
                    {
                        cit.AddRange(new List<MapSchemePoint> { point, pairPoint });
                        allPoints.Remove(point);
                        allPoints.Remove(pairPoint);
                        continue;
                    }
                    if ((scheme.NumbOfTreasuries - treas.Count) % 2 == 0 && scheme.NumbOfTreasuries > treas.Count)
                    {
                        treas.AddRange(new List<MapSchemePoint> { point, pairPoint });
                        allPoints.Remove(point);
                        allPoints.Remove(pairPoint);
                        continue;
                    }
                    if ((scheme.NumbOfResources - res.Count) % 2 == 0 && scheme.NumbOfResources > res.Count)
                    {
                        res.AddRange(new List<MapSchemePoint> { point, pairPoint });
                        allPoints.Remove(point);
                        allPoints.Remove(pairPoint);
                        continue;
                    }
                }
            }

            //Фабрика создает точки из листов
            foreach (var item in cit)
            {
                try
                {
                    complete.Add(CreateCity(item));
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Генерация города не удалась, точка схемы: {item}");
                    throw;
                }
            }

            foreach (var item in treas)
            {
                try
                {
                    complete.Add(CreateTreasury(item/*, _quests, scheme.QuestLevel*/));
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Генерация сокровищницы не удалась, точка схемы: {item}");
                    throw;
                }
            }

            foreach (var item in res)
            {
                try
                {
                    complete.Add(CreateReasourse(item));
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Генерация месторождения ресурсов не удалась, точка схемы: {item}");
                    throw;
                }
            }

            return complete;
        }

        public List<Terrain> GenTerrForPoints(List<InterestPoint> intPoints, Random rnd, TerrainOptions options,
            MapScheme scheme, TerrainDensity density)
        {
            List<InterestPoint> basePoints = new();
            foreach (var item in intPoints)
            {
                basePoints.Add(item);
            }
            List<InterestPoint> points = new();
            InterestPoint point;

            //рандомизируем порядок исходных точек
            for (int i = 0; i < intPoints.Count; i++)
            {
                try
                {
                    point = basePoints.ElementAt(rnd.Next(0, basePoints.Count));
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, "Не удалось выбрать исходную точку для рандомайзера точек террейна");
                    throw new Exception($"Не удалось выбрать исходную точку для рандомайзера точек террейна," +
                        $" {e.Message},\n {e.StackTrace}");
                }
                points.Add(point);
                basePoints.Remove(point);
            }

            //по мере генерации террейна заполняем лист уже существующих точек и отправляем в creator-ы
            //дабы не было пересечений
            List<Rectangle> forbidPos = new();
            List<Terrain> terrains = new();
            Terrain terrain;

            foreach (var item in points)
            {
                forbidPos.Add(new Rectangle(item.XCoordinate, item.YCoordinate, item.PointWidth, item.PointHeight));

                bool typeIsGen = false;

                //в зависимости от заданной плотности террейна, создаем разные его типы с заданным шансом
                for (int i = 0; i < (int)density; i++)
                {
                    typeIsGen = false;
                    while (typeIsGen == false)
                    {
                        int random = rnd.Next(101);
                        if (random <= options.ForestDensity)
                        {
                            terrain = CreateForest(item, forbidPos, scheme);

                            if (terrain != null)
                            {
                                terrains.Add(terrain);
                                forbidPos.Add(new Rectangle(terrain.XCoordinate, terrain.YCoordinate,
                                    terrain.PointWidth, terrain.PointHeight));
                            }

                            typeIsGen = true;
                        }
                        else if (random > options.ForestDensity && random <= options.ForestDensity + options.SwampDensity)
                        {
                            terrain = CreateSwamp(item, forbidPos, scheme);

                            if (terrain != null)
                            {
                                terrains.Add(terrain);
                                forbidPos.Add(new Rectangle(terrain.XCoordinate, terrain.YCoordinate,
                                    terrain.PointWidth, terrain.PointHeight));
                            }

                            typeIsGen = true;
                        }
                        else if (random > options.ForestDensity + options.SwampDensity && random <= 100)
                        {
                            terrain = CreateWater(item, forbidPos, scheme);

                            if (terrain != null)
                            {
                                terrains.Add(terrain);
                                forbidPos.Add(new Rectangle(terrain.XCoordinate, terrain.YCoordinate,
                                    terrain.PointWidth, terrain.PointHeight));
                            }

                            typeIsGen = true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            terrains = PlaceGodTokens(scheme.GodPresense, rnd, terrains);

            return terrains;
        }

        public Terrain CreateForest(InterestPoint point, List<Rectangle> forbidPos, MapScheme scheme)
        {
            ForestCreator forestCr = new(point, forbidPos, scheme);
            Terrain terrain;
            try
            {
                terrain = forestCr.Create();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Генерация леса не удалась, точка схемы: {point}");
                throw new Exception($"Генерация леса не удалась, точка схемы: {point},\n" +
                    $" {e.Message},\n {e.StackTrace}");
            }

            return terrain;
        }

        public Terrain CreateSwamp(InterestPoint point, List<Rectangle> forbidPos, MapScheme scheme)
        {
            SwampCreator swampCr = new(point, forbidPos, scheme);
            Terrain terrain;
            try
            {
                terrain = swampCr.Create();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Генерация болота не удалась, точка схемы: {point}");
                throw new Exception($"Генерация болота не удалась, точка схемы: {point},\n" +
                    $" {e.Message},\n {e.StackTrace}");
            }

            return terrain;
        }

        public Terrain CreateWater(InterestPoint point, List<Rectangle> forbidPos, MapScheme scheme)
        {
            WaterCreator waterCr = new(point, forbidPos, scheme);
            Terrain terrain;
            try
            {
                terrain = waterCr.Create();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Генерация воды не удалась, точка схемы: {point}");
                throw new Exception($"Генерация воды не удалась, точка схемы: {point},\n" +
                    $" {e.Message},\n {e.StackTrace}");
            }

            return terrain;
        }

        public List<Terrain> PlaceGodTokens(int godPresence, Random rnd, List<Terrain> terrains)
        {
            int godTokenCount = 1;
            int cycles = 0;

            var dontHaveToken = terrains.Where(t => t.GodFrendly == true && t.HasGodToken == false).GroupBy(r => r.ReferenceTo);

            while (godTokenCount <= godPresence)
            {
                foreach (var group in dontHaveToken)
                {
                    var groupFilter = group.Where(t => t.HasGodToken != true);

                    if (godTokenCount <= godPresence && groupFilter.Count() > 0)
                    {
                        var element = groupFilter.ElementAt(rnd.Next(0, groupFilter.Count()));
                        if (element.HasGodToken != true)
                            element.HasGodToken = true;

                        godTokenCount++;
                    }
                }

                cycles++;
                if (cycles > 20)
                {
                    break;
                }
            }

            return terrains;
        }

        public InterestPoint CreateCity(MapSchemePoint point)
        {
            IntPointCreator cityCr;
            InterestPoint city;

            try
            {
                cityCr = new CityCreator(point);
                city = cityCr.Create();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Генерация города не удалась, точка схемы: {point}");
                throw;
            }

            return city;
        }

        public InterestPoint CreateReasourse(MapSchemePoint point)
        {
            IntPointCreator resCr;
            InterestPoint res;

            try
            {
                resCr = new ResourceCreator(point);
                res = resCr.Create();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Генерация ресурсной точки не удалась, точка схемы: {point}");
                throw;
            }

            return res;
        }

        public InterestPoint CreateTreasury(MapSchemePoint point)
        {
            IntPointCreator treasCr;
            InterestPoint treas;

            try
            {
                treasCr = new TreasuryCreator(point);
                treas = treasCr.Create();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Генерация сокровищницы не удалась, точка схемы: {point}");
                throw;
            }
            return treas;
        }
    }
}
