using EyeOfGods.Models;
using Moq;
using static NUnitTests.FakeDb.Db_Moq;
using EyeOfGods.SupportClasses.MapGenFactory;
using EyeOfGods.Models.MapModels;
using Microsoft.Extensions.Logging;
using EyeOfGods.Context;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators;
using System.Drawing;
using EyeOfGods.SupportClasses.MapGenFactory.IntPoint.Products;
using EyeOfGods.SupportClasses;

namespace NUnitTests.MapGener
{
    [TestFixture]
    internal class MapGenTest
    {
        Mock<MyWargameContext> _fakeDb;
        MapGenerator generator;
        MapScheme scheme;
        SeedData seed = new();
        Random rnd = new();

        [SetUp]
        public void Setup()
        {
            Mock<ILogger<MapGenerator>> logger = new();
            Mock<ILittleHelper> helper = new();
            _fakeDb = Context();
            generator = new(logger.Object);
            scheme = _fakeDb.Object.MapSchemes.First();
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(5)]
        public void CreateForest_generate_Forests_whith_no_Intersections(int pointIndex)
        {
            var point = scheme.Points[pointIndex];
            Rectangle pointRect = new() { X = point.XCoordinate, Y = point.YCoordinate,
                Height = 2, Width = 2 };

            var forbidPos = new List<Rectangle>() { pointRect };

            var forest = generator.CreateForest(point, forbidPos, scheme);
            Rectangle forestRect = new()
            {
                X = forest.XCoordinate,
                Y = forest.YCoordinate,
                Height = forest.PointHeight,
                Width = forest.PointWidth
            };

            Assert.That(forestRect.IntersectsWith(forbidPos[0]), Is.False);
        }

        [TestCase(TerrainDensity.Низкая, 33, 33, 33)]
        [TestCase(TerrainDensity.Средняя, 33, 33, 33)]
        [TestCase(TerrainDensity.Высокая, 33, 33, 33)]
        public void GenTerrForPoints_generate_right_number_of_Terrain(TerrainDensity terDensity, int fDensity, int sDensity, int wDensity)
        {
            TerrainOptions opt = new()
            {
                Density = terDensity,
                ForestDensity = fDensity,
                SwampDensity = sDensity,
                WaterDensity = wDensity
            };

            var points = generator.GenTerrForPoints(scheme, rnd, opt);

            Assert.That(points.Count / (int)terDensity, Is.EqualTo(scheme.Points.Count));
        }

        [TestCase(TerrainDensity.Низкая)]
        [TestCase(TerrainDensity.Средняя)]
        [TestCase(TerrainDensity.Высокая)]
        public void PlaceGodToken_in_GenTerrForPoints_generate_right_number_of_Tokens(TerrainDensity _density)
        {
            TerrainOptions opt = new()
            {
                Density = _density,
                ForestDensity = 33,
                SwampDensity = 33,
                WaterDensity = 33
            };

            var terrains = generator.GenTerrForPoints(scheme, rnd, opt);

            var terrWhithToken = terrains.Where(t => t.HasGodToken == true).Count();

            Assert.That(terrWhithToken, Is.EqualTo(scheme.GodPresense));
        }

        [TestCase(TerrainDensity.Низкая)]
        [TestCase(TerrainDensity.Средняя)]
        [TestCase(TerrainDensity.Высокая)]
        public void PlaceGodToken_in_GenTerrForPoints_generate_ONLY_ONE_Token_to_InterstPoint(TerrainDensity _density)
        {
            TerrainOptions opt = new()
            {
                Density = _density,
                ForestDensity = 67,
                SwampDensity = 33,
                WaterDensity = 0
            };
            scheme.GodPresense = 5;

            var terrains = generator.GenTerrForPoints(scheme, rnd, opt);

            var terrWhithToken = terrains.Where(t => t.HasGodToken == true)/*.GroupBy(r=>r.ReferenceTo)*/;
            //bool lessThanTwo = terrWhithToken.Any(g => g.Count() > 1);


            Assert.That(terrWhithToken.Count, Is.EqualTo(scheme.GodPresense));
        }



        [TestCase(2, 2, 2)]
        [TestCase(5, 1, 1)]
        public void GenInterestPoints_generate_right_number_Point_Types(int NumbOfCities, int NumbOfTreasuries, int NumbOfResources)
        {
            scheme.NumbOfCities = NumbOfCities;
            scheme.NumbOfTreasuries = NumbOfTreasuries;
            scheme.NumbOfResources = NumbOfResources;
            if (NumbOfCities + NumbOfTreasuries + NumbOfResources == 7)
            {
                scheme.Points = seed.mapSchemePoints7;
            }

            var points = generator.GenInterestPoints(scheme, rnd);

            Assert.That(points.Where(p => p.Type == InterestPointsTypes.Город).ToList().Count == NumbOfCities, Is.True);
            Assert.That(points.Where(p => p.Type == InterestPointsTypes.Сокровищница).ToList().Count == NumbOfTreasuries, Is.True);
            Assert.That(points.Where(p => p.Type == InterestPointsTypes.Ресурсы).ToList().Count == NumbOfResources, Is.True);
        }










        //[Test]
        //public void DOES_city_creator_create_City()
        //{
        //    var sheme = _fakeDb.Object.MapSchemes.First();


        //    var x = generator.GenerateMap(sheme, new TerrainOptions
        //    {
        //        density = TerrainDensity.Средняя,
        //        ForestDensity = 30,
        //        SwampDensity = 30,
        //        WaterDensity = 30
        //    });

        //    Assert.That(x, Is.TypeOf<City>());
        //}

        //[Test]
        //public void DOES_forest_creator_create_Forest()
        //{
        //    List<Rectangle> rect = new()
        //    {
        //        new Rectangle(scheme.Points[0].XCoordinate, scheme.Points[0].YCoordinate,
        //        2, 2)
        //    };

        //    MapSchemePoint x = new() { PointNumber = 1, PointHeight = 2, PointWidth = 2, XCoordinate = 2, YCoordinate = 2 };
        //    ForestCreator fCr = new(x, rect, scheme);

        //    List<Terrain> ter = new();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Terrain t = fCr.Create();
        //        rect.Add(new Rectangle(t.XCoordinate, t.YCoordinate, t.PointWidth, t.PointHeight));
        //        ter.Add(t);
        //    }

        //    Assert.That(ter.Count == 10, Is.True);
        //}
    }
}
