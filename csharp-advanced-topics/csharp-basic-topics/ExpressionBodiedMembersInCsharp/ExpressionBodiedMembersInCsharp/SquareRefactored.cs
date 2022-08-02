namespace ExpressionBodiedMembersInCsharp
{
    public class SquareRefactored
    {
        private double _side;

        public SquareRefactored(double side)
        {
            _side = side;
        }

        public double Area => Math.Pow(_side, 2);
    }
}