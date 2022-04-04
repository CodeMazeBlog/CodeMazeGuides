using HowToDetectIfADictionaryKeyExistsInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

            Assert.IsTrue(SetOnceDictionary["Apple"] == 2);
            Assert.IsTrue(SetOnceDictionary["Banana"] == 3);
            Assert.IsTrue(SetOnceDictionary["Kiwi"] == 4);
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
            Assert.IsTrue(apples == 3);
            
            // Throws an exception!
            try
            {
                int kiwis = MyDictionary["Kiwi"];
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is KeyNotFoundException);
            }
            
            // Good practice
            int oranges = 0;
            if (MyDictionary.ContainsKey("Orange"))
            {
                oranges = MyDictionary["Orange"]; // 5
            }
            Assert.IsTrue(oranges == 5);
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

            Assert.IsTrue(Apples == 3);
            Assert.IsTrue(Kiwi == 0);
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
    }
}
