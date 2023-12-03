using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.Creators;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace EyeOfGods.SupportClasses.MapGenFactory
{
    public class MapGenerator
    {
        private readonly ILogger<MapGenerator> _logger;
        private List<Quest> _quests;
        //private List<God> _gods;
        public MapGenerator(ILogger<MapGenerator> logger, List<Quest> quests)
        {
            _logger = logger;
            _quests = quests;
        }

        public async Task<Map> GenerateMap(MapScheme scheme, TerrainDensity density, int forestDen, int swampDen,
            int waterDen)
        {
            ////////наверно параметры надо будет упаковать как-нибудь, в какой-нибудь класс ТеррейнОпшонс или что-то такое
            Random rnd = new();

            Map map = new Map();
            map.Scheme = scheme;
            map.InterestPoints = await GenInterestPoints(scheme, rnd);


            ////////
            ///Далее добавление террейна
            ////////




            List<MapSchemePoint> basePoints = new();
            foreach (var item in scheme.Points)
            {
                basePoints.Add(item);
            }
            List<MapSchemePoint> points = new();
            MapSchemePoint point;

            //рандомизируем порядок исходных точек
            for (int i = 0; i < scheme.Points.Count; i++)
            {
                point = basePoints.ElementAt(rnd.Next(0, basePoints.Count));
                points.Add(point);
                basePoints.Remove(point);
            }

            //по мере генерации террейна заполняем лист уже существующих точек и отправляем в creator-ы
            //дабы не было пересечений
            List<Rectangle> forbidPos = new();
            List<Terrain> terrains = new();
            foreach (var item in points)
            {
                forbidPos.Add(new Rectangle(item.XCoordinate, item.YCoordinate, item.PointWidth, item.PointHeight));
                
                bool typeIsGen = false;

                //в зависимости от заданной плотности террейна, создаем разные его типы с заданным шансом
                // и крутим while пока не создасться хоть какой-то
                for (int i = 0; i < (int)density; i++)
                {
                    typeIsGen = false;
                    while (typeIsGen == false)
                    {
                        if (LittleHelper.BoolRandom(forestDen))
                        {
                            ForestCreator forestCr = new(item, forbidPos, scheme);
                            Terrain terrain = forestCr.Create();

                            if (terrain != null)
                            {
                                terrains.Add(terrain);
                                forbidPos.Add(new Rectangle(terrain.XCoordinate, terrain.YCoordinate,
                                    terrain.PointWidth, terrain.PointHeight));
                            }
                            
                            typeIsGen = true;
                        }
                        else if (LittleHelper.BoolRandom(swampDen))
                        {
                            SwampCreator swampCr = new(item, forbidPos, scheme);
                            Terrain terrain = swampCr.Create();

                            if (terrain != null)
                            {
                                terrains.Add(terrain);
                                forbidPos.Add(new Rectangle(terrain.XCoordinate, terrain.YCoordinate,
                                    terrain.PointWidth, terrain.PointHeight));
                            }

                            typeIsGen = true;
                        }
                        //else if (LittleHelper.BoolRandom(waterDen))
                        //{
                        //    //terrTypes.Add(TerrainTypes.Вода);
                        //    typeIsGen = true;
                        //}
                        else
                        {
                            continue;
                        }
                    }
                }
            }


            ///// раскидываем божественные жетоны
            ///надо вывести в отдельную функцию, чтоб ее отдельно можно было вызывать
            int godTokenCount = 0;

            while (godTokenCount != scheme.GodPresense)
            {
                var haveToken = terrains.Where(t => t.HasGodToken == true);
                var dontHaveToken = terrains.Where(t => t.GodFrendly == true && t.HasGodToken == false);

                var possElem = dontHaveToken.Except(dontHaveToken
                    .IntersectBy(haveToken.Select(p => p.ReferenceTo), w => w.ReferenceTo));

                possElem.ElementAt(rnd.Next(0, possElem.Count())).HasGodToken = true;

                godTokenCount++;
            }






            return map;
        }















        public async Task<List<InterestPoint>> GenInterestPoints(MapScheme scheme, Random rnd)
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

            //Рандомизируем номера точек схем под каждый из типов
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
                    complete.Add(await CreateCity(item));
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
                    complete.Add(await CreateTreasury(item, _quests, scheme.QuestLevel));
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
                    complete.Add(await CreateReasourse(item));
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Генерация месторождения ресурсов не удалась, точка схемы: {item}");
                    throw;
                }
            }

            return complete;
        }


        //создаем город
        public Task<InterestPoint> CreateCity(MapSchemePoint point)
        {
            IntPointCreator cityCr;
            InterestPoint city;

            try
            {
                cityCr = new CityCreator(point);
                city = cityCr.Create() ;
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Генерация города не удалась, точка схемы: {point}");
                throw;
            }

            return Task.FromResult(city);
        }


        //создаем месторождение ресурсов
        public Task<InterestPoint> CreateReasourse(MapSchemePoint point)
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

            return Task.FromResult(res);
        }


        //создаем сокровищницу
        public Task<InterestPoint> CreateTreasury(MapSchemePoint point, List<Quest> quests, QuestLevel level)
        {
            IntPointCreator treasCr;
            InterestPoint treas;

            try
            {
                treasCr = new TreasuryCreator(point, quests, level);
                treas = treasCr.Create();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Генерация сокровищницы не удалась, точка схемы: {point}, уровень квеста: {level}");
                throw;
            }
            return Task.FromResult(treas);
        }










        //public static Task<bool> ContainsForListOfLists(List<List<MapSchemePoint>> listOfLists, MapSchemePoint serchItem)
        //{
        //    bool result = false;
        //    foreach (var list in listOfLists)
        //    {
        //        if (list.Contains(serchItem))
        //        {
        //            result = true;
        //            break;
        //        }
        //    }
        //    return Task.FromResult(result);
        //}

        //public Task<List<List<MapSchemePoint>>> PointPairsRandomizer(List<MapSchemePoint> schemePoints) 
        //{
        //    //////Надо как-то зарандомить выбор пар точек для генерации
        //    ///

        //    ///
        //    /// А что если тут словарь использовать?
        //    /// 
        //    List<List<MapSchemePoint>> pointPairs = new();
        //    List<MapSchemePoint> pairPoints = new();

        //    foreach (var item in schemePoints)
        //    {
        //        if (!pairPoints.Contains(item) && !ContainsForListOfLists(pointPairs, item).Result)
        //        {
        //            pairPoints.Add(item);

        //            try
        //            {
        //                if (item.PareWhithPoint != null)
        //                {
        //                    schemePoints.Add(schemePoints.Find(p => p.PareWhithPoint == item.PointNumber));
        //                }
        //            }
        //            catch (System.Exception ex)
        //            {
        //                _logger.LogCritical(ex, $"Не удалось найти пару точке {item.PointNumber}");
        //                throw;
        //            }

        //            pointPairs.Add(pairPoints);
        //            pairPoints.Clear();
        //        }
        //        else
        //        {
        //            pairPoints.Add(item);
        //            pointPairs.Add(pairPoints);
        //            pairPoints.Clear();
        //        }
        //    }

        //    return Task.FromResult(pointPairs);
        //}
    }
}
