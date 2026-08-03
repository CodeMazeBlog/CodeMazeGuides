using System.Collections;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void WhenGivenIEnumerableOnCast_ThenConvertToTResult()
        {
            var primes = new ArrayList
            {
                5,
                3,
                2,
                7
            };

            var primeQuery = primes.Cast<int>().OrderBy(prime => prime).Select(prime => prime);

            var expected = new List<int> { 2, 3, 5, 7 };

            Assert.Equal(expected, primeQuery);
        }

        [Fact]
        public void WhenGivenIEnumerableOnOfType_ThenFilterOnTResult()
        {
            var cities = new ArrayList
            {
                "London",
                "Paris",
                "Madrid",
                "Berlin",
                7,
                "Lisbon"
            };

            var cityQuery = cities.OfType<string>();

            var expected = new List<string> { "London", "Paris", "Madrid", "Berlin", "Lisbon" };

            Assert.Equal(expected, cityQuery);
        }

        [Fact]
        public void WhenGivenIEnumerableOnOfType_ThenCanUseStandardQueryOperators()
        {
            var cities = new ArrayList
            {
                "London",
                "Paris",
                "Madrid",
                "Berlin",
                7,
                "Lisbon",
                8,
                12
            };

            var evens = cities.OfType<int>().Where(x => x % 2 == 0);

            var expected = new List<int> { 8, 12 };

            Assert.Equal(expected, evens);
        }

        [Fact]
        public void WhenGivenIEnumerableOnAsParallel_ThenConvertToParallelQuery()
        {
            var numbers = Enumerable.Range(0, 100);

            var oddsCount = numbers.AsParallel().Count(x => x % 2 != 0);

            var expected = 50;

            Assert.Equal(expected, oddsCount);
        }

        [Fact]
        public void WhenGivenIEnumerableOnAsQueryable_ThenConvertToQueryable()
        {
            var numbers = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            var query = numbers.AsQueryable();

            var multiplesOf3 = query.Where(x => x % 3 == 0);

            var expected = new List<int> { 3, 6, 9 };

            Assert.Equal(expected, multiplesOf3);

            Assert.Equal("Constant", query.Expression.NodeType.ToString());
        }
    }
}