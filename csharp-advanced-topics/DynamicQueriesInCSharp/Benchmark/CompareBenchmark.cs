using BenchmarkDotNet.Attributes;
using DynamicQueriesInCSharp.Context;
using DynamicQueriesInCSharp.Entities;
using DynamicQueriesInCSharp.Queries;
using System.Linq.Expressions;

namespace Benchmark
{
    public class CompareBenchmark
    {
        private readonly ApplicationDbContext _context;

        public CompareBenchmark()
        {
            _context = new ContextFactory().CreateDbContext();
        }

        private static readonly Expression<Func<Person, bool>> _equalDynamic =
            ExpressionQueries.GetEqualExpression();

        [Benchmark]
        public void EqualDynamic()
        {
            _context.Persons.Where(_equalDynamic).ToList();
        }

        private static readonly Expression<Func<Person, bool>> _equalLambda =
            LambdaQueries.GetEqualExpression();

        [Benchmark]
        public void EqualLambda()
        {
            _context.Persons.Where(_equalLambda).ToList();
        }

        private static readonly Expression<Func<Person, bool>> _equalConjuctionDynamic =
            ExpressionQueries.GetEqualConjuctionExpression();

        [Benchmark]
        public void EqualConjuctionDynamic()
        {
            _context.Persons.Where(_equalConjuctionDynamic).ToList();
        }

        private static readonly Expression<Func<Person, bool>> _equalConjuctionLambda =
            LambdaQueries.GetEqualConjuctionExpression();

        [Benchmark]
        public void EqualConuctionLambda()
        {
            _context.Persons.Where(_equalConjuctionLambda).ToList();
        }

        private static readonly Expression<Func<Person, bool>> _containsDynamic =
           ExpressionQueries.GetContainsExpression();

        [Benchmark]
        public void ContainsDynamic()
        {
            _context.Persons.Where(_containsDynamic).ToList();
        }

        private static readonly Expression<Func<Person, bool>> _containsLambda =
           LambdaQueries.GetContainsExpression();

        [Benchmark]
        public void ContainsLambda()
        {
            _context.Persons.Where(_containsLambda).ToList();
        }


        private static readonly Expression<Func<Person, bool>> _inDynamic =
           ExpressionQueries.GetInExpression();

        [Benchmark]
        public void InDynamic()
        {
            _context.Persons.Where(_inDynamic).ToList();
        }

        private static readonly Expression<Func<Person, bool>> _inLambda =
           LambdaQueries.GetInExpression();

        [Benchmark]
        public void Inlambda()
        {
            _context.Persons.Where(_inLambda).ToList();
        }

        private static readonly Expression<Func<Person, bool>> _nestedDynamic =
            ExpressionQueries.GetNestedExpression();

        [Benchmark]
        public void NestedDynamic()
        {
            _context.Persons.Where(_nestedDynamic).ToList();
        }

        private static readonly Expression<Func<Person, bool>> _nestedlambda =
           LambdaQueries.GetNestedExpression();

        [Benchmark]
        public void NestedLambda()
        {
            _context.Persons.Where(_nestedlambda).ToList();
        }

        private static readonly Expression<Func<Person, bool>> _betweenDynamic =
            ExpressionQueries.GetBetweenExpression();

        [Benchmark]
        public void BetweenDynamic()
        {
            _context.Persons.Where(_betweenDynamic).ToList();
        }

        private static readonly Expression<Func<Person, bool>> _betweenLambda =
            LambdaQueries.GetBetweenExpression();

        [Benchmark]
        public void BetweenLambda()
        {
            _context.Persons.Where(_betweenLambda).ToList();
        }
    }
}
