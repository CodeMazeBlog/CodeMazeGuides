using System.Linq.Expressions;

namespace ExpressionTreeInCsharp
{
    public class CustomExpressionVisitor : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }
        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b.NodeType is ExpressionType.OrElse)
            {
                var left = Visit(b.Left);
                var right = Visit(b.Right);

                return Expression.MakeBinary(ExpressionType.AndAlso, left, right, b.IsLiftedToNull, b.Method);
            }

            return base.VisitBinary(b);
        }
    }

}
