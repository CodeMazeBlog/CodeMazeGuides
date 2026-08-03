using DictionaryVsHashTables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Tests
{
    [TestClass]
    public class DictionaryVsHashTablesUnitTest
    {
        private readonly Dictionary<int, Order> _orders = new();
        private readonly Hashtable _random = new();

        public DictionaryVsHashTablesUnitTest()
        {
            _orders.Add(1, new Order
            {
                OrderId = Guid.NewGuid(),
                Quantity = 25
            });
            _orders.Add(2, new Order
            {
                OrderId = Guid.NewGuid(),
                Quantity = 35
            });
            _orders.Add(3, new Order
            {
                OrderId = Guid.NewGuid(),
                Quantity = 45
            });

            _random.Add(1, 100);
            _random.Add(2, "Chicago");
            _random.Add(3, true);
        }

        [TestMethod]
        public void WhenCreateEmptyDictionary_ThenReturnDictionaryOfTypeIntAndString()
        {
            var actual = Utility.CreateEmptyDictionary();

            Assert.IsInstanceOfType(actual, typeof(Dictionary<int, string>));
        }

        [TestMethod]
        public void WhenCreateOrdersDictionary_ThenReturnDictionaryOfTypeIntAndOrder()
        {
            var actual = Utility.CreateOrderDictionary();

            Assert.IsInstanceOfType(actual, typeof(Dictionary<int, Order>));
        }

        [TestMethod]
        public void WhenCreateOrdersDictionary_ThenFirstKeyShouldBeEqual()
        {
            var actual = Utility.CreateOrderDictionary();
            var expected = _orders;

            Assert.AreEqual(expected.Keys.ToList()[0], actual.Keys.ToList()[0]);
        }

        [TestMethod]
        public void WhenCreateOrdersDictionary_ThenFirstKeyAndSecondKeyShouldNotBeEqual()
        {
            var actual = Utility.CreateOrderDictionary();
            var expected = _orders;

            Assert.AreNotEqual(expected.Keys.ToList()[0], actual.Keys.ToList()[1]);
        }

        [TestMethod]
        public void WhenCreateOrdersDictionary_ThenFirstQuantitiesShouldBeEqual()
        {
            var actual = Utility.CreateOrderDictionary();
            var firstActualQuantity = actual.Values.First().Quantity;

            var expected = _orders;
            var firstExpectedQuantity = expected.Values.First().Quantity;

            Assert.AreEqual(firstExpectedQuantity, firstActualQuantity);
        }

        [TestMethod]
        public void WhenCreateOrdersDictionary_ThenFirstAndSecondQuantitiesShouldNotBeEqual()
        {
            var actual = Utility.CreateOrderDictionary();
            var firstActualQuantity = actual.Values.ElementAt(1).Quantity;

            var expected = _orders;
            var secondExpectedQuantity = expected.Values.ElementAt(2).Quantity;

            Assert.AreNotEqual(secondExpectedQuantity, firstActualQuantity);
        }

        [TestMethod]
        public void WhenCreateEmptyHashTable_ThenReturnInstanceOfAHashtable()
        {
            var actual = Utility.CreateEmptyHashTable();

            Assert.IsInstanceOfType(actual, typeof(Hashtable));
        }

        [TestMethod]
        public void WhenCreateHashTable_ThenCountOfKeysShouldBeEqual()
        {
            var actual = Utility.CreateHashTable();
            var expected = _random;

            Assert.AreEqual(actual.Keys.Count, expected.Keys.Count);
        }

        [TestMethod]
        public void WhenCreateHashTableAndAddAnotherElement_ThenCountOfKeysShouldNotBeEqual()
        {
            var actual = Utility.CreateHashTable();
            var expected = _random;
            expected.Add(4, 200.65f);

            Assert.AreNotEqual(actual.Keys.Count, expected.Keys.Count);
        }
    }
}