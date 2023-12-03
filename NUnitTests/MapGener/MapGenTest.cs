using EyeOfGods.Models;
using Moq;
using static NUnitTests.FakeDb.Db_Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeOfGods.SupportClasses.MapGenFactory;
using EyeOfGods.SupportClasses.MapGenFactory.Products;
using EyeOfGods.SupportClasses.MapGenFactory.Creators;
using EyeOfGods.Models.MapModels;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using EyeOfGods.Context;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators;
using System.Drawing;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products;

namespace NUnitTests.MapGener
{
    [TestFixture]
    internal class MapGenTest
    {
        ILogger<MapGenerator> _logger;
        Mock<MyWargameContext> _fakeDb;
        Random rnd = new();
        MapGenerator generator;
        MapScheme scheme;
        SeedData seed = new();

        [SetUp]
        public void Setup()
        {
            _fakeDb = Context();
            generator = new(_logger, _fakeDb.Object.Quests.ToList());
            scheme = _fakeDb.Object.MapSchemes.First();
        }

        [Test]
        public void DOES_city_creator_create_City()
        {
            var sheme = _fakeDb.Object.MapSchemes.First();


            var x = generator.GenerateMap(sheme,TerrainDensity.Средняя,30,30,30);

            Assert.That(x, Is.TypeOf<City>());
        }

        [Test]
        public void DOES_forest_creator_create_Forest()
        {
            var sheme = _fakeDb.Object.MapSchemes.First();
            List<Rectangle> rect = new()
            {
                new Rectangle(sheme.Points[0].XCoordinate, sheme.Points[0].YCoordinate,
                2, 2)
            };

            MapSchemePoint x = new() { PointNumber = 1, PointHeight = 2, PointWidth = 2, XCoordinate = 2, YCoordinate = 2 };
            ForestCreator fCr = new(x, rect, scheme);

            List<Terrain> ter = new();
            for (int i = 0; i < 10; i++)
            {
                Terrain t = fCr.Create();
                rect.Add(new Rectangle(t.XCoordinate, t.YCoordinate, t.PointWidth, t.PointHeight));
                ter.Add(t);
            }

            Assert.That(ter.Count==10, Is.True);
        }

        [TestCase(2, 2, 2)]
        [TestCase(5, 1, 1)]
        public void DOES_GenInterestPoints_generate_right_number_Point_Types(int NumbOfCities, int NumbOfTreasuries, int NumbOfResources)
        {
            scheme.NumbOfCities = NumbOfCities;
            scheme.NumbOfTreasuries = NumbOfTreasuries;
            scheme.NumbOfResources = NumbOfResources;
            if (NumbOfCities + NumbOfTreasuries + NumbOfResources == 7)
            {
                scheme.Points = seed.mapSchemePoints7;
            }

            var points = generator.GenInterestPoints(scheme, rnd).Result;

            Assert.That(points.Where(p=>p.Type == InterestPointsTypes.Город).ToList().Count == NumbOfCities, Is.True);
            Assert.That(points.Where(p => p.Type == InterestPointsTypes.Сокровищница).ToList().Count == NumbOfTreasuries, Is.True);
            Assert.That(points.Where(p => p.Type == InterestPointsTypes.Ресурсы).ToList().Count == NumbOfResources, Is.True);
        }
    }
}
