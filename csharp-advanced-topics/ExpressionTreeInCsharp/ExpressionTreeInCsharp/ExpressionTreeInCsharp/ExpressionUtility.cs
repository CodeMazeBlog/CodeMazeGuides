using System.Linq.Expressions;

namespace ExpressionTreeInCsharp
{
    public class ExpressionUtility
    {
        public BinaryExpression CreateExpression(ParameterExpression parameter)
        {
            var valueType = typeof(int);

            var moduloThree = Expression.Modulo(parameter, Expression.Constant(3, valueType));
            var moduloEven = Expression.Modulo(parameter, Expression.Constant(2, valueType));
            var multipleOfThree = Expression.Equal(moduloThree, Expression.Constant(0, valueType));
            var even = Expression.Equal(moduloEven, Expression.Constant(0, valueType));
            var binaryExpression = Expression.OrElse(multipleOfThree, even);

            return binaryExpression;
        }
        public Func<int, bool> EvenOrMultipleOfThree()
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            var isEvenOrMultipleOfThreeExpression = CreateExpression(parameter);
            Func<int, bool> isEvenOrMultipleOfThree = Expression.Lambda<Func<int, bool>>(isEvenOrMultipleOfThreeExpression, parameter).Compile();

            return isEvenOrMultipleOfThree;
        }

    }
}