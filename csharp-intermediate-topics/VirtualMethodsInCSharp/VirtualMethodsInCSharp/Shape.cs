namespace VirtualMethodsInCSharp
{
    public class Shape
    {
        public virtual double CalculateArea()
        {
            return 0;
        }

        public virtual string GetShapeType()
        {
            return "This is a generic shape";
        }

        public string Draw()
        {
            return "Drawing a generic shape";
        }
    }
}