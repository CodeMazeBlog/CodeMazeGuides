using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValueAndReferenceTypes;
namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void WhenValueType_ThenBothRectanglesHaveSeparateCopies()
        {
            var firstRectangle = new ValueTypeRectangle();
            firstRectangle.Length = 10;
            firstRectangle.Breadth = 10;

            var secondRectangle = firstRectangle;

            firstRectangle.Length = 20;
            firstRectangle.Breadth = 20;

            Assert.AreNotEqual(firstRectangle.Area(), secondRectangle.Area());
        }

        [TestMethod]
        public void WhenReferenceType_ThenBothRectanglesHaveReferencesToSameAddress()
        {
            var firstRectangle = new ReferenceTypeRectangle();
            firstRectangle.Length = 10;
            firstRectangle.Breadth = 10;

            var secondRectangle = firstRectangle;

            firstRectangle.Length = 20;
            firstRectangle.Breadth = 20;

            Assert.AreEqual(firstRectangle.Area(), secondRectangle.Area());
        }

        [TestMethod]
        public void WhenPassByValue_ThenCounterHaveDifferentCopies()
        {
            var pass = new PassByValueAndReferenceSample();
            int counter = 100;
            pass.PassByValue(counter);

            Assert.AreEqual(100, counter);
        }

        [TestMethod]
        public void WhenPassByReference_ThenCounterHaveReferenceToSameAddress()
        {
            var pass = new PassByValueAndReferenceSample();
            int counter = 100;
            pass.PassByReference(ref counter);

            Assert.AreEqual(101, counter);
        }

        [TestMethod]
        public void WhenBoxingUnBoxing_ThenValueToReferenceAndReferenceToValueConversion()
        {
            var conv = new BoxingAndUnboxing();
            int input = 500;
            var output = conv.BoxingUnBoxing(input);

            Assert.AreEqual(output, input);
        }

        [TestMethod]
        public void WhenString_ThenReferenceType()
        {
            var str = new StringSample();
            var result = str.PrintWords();

            Assert.AreEqual("CodeMaze", result);
        }
    }
}