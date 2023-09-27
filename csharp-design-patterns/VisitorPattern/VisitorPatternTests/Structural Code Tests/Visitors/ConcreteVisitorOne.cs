namespace VisitorPatternTests
{
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
}