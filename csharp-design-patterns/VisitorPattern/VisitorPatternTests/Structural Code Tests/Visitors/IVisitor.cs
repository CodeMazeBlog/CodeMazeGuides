namespace VisitorPatternTests
{
    public interface IVisitor
    {
        void Visit(ConcreteElementOne element);
        void Visit(ConcreteElementTwo element);
    }
}