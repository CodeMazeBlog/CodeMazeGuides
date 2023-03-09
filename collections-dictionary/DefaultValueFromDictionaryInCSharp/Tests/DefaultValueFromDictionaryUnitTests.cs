using DefaultValueFromDictionaryInCSharp.MethodGetValueOrDefault;

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

            Assert.AreEqual(value, 0);
        }

        [TestMethod]
        public void GivenMethodGetValueOrDefault_WhenKeyBob_ThenValueTwo()
        {
            var key = "bob";
            var value = MethodGetValueOrDefault.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(value, 2);
        }

        [TestMethod]
        public void GivenMethodTryGetValue_WhenKeyNotExisting_ThenDefaultValueZero()
        {
            var key = "sam";
            var value = MethodGetValueOrDefault.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(value, 0);
        }

        [TestMethod]
        public void GivenMethodTryGetValue_WhenKeyBob_ThenValueTwo()
        {
            var key = "bob";
            var value = MethodGetValueOrDefault.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(value, 2);
        }

        [TestMethod]
        public void GivenMethodContainsKey_WhenKeyNotExisting_ThenDefaultValueZero()
        {
            var key = "sam";
            var value = MethodGetValueOrDefault.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(value, 0);
        }

        [TestMethod]
        public void GivenMethodContainsKey_WhenKeyBob_ThenValueTwo()
        {
            var key = "bob";
            var value = MethodGetValueOrDefault.GetValueFromDictionary(_myDictionary, key);

            Assert.AreEqual(value, 2);
        }
    }
}