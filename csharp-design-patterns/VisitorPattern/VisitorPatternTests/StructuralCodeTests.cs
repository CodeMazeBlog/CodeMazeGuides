using NUnit.Framework;

namespace VisitorPatternTests
{
    [TestFixture]
    public class StructuralCodeTests
    {
        public interface IVisitor
        {
            void Visit(ConcreteElementOne element);
            void Visit(ConcreteElementTwo element);
        }
        public interface IVisitableElement
        {
            void Accept(IVisitor visitor);
        }

        #region Concrete elements
        public class ConcreteElementOne : IVisitableElement
        {
            public string ElementOneData { get; } = "The Ultimate Answer To Everything: ";
            public void Accept(IVisitor visitor) => visitor.Visit(this);
        }
        public class ConcreteElementTwo : IVisitableElement
        {
            public int ElementTwoData { get; } = 42;

            public void Accept(IVisitor visitor) => visitor.Visit(this);
        }
        #endregion

        #region Concrete visitors
        public class ConcreteVisitorOne : IVisitor
        {
            public void Visit(ConcreteElementOne element)
            {
                Console.Write(element.ElementOneData);
            }

            public void Visit(ConcreteElementTwo element)
            {
                Console.Write(element.ElementTwoData);
            }
        }

        #endregion

        [Test]
        public void SimpleScenarioTest()
        {
            //capture console output to assert test results
            using var sw = new StringWriter();
            Console.SetOut(sw);

            //arrange
            var elements = new IVisitableElement[] { new ConcreteElementOne(), new ConcreteElementTwo() };
            var visitor = new ConcreteVisitorOne();

            //act
            UseTheVisitorPattern(elements, visitor);

            //assert
            Assert.AreEqual("The Ultimate Answer To Everything: 42", sw.ToString());

            static void UseTheVisitorPattern(IVisitableElement[] elements, IVisitor visitor)
            {
                foreach (var element in elements)
                {
                    switch (element)
                    {
                        case ConcreteElementOne one: visitor.Visit(one); break;
                        case ConcreteElementTwo two: visitor.Visit(two); break;
                    }
                }
            }
        }
    }
}