using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValueAndReferenceTypes;
namespace Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void WhenValueType_ThenBothRectanglesHaveSeparateCopies()
        {
            var firstRectangle = new ValueTypeRectangle();
            firstRectangle.length = 10;
            firstRectangle.breadth = 10;

            var secondRectangle = firstRectangle;

            firstRectangle.length = 20;
            firstRectangle.breadth = 20;

            Assert.AreNotEqual(firstRectangle.Area(), secondRectangle.Area());
        }

        [TestMethod]
        public void WhenReferenceType_ThenBothRectanglesHaveReferencesToSameAddress()
        {
            var firstRectangle = new ReferenceTypeRectangle();
            firstRectangle.length = 10;
            firstRectangle.breadth = 10;

            var secondRectangle = firstRectangle;

            firstRectangle.length = 20;
            firstRectangle.breadth = 20;

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
        public void When_BoxingUnBoxing()
        {
            var conv = new BoxingAndUnboxing();
            int input = 500;
            var output = conv.BoxingUnBoxing(input);

            Assert.AreEqual(output, input);
        }

        [TestMethod]
        public void When_StringAreReferenceType()
        {
            var str = new StringSample();
            var result = str.PrintWords();

            Assert.AreEqual("CodeMaze", result);
        }
    }
}