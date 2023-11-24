using EyeOfGods.Models;
using Moq;
using static NUnitTests.FakeDb.Db_Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeOfGods.SupportClasses.MapGenFactory;

namespace NUnitTests.MapGener
{
    [TestFixture]
    internal class MapGenTest
    {

        Mock<MyWargameContext> _fakeDb = new();
        Random rnd = new();
        MapGenerator generator = new ();

        [SetUp]
        public void Setup()
        {
            _fakeDb = Context();
        }

        //[Test]
        //public void DOES_
    }
}
