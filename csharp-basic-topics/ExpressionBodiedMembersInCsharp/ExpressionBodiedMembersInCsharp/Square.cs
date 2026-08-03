namespace ExpressionBodiedMembersInCsharp
{
    public class Square
    {
        private double _side;

        public Square(double side)
        {
            _side = side;
        }

        public double CalculateArea() => Math.Pow(_side, 2);
    }
}