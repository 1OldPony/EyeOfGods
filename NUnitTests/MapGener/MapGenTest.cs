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

        [TestCase(3, 3)]
        [TestCase(4, 5)]
        [TestCase(2, 6)]
        public void CreateForest_generate_Forests_whith_no_Intersections(int xCoord, int yCoord)
        {
            var point = new InterestPoint() { PointNumber=1, PointHeight = 2, PointWidth = 2, XCoordinate= xCoord, YCoordinate = yCoord };
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
    }
}
