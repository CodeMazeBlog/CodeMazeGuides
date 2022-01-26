using CopyArrayElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private readonly ElementCopier _elementCopier;
        
        public Tests()
        {
            _elementCopier = new ElementCopier();
        }

        [TestMethod]
        public void GivenTheClassProgram_ThenRunTheMainMethodAndWriteResultsAtTheConsole()
        {
            Program.Main(new string[]{ });

            Assert.AreEqual(1, Program.OutputResult);
        }

        [TestMethod]
        public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingAssignment()
        {
            var initialArray = Program.InstantiateInitialArray();

            var destinationArray = _elementCopier.CopyUsingAssignment(initialArray);

            Assert.AreSame(initialArray, destinationArray);
        }

        [TestMethod]
        public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingArrayClass()
        {
            var initialArray = Program.InstantiateInitialArray();

            var destinationArray = _elementCopier.CopyUsingArrayClass(initialArray);

            //Not returning the same array
            Assert.AreNotSame(initialArray, destinationArray);
            //The size of both array are equals
            Assert.AreEqual(initialArray.Length, destinationArray.Length);
            //It made a shallow Copy
            Assert.AreSame(initialArray[0], destinationArray[0]);
        }

        [TestMethod]
        public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingClone()
        {
            var initialArray = Program.InstantiateInitialArray();

            var destinationArray = _elementCopier.CopyUsingClone(initialArray);

            Assert.AreNotSame(initialArray, destinationArray);
            Assert.AreEqual(initialArray.Length, destinationArray.Length);
            Assert.AreSame(initialArray[0], destinationArray[0]);
        }

        [TestMethod]
        public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingCopyTo()
        {
            var initialArray = Program.InstantiateInitialArray();

            var destinationArray = _elementCopier.CopyUsingCopyTo(initialArray);

            Assert.AreNotSame(initialArray, destinationArray);
            Assert.AreEqual(initialArray.Length, destinationArray.Length);
            Assert.AreSame(initialArray[0], destinationArray[0]);
        }

        [TestMethod]
        public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingRange()
        {
            var initialArray = Program.InstantiateInitialArray();

            var destinationArray = _elementCopier.CopyUsingRange(initialArray);

            Assert.AreNotSame(initialArray, destinationArray);
            Assert.AreEqual(initialArray.Length, destinationArray.Length);
            Assert.AreSame(initialArray[0], destinationArray[0]);
        }

        [TestMethod]
        public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingLinq()
        {
            var initialArray = Program.InstantiateInitialArray();

            var destinationArray = _elementCopier.CopyUsingLinq(initialArray);

            Assert.AreNotSame(initialArray, destinationArray);
            Assert.AreEqual(initialArray.Length, destinationArray.Length);
            //In this case, we are not doing shallow copy, but deep copy
            Assert.AreNotSame(initialArray[0], destinationArray[0]);
        }

        [TestMethod]
        public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodManuallyCopy()
        {
            var initialArray = Program.InstantiateInitialArray();

            var destinationArray = _elementCopier.ManuallyCopy(initialArray);

            Assert.AreNotSame(initialArray, destinationArray);
            Assert.AreEqual(initialArray.Length, destinationArray.Length);
            Assert.AreNotSame(initialArray[0], destinationArray[0]);
        }
    }
}