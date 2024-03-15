using DeleteElementsFromAnArray;

namespace Tests 
{
    [TestClass]
    public class DefaultValueFromDictionaryUnitTests 
    {
        private readonly int[] _myArray = new int[] { 3, 4, 5, 3, 5, 7 };

        [TestMethod]
        public void GivenMethodFindAll_WhenDeleteElement3_ThenArray4557() 
        {
            var key = 3;
            var expectedResult = new int[] { 4, 5, 5, 7 };
            var value = Methods.DeleteWithFindAll(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }


        [TestMethod]
        public void GivenMethodFindAll_WhenDeleteElement6_ThenArray345357() 
        {
            var key = 6;
            var expectedResult = new int[] { 3, 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithFindAll(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodWhere_WhenDeleteElement3_ThenArray4557() 
        {
            var key = 3;
            var expectedResult = new int[] { 4, 5, 5, 7 };
            var value = Methods.DeleteWithWhere(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodWhere_WhenDeleteElement6_ThenArray345357() 
        {
            var key = 6;
            var expectedResult = new int[] { 3, 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithWhere(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodRemoveAll_WhenDeleteElement3_ThenArray4557() 
        {
            var key = 3;
            var expectedResult = new int[] { 4, 5, 5, 7 };
            var value = Methods.DeleteWithRemoveAll(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodRemoveAll_WhenDeleteElement6_ThenArray345357() 
        {
            var key = 6;
            var expectedResult = new int[] { 3, 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithRemoveAll(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodLoop_WhenDeleteElement3_ThenArray45357() 
        {
            var key = 3;
            var expectedResult = new int[] { 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithLoop(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodLoop_WhenDeleteElement6_ThenArray345357() 
        {
            var key = 6;
            var expectedResult = new int[] { 3, 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithLoop(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodArrayCopy_WhenDeleteElement3_ThenArray45357() {
            var key = 3;
            var expectedResult = new int[] { 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithArrayCopy(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodArrayCopy_WhenDeleteElement6_ThenArray345357() {
            var key = 6;
            var expectedResult = new int[] { 3, 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithArrayCopy(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodArraySegment_WhenDeleteElement3_ThenArray4557() 
        {
            var key = 3;
            var expectedResult = new int[] { 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithArraySegment(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodArraySegment_WhenDeleteElement6_ThenArray345357() {
            var key = 6;
            var expectedResult = new int[] { 3, 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithArraySegment(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodBufferCopy_WhenDeleteElement3_ThenArray45357()
        {
            var key = 3;
            var expectedResult = new int[] { 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithBufferCopy(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodBufferCopy_WhenDeleteElement6_ThenArray345357()
        {
            var key = 6;
            var expectedResult = new int[] { 3, 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithBufferCopy(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodList_WhenDeleteElement3_ThenArray4557()
        {
            var key = 3;
            var expectedResult = new int[] { 4, 5, 5, 7 };
            var value = Methods.DeleteWithList(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenMethodList_WhenDeleteElement6_ThenArray345357()
        {
            var key = 6;
            var expectedResult = new int[] { 3, 4, 5, 3, 5, 7 };
            var value = Methods.DeleteWithList(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }

        [TestMethod]
        public void GivenPooledArray_WhenDeleteElement3_ThenArray4557()
        {
            var key = 3;
            var expectedResult = new int[] { 4, 5, 5, 7 };
            var value = Methods.DeleteWithPooledArray(_myArray, key);

            CollectionAssert.AreEqual(value, expectedResult);
        }
    }
}