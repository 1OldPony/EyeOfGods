using EyeOfGods.Controllers;
using EyeOfGods.Models;
using EyeOfGods.SupportClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using static NUnitTests.FakeDb.Db_Moq;

namespace NUnitTests.Controllers
{
    [TestFixture]
    internal class GensAndStat_Test
    {
        GensAndStat _GnS;
        Mock<MyWargameContext> _fakeDb;
        Mock<IUnitGenerator> _unitGen;
        Mock<IStatistics> _statistics;

        [SetUp]
        public void Setup()
        {
            _fakeDb = Context();
            _unitGen = new();
            _statistics = new();
            _GnS = new GensAndStat(_fakeDb.Object, _unitGen.Object, _statistics.Object);
        }

        [Test]
        public void GetStatist()
        {
            var x = _GnS.GetUnitsStat().Result;

            Assume.That(x.UnitsCount, Is.Not.EqualTo(0));
        }

        [Test]
        public void GenerateUnits_test()
        {
            var x = _GnS.GenerateUnits(2).Result;

            Assume.That(x.ExecuteResultAsync, Is.TypeOf<OkResult>());
        }
    }
}
