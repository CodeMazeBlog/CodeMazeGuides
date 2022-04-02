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
        [InlineData(17)]
        public void GivenNumber_WhenItIsNotEvenOrMultipleOfThree_ThenItReturnFalse(int number)
        {
            Func<int, bool> isEvenOrMultipleOfThree = _utility.EvenOrMultipleOfThree();
            var result = isEvenOrMultipleOfThree(number);

            Assert.False(result);
        }

        [Theory]
        [InlineData(9)]
        [InlineData(4)]
        public void GivenNumber_WhenItIsEvenOrMultipleOfThree_ThenItReturnTrue(int number)
        {
            Func<int, bool> isEvenOrMultipleOfThree = _utility.EvenOrMultipleOfThree();
            var result = isEvenOrMultipleOfThree(number);

            Assert.True(result);
        }

        [Fact]
        public void WhenCallCreateTheExpressionTree_ThenItCreatesTheExpressionTypeOrElse()
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
        public void GivenEvenOrMultipleOfThreeNumber_WhenExpressionTypeIsAnd_ThenItReturnsFalse(int number)
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            var expr = _utility.CreateExpression(parameter);
            var treeModifier = new CustomExpressionVisitor();
            var modifiedExpr = treeModifier.Modify(expr);

            Func<int, bool> isEvenAndMultipleOfThree = Expression.Lambda<Func<int, bool>>(modifiedExpr, parameter).Compile();
            var result = isEvenAndMultipleOfThree(number);

            Assert.False(result);
        }

        [Theory]
        [InlineData(18)]
        [InlineData(6)]
        public void GivenEvenAndMultipleOfThreeNumber_WhenExpressionTypeIsAnd_ThenItReturnsTrue(int number)
        {
            var parameter = Expression.Parameter(typeof(int), "x");
            var expr = _utility.CreateExpression(parameter);
            var treeModifier = new CustomExpressionVisitor();
            var modifiedExpr = treeModifier.Modify(expr);

            Func<int, bool> isEvenAndMultipleOfThree = Expression.Lambda<Func<int, bool>>(modifiedExpr, parameter).Compile();
            var result = isEvenAndMultipleOfThree(number);

            Assert.True(result);
        }
    }
}