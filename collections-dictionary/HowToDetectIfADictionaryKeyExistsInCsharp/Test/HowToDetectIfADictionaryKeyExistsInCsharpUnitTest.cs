using HowToDetectIfADictionaryKeyExistsInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class HowToDetectIfADictionaryKeyExistsInCsharpUnitTest
    {
        [TestMethod]
        public void DictionaryContainsKey()
        {
            Dictionary<string, int> MyDictionary = new Dictionary<string, int>() { { "Apple", 3 }, { "Banana", -2 }, { "Orange", 5 }, { "Pear", 2 } };
            bool DictionaryHasBanana = MyDictionary.ContainsKey("Banana"); // true
            bool DictionaryHasKiwi = MyDictionary.ContainsKey("Kiwi"); // false
            bool DictionaryHasLowercaseBanana = MyDictionary.ContainsKey("banana"); // false, because "Banana" exists but "banana" does not

            Assert.IsTrue(DictionaryHasBanana);
            Assert.IsFalse(DictionaryHasKiwi);
            Assert.IsFalse(DictionaryHasLowercaseBanana);
        }
        [TestMethod]
        public void DictionaryContainsKeyUpdate()
        {
            Dictionary<string, int> SetOnceDictionary = new Dictionary<string, int>() { { "Apple", 2 }, { "Banana", 3 } };
            if (!SetOnceDictionary.ContainsKey("Apple")) { SetOnceDictionary["Apple"] = 4; }
            if (!SetOnceDictionary.ContainsKey("Kiwi")) { SetOnceDictionary["Kiwi"] = 4; }

            Assert.IsTrue(SetOnceDictionary.ContainsKey("Apple"));
            Assert.IsTrue(SetOnceDictionary.ContainsKey("Banana"));
            Assert.IsTrue(SetOnceDictionary.ContainsKey("Kiwi"));

            Assert.AreEqual(2, SetOnceDictionary["Apple"]);
            Assert.AreEqual(3, SetOnceDictionary["Banana"]);
            Assert.AreEqual(4, SetOnceDictionary["Kiwi"]);
        }
        [TestMethod]
        public void DictionaryCheckBeforeUse()
        {
            Dictionary<string, int> MyDictionary = new Dictionary<string, int>()
            {
                { "Apple", 3 },
                { "Banana", -2 },
                { "Orange", 5 },
                { "Pear", 2 }
            };

            // Works, but risky!
            int apples = MyDictionary["Apple"]; // 3
            Assert.AreEqual(3, apples);

            // Throws an exception!
            Assert.ThrowsExactly<KeyNotFoundException>(() => MyDictionary["Kiwi"]);

            // Good practice
            int oranges = 0;
            if (MyDictionary.ContainsKey("Orange"))
            {
                oranges = MyDictionary["Orange"]; // 5
            }
            Assert.AreEqual(5, oranges);
        }
        [TestMethod]
        public void DictionaryTryGetValue()
        {
            Dictionary<string, int> MyDictionary = new Dictionary<string, int>()
            {
                { "Apple", 3 },
                { "Banana", -2 },
                { "Orange", 5 },
                { "Pear", 2 }
            };

            int apples = 0;
            bool ApplesSuccess = MyDictionary.TryGetValue("Apple", out apples); // ApplesSuccess == true, apples == 3
            int kiwi = 0;
            bool KiwisSuccess = MyDictionary.TryGetValue("Kiwi", out kiwi); // KiwisSuccess == false, kiwi == 0

            // Same process, but more succinct:
            ApplesSuccess = MyDictionary.TryGetValue("Apple", out int Apples); // ApplesSuccess == true, Apples == 3
            KiwisSuccess = MyDictionary.TryGetValue("Kiwi", out int Kiwi); // KiwisSuccess == false, Kiwi == 0

            Assert.AreEqual(3, Apples);
            Assert.AreEqual(0, Kiwi);
            Assert.IsTrue(ApplesSuccess);
            Assert.IsFalse(KiwisSuccess);
        }
        [TestMethod]
        public void DictionaryHasBanana()
        {
            Dictionary<string, int> MyDictionary = new Dictionary<string, int>()
            {
                { "Apple", 3 },
                { "Banana", -2 },
                { "Orange", 5 },
                { "Pear", 2 }
            };

            bool DictionaryHasBanana = MyDictionary.ContainsKey("Banana");

            Assert.IsTrue(DictionaryHasBanana);
        }
        [TestMethod]
        public void DictionaryTryAdd()
        {
            var inventory = new Dictionary<string, int>()
            {
                { "Apple", 2 },
                { "Banana", 3 }
            };

            var appleAdded = inventory.TryAdd("Apple", 4); // false, "Apple" is already there and keeps its 2
            var kiwiAdded = inventory.TryAdd("Kiwi", 4); // true, "Kiwi" is inserted

            Assert.IsFalse(appleAdded);
            Assert.IsTrue(kiwiAdded);
            Assert.AreEqual(2, inventory["Apple"]);
            Assert.AreEqual(4, inventory["Kiwi"]);
        }
        [TestMethod]
        public void DictionaryAddThrowsOnDuplicateKey()
        {
            var inventory = new Dictionary<string, int>() { { "Apple", 2 } };

            Assert.ThrowsExactly<ArgumentException>(() => inventory.Add("Apple", 4));
        }
        [TestMethod]
        public void DictionaryGetValueOrDefault()
        {
            var inventory = new Dictionary<string, int>() { { "Apple", 3 } };

            Assert.AreEqual(3, inventory.GetValueOrDefault("Apple"));
            Assert.AreEqual(0, inventory.GetValueOrDefault("Kiwi"));
            Assert.AreEqual(99, inventory.GetValueOrDefault("Kiwi", 99));
        }
        [TestMethod]
        public void DictionaryContainsValue()
        {
            var inventory = new Dictionary<string, int>() { { "Apple", 3 }, { "Banana", -2 } };

            Assert.IsTrue(inventory.ContainsValue(-2));
            Assert.IsFalse(inventory.ContainsValue(7));
        }
        [TestMethod]
        public void DictionaryIsEmpty()
        {
            var empty = new Dictionary<string, int>();
            var inventory = new Dictionary<string, int>() { { "Apple", 3 } };

            Assert.AreEqual(0, empty.Count);
            Assert.AreNotEqual(0, inventory.Count);
        }
        [TestMethod]
        public void DictionaryEqualityCheck()
        {
            MyClass One = new MyClass(1);
            MyClass AnotherOne = new MyClass(1);

            Dictionary<MyClass, int> MyDictionary = new Dictionary<MyClass, int>();
            MyDictionary.Add(One, 1);

            Assert.IsFalse(MyDictionary.ContainsKey(AnotherOne));
        }
        [TestMethod]
        public void DictionaryWithEquality()
        {
            MyClassWithEquality One = new MyClassWithEquality(1);
            MyClassWithEquality AnotherOne = new MyClassWithEquality(1);

            Dictionary<MyClassWithEquality, int> MyDictionary = new Dictionary<MyClassWithEquality, int>();
            MyDictionary.Add(One, 1);

            Assert.IsTrue(MyDictionary.ContainsKey(AnotherOne));
        }
        [TestMethod]
        public void DictionaryWithEqualityHandlesNull()
        {
            var one = new MyClassWithEquality(1);

            Assert.IsFalse(one.Equals((MyClassWithEquality?)null));
            Assert.IsFalse(one.Equals((object?)null));
            Assert.IsTrue(EqualityComparer<MyClassWithEquality>.Default.Equals(one, new MyClassWithEquality(1)));
        }
    }
}
