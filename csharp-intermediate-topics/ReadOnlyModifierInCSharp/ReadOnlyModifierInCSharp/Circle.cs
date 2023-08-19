namespace ReadOnlyModifierInCSharp
{
    public class Circle
    {
        private readonly double _radius;

        public double Area
        {
            get { return Math.PI * _radius * _radius; }
        }

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double GetCircumference()
        {
            return 2 * Math.PI * _radius;
        }

        public void ModifyRadius()
        {
            //_radius = _radius + 2; //Throws Compiler Error
        }
    }
}
