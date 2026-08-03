using NUnit.Framework;

namespace VisitorPatternTests
{
    [TestFixture]
    public class StructuralCodeTests
    {
        [Test]
        public void WhenProcessedElementsThenCorrectAnswerProduced()
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