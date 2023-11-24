namespace VisitorPatternTests
{
    public class ConcreteElementTwo : IVisitableElement
    {
        public int ElementTwoData { get; } = 42;

        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}