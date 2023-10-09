using Moq;
using NUnitTests.FakeDb;
using static NUnitTests.FakeDb.Db_Moq;

namespace NUnitTests
{
    [TestFixture]
    public class FakeDb_Test
    {
        private Mock<IContext> _fakeDb = new();

        [SetUp]
        public void Setup()
        {
            _fakeDb = Context();

            //public MyWargameContext context;

            //PagesController Pages = new(context);
        }

        //[Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void DOES_rangeWeapon_HAS_Its_type(int elementNumber)
        {
            Assert.IsTrue(_fakeDb.Object.RangeWeapons.ElementAt(elementNumber).RangeWeaponsType != null);
        }

        [TestCase(0, "Легкое стрелковое вооружение")]
        [TestCase(1, "Тяжелое стрелковое вооружение")]
        [TestCase(2, "Артиллерийское вооружение")]
        public void DOES_rangeWepon_HAS_RIGHT_type(int elementNumber, string rightTypeName)
        {
            Assert.IsTrue(_fakeDb.Object.RangeWeapons.ElementAt(elementNumber).RangeWeaponsType.RWTypeName == rightTypeName);
        }

        [TestCase(0)]
        [TestCase(1)]
        public void DOES_unitType_HAS_Its_orders(int elementNumber)
        {
            Assert.IsTrue(_fakeDb.Object.UnitTypes.ElementAt(elementNumber).UnitTypeOrders.Count != 0);
        }
    }
}