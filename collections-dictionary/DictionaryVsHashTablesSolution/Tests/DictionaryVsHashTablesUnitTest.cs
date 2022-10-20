using DictionaryVsHashTables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Tests
{
    [TestClass]
    public class DictionaryVsHashTablesUnitTest
    {
        private readonly Dictionary<int, Order> orders = new();
        private readonly Hashtable random = new();

        public DictionaryVsHashTablesUnitTest()
        {
            orders.Add(1, new Order
            {
                OrderId = Guid.NewGuid(),
                Quantity = 25
            });
            orders.Add(2, new Order
            {
                OrderId = Guid.NewGuid(),
                Quantity = 35
            });
            orders.Add(3, new Order
            {
                OrderId = Guid.NewGuid(),
                Quantity = 45
            });

            random.Add(1, 100);
            random.Add(2, "Chicago");
            random.Add(3, true);
        }

        [TestMethod]
        public void WhenCreateAnEmptyDictionary_ThenReturnDictionaryOfTypeIntAndString()
        {
            var actual = Utility.CreateAnEmptyDictionary();

            Assert.IsInstanceOfType(actual, typeof(Dictionary<int, string>));
        }

        [TestMethod]
        public void WhenCreateAnOrdersDictionary_ThenReturnDictionaryOfTypeIntAndOrder()
        {
            var actual = Utility.CreateAnOrderDictionary();

            Assert.IsInstanceOfType(actual, typeof(Dictionary<int, Order>));
        }

        [TestMethod]
        public void WhenCreateAnOrdersDictionary_ThenFirstKeyShouldBeEqual()
        {
            var actual = Utility.CreateAnOrderDictionary();
            var expected = orders;

            Assert.AreEqual(expected.Keys.ToList()[0], actual.Keys.ToList()[0]);
        }

        [TestMethod]
        public void WhenCreateAnOrdersDictionary_ThenFirstKeyAndSecondKeyShouldNotBeEqual()
        {
            var actual = Utility.CreateAnOrderDictionary();
            var expected = orders;

            Assert.AreNotEqual(expected.Keys.ToList()[0], actual.Keys.ToList()[1]);
        }

        [TestMethod]
        public void WhenCreateAnOrdersDictionary_ThenFirstQuantitiesShouldBeEqual()
        {
            var actual = Utility.CreateAnOrderDictionary();
            var firstActualQuantity = actual.Values.First().Quantity;

            var expected = orders;
            var firstExpectedQuantity = expected.Values.First().Quantity;

            Assert.AreEqual(firstExpectedQuantity, firstActualQuantity);
        }

        [TestMethod]
        public void WhenCreateAnOrdersDictionary_ThenFirstAndSecondQuantitiesShouldNotBeEqual()
        {
            var actual = Utility.CreateAnOrderDictionary();
            var firstActualQuantity = actual.Values.ElementAt(1).Quantity;

            var expected = orders;
            var secondExpectedQuantity = expected.Values.ElementAt(2).Quantity;

            Assert.AreNotEqual(secondExpectedQuantity, firstActualQuantity);
        }

        [TestMethod]
        public void WhenCreateAnEmptyHashTable_ThenReturnInstanceOfAHashtable()
        {
            var actual = Utility.CreateAnEmptyHashTable();

            Assert.IsInstanceOfType(actual, typeof(Hashtable));
        }

        [TestMethod]
        public void WhenCreateAHashTable_ThenCountOfKeysShouldBeEqual()
        {
            var actual = Utility.CreateAHashTable();
            var expected = random;

            Assert.AreEqual(actual.Keys.Count, expected.Keys.Count);
        }

        [TestMethod]
        public void WhenCreateAHashTableAndAddAnotherElement_ThenCountOfKeysShouldNotBeEqual()
        {
            var actual = Utility.CreateAHashTable();
            var expected = random;
            expected.Add(4, 200.65f);

            Assert.AreNotEqual(actual.Keys.Count, expected.Keys.Count);
        }
    }
}