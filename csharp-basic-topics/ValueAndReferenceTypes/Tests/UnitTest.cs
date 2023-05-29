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
            firstRectangle.MyShape = new Shape { Name = "Square" };

            var secondRectangle = firstRectangle;

            firstRectangle.Length = 20;
            firstRectangle.Breadth = 20;
            firstRectangle.MyShape.Name = "Circle";

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
        public void WhenValueTypesPassByValue_ThenCounterHaveDifferentCopies()
        {
            var pass = new PassByValueAndReferenceSample();
            int counter = 100;
            pass.PassValueTypesByValue(counter);

            Assert.AreEqual(100, counter);
        }

        [TestMethod]
        public void WhenReferenceTypesPassByValue_ThenCounterHaveDifferentCopies()
        {
            var pass = new PassByValueAndReferenceSample();
            ReferenceTypeRectangle rect = new ReferenceTypeRectangle { Length = 20, Breadth = 20 };
            pass.PassReferenceTypesByValue(rect);
            Console.WriteLine($"Value outside after call Length = {rect.Length}, Breadth = {rect.Breadth} ");

            Assert.AreEqual(400, rect.Length * rect.Breadth);
        }


        [TestMethod]
        public void WhenValueTypesPassByReference_ThenCounterHaveReferenceToSameAddress()
        {
            var pass = new PassByValueAndReferenceSample();
            int counter = 100;
            pass.PassValueTypesByReference(ref counter);

            Assert.AreEqual(101, counter);
        }

        [TestMethod]
        public void WhenReferenceTypesPassByReference_ThenCounterHaveReferenceToSameAddress()
        {
            var pass = new PassByValueAndReferenceSample();
            ReferenceTypeRectangle rect = new ReferenceTypeRectangle { Length = 20, Breadth = 20 };
            pass.PassReferenceTypesByReference(rect);
            Console.WriteLine($"Value outside after call Length = {rect.Length}, Breadth = {rect.Breadth} ");

            Assert.AreEqual(100, rect.Length * rect.Breadth);
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