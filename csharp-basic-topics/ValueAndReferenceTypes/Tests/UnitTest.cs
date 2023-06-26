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
        public void WhenValueTypeArguments_ThenLengthHaveDifferentCopies()
        {
            var pass = new ValueAndReferenceAsMethodArgumentsSample();
            ValueTypeRectangle rect = new ValueTypeRectangle { Length = 20};
            pass.ValueTypeArguments(rect);

            Assert.AreEqual(20, rect.Length);
        }

        [TestMethod]
        public void WhenReferenceTypeArguments_ThenLengthHaveSameReference()
        {
            var pass = new ValueAndReferenceAsMethodArgumentsSample();
            ReferenceTypeRectangle rect = new ReferenceTypeRectangle { Length = 20 };
            pass.ReferenceTypeArguments(rect);

            Assert.AreEqual(21, rect.Length);
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
        public void WhenReferenceTypes_ThenAllObjectsAreAffected()
        {
            var firstRectangle = new ValueTypeRectangle();
            firstRectangle.MyShape = new Shape { Name = "Square" };

            var secondRectangle = firstRectangle;
            secondRectangle.MyShape.Name = "Circle";

            Console.WriteLine($"First rectangle shape -> {firstRectangle.MyShape.Name}");
            Console.WriteLine($"Second rectangle shape -> {secondRectangle.MyShape.Name}");

            Assert.AreEqual(firstRectangle.MyShape.Name, secondRectangle.MyShape.Name);
        }
    }
}