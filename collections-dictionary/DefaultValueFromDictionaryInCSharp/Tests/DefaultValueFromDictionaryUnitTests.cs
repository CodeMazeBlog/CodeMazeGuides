using DefaultValueFromDictionaryInCSharp.MethodContainsKey;
using DefaultValueFromDictionaryInCSharp.MethodGetValueOrDefault;
using DefaultValueFromDictionaryInCSharp.MethodGetValueOrDefaultWithFallback;
using DefaultValueFromDictionaryInCSharp.MethodTryGetValue;

namespace Tests
{
    [TestClass]
    public class DefaultValueFromDictionaryUnitTests
    {
        private readonly Dictionary<string, int> _myDictionary = new Dictionary<string, int> {
            {"alice", 1 },
            {"bob", 2 },
            {"tom", 3 }
        };

        [TestMethod]
        public void GivenMethodGetValueOrDefault_WhenKeyNotExisting_ThenDefaultValueZero()
        {
            var key = "sam";
            var value = MethodGetValueOrDefault.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void GivenMethodGetValueOrDefault_WhenKeyBob_ThenValueTwo()
        {
            var key = "bob";
            var value = MethodGetValueOrDefault.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(2, value);
        }

        [TestMethod]
        public void GivenMethodTryGetValue_WhenKeyNotExisting_ThenDefaultValueZero()
        {
            var key = "sam";
            var value = MethodTryGetValue.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void GivenMethodTryGetValue_WhenKeyBob_ThenValueTwo()
        {
            var key = "bob";
            var value = MethodTryGetValue.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(2, value);
        }

        [TestMethod]
        public void GivenMethodContainsKey_WhenKeyNotExisting_ThenDefaultValueZero()
        {
            var key = "sam";
            var value = MethodContainsKey.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void GivenMethodContainsKey_WhenKeyBob_ThenValueTwo()
        {
            var key = "bob";
            var value = MethodContainsKey.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(2, value);
        }

        [TestMethod]
        public void GivenMethodGetValueOrDefaultWithFallback_WhenKeyNotExisting_ThenFallbackValue()
        {
            var key = "sam";
            var value = MethodGetValueOrDefaultWithFallback.GetValueFromDictionary(_myDictionary, key, -1);

            Assert.AreEqual(-1, value);
        }

        [TestMethod]
        public void GivenMethodGetValueOrDefaultWithFallback_WhenStoredValueEqualsFallback_ThenSameResultAsMissingKey()
        {
            var dictionary = new Dictionary<string, int> { { "neg", -1 } };

            var stored = MethodGetValueOrDefaultWithFallback.GetValueFromDictionary(dictionary, "neg", -1);
            var missing = MethodGetValueOrDefaultWithFallback.GetValueFromDictionary(dictionary, "gone", -1);

            Assert.AreEqual(-1, stored);
            Assert.AreEqual(-1, missing);
            Assert.AreEqual(stored, missing);
        }

        [TestMethod]
        public void GivenFirstOrDefault_WhenKeyNotExisting_ThenDefaultKeyValuePairNotNull()
        {
            var searchKey = "sam";

            var pair = _myDictionary.FirstOrDefault(p => p.Key == searchKey);

            Assert.AreEqual(default(KeyValuePair<string, int>), pair);
            Assert.IsNull(pair.Key);
            Assert.AreEqual(0, pair.Value);
        }
    }
}
