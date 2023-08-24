namespace VisitorPatternTests
{
    public class ConcreteElementOne : IVisitableElement
    {
        public string ElementOneData { get; } = "The Ultimate Answer To Everything: ";
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}