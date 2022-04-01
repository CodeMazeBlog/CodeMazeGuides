using ExpressionTreeInCsharp;
using System;
using System.Linq.Expressions;
using Xunit;

namespace Tests
{
    public class ExpressionTreeTests
    {
        private readonly ExpressionUtility _utility = new ExpressionUtility();

        [Theory]
        [InlineData(5)]
        public void WhenIsNotEvenOrMultipleOfThree_ThenItReturnFalse(int number)
        {
            Func<int, bool> isEvenOrMultipleOfThree = _utility.EvenOrMultipleOfThree();
            var result = isEvenOrMultipleOfThree(number);

            Assert.False(result);

        }

        [Theory]
        [InlineData(9)]
        [InlineData(4)]
        public void GivenCorrectNumbers_WhenIsEvenOrMultipleOfThree_ThenItReturnTrue(int number)
        {
            Func<int, bool> isEvenOrMultipleOfThree = _utility.EvenOrMultipleOfThree();
            var result = isEvenOrMultipleOfThree(number);

            Assert.True(result);
        }

        [Fact]
        public void WhenCreateTheExpressionTree_ThenTheExpressionTypeOrElse()
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            var expr = _utility.CreateExpression(parameter);

            Assert.Equal("(((x % 3) == 0) OrElse ((x % 2) == 0))", expr.ToString());
        }

        [Fact]
        public void WhenTheExpressionTreeIsModified_ThenTheExpressionTypeIsAnd()
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            var expr = _utility.CreateExpression(parameter);
            var treeModifier = new CustomExpressionVisitor();
            var modifiedExpr = treeModifier.Modify(expr);

            Assert.Equal("(((x % 3) == 0) AndAlso ((x % 2) == 0))", modifiedExpr.ToString());
        }

        [Theory]
        [InlineData(9)]
        [InlineData(4)]
        public void GivenIncorrectNumbers_WhenIsEvenAndMultipleOfThree_ThenItReturnFalse(int number)
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            var expr = _utility.CreateExpression(parameter);
            var treeModifier = new CustomExpressionVisitor();
            var modifiedExpr = treeModifier.Modify(expr);

            Func<int, bool> isEvenAndMultipleOfThree = Expression.Lambda<Func<int, bool>>(modifiedExpr, parameter).Compile();
            var result = isEvenAndMultipleOfThree(number);

            Assert.False(result);
        }
    }
}