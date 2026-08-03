namespace VisitorPatternTests
{
    public interface IVisitableElement
    {
        void Accept(IVisitor visitor);
    }
}