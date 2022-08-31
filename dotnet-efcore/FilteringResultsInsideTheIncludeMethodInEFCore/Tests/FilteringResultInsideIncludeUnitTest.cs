using FilteringResultsInsideInclude;
using FilteringResultsInsideInclude.Models;
using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class FilteringResultInsideIncludeUnitTest
    {
        [Fact]
        public void WhenUsingNotSupportedMethod_ThenFailsWithAInvalidOperationException()
        {
            var context = new AppDbContext();

            Assert.Throws<InvalidOperationException>(
                () => Queries.NotSupportedMethod(context)
            ); 
        }

        [Fact]
        public void WhenUsingStandAloneFilter_ThenSuccess()
        {
            var context = new AppDbContext();
            var actual = Queries.StandAloneFilter(context);

            var expected = Queries.CourseCount;

            Assert.Equal(expected, actual.Count);
        }

        [Fact]
        public void WhenUsingNotStandAloneFilter_ThenFailsWithAInvalidOperationException()
        {
            var context = new AppDbContext();

            Assert.Throws<InvalidOperationException>(
                () => Queries.NotStandAloneFilter(context)
            );
        }

        [Fact]
        public void WhenUsingAOneFilterPerNavigationOnMultipleInclude_ThenSuccess()
        {
            var context = new AppDbContext();

            var actual = Queries.RightFilteringOnMultipleInclude(context);

            Assert.Equal(actual.Item1.Count, actual.Item2.Count);
        }

        [Fact]
        public void WhenUsingMoreThanFilteringOnMultipleInclude_ThenFailsWithAInvalidOperationException()
        {
            var context = new AppDbContext();

            Assert.Throws<InvalidOperationException>(
                () => Queries.BadFilteringOnMultipleInclude(context)
            );
        }

        [Fact]
        public void WhenFilteringOnIncludeWithTrackingQueries_ThenAggregatesTheResults1()
        {
            var context = new AppDbContext();
            var acutal = Queries.FilteredIncludeWithTrackingQueries1(context);
            var courses1 = acutal.Item1;
            var courses2 = acutal.Item2;

            var expected = Queries.CourseCount;

            Assert.True(courses1.Count == expected && courses2.Count == expected);
        }

        [Fact]
        public void WhenFilteringOnIncludeWithTrackingQueries_ThenAggregatesTheResults2()
        {
            var context = new AppDbContext();
            var actual = Queries.FilteredIncludeWithTrackingQueries2(context);

            var expected = Queries.CourseCount;

            Assert.Equal(expected, actual.Count);
        }

        [Fact]
        public void WhenUsingSelectMethodWithFilteredInclude_ThenTheFilterIgnores()
        {
            var context = new AppDbContext();
            var actual = Queries.FilteringInsideIncludeAndSelectMethod(context);

            var expected = Queries.CourseCount * Queries.StudentCountPerCourse;

            Assert.Equal(expected, actual.Sum(x => x.Count));
        }

        [Fact]
        public void WhenUsingFilterInsideSelectMethodWithoutInclude_ThenTheFilterApplies()
        {
            var context = new AppDbContext();
            var actual = Queries.FilteringInsideSelectMethodWithoutInclude(context);

            var expected = Queries.CourseCount * (Queries.StudentCountPerCourse / 2);

            Assert.Equal(expected, actual.Sum(x => x.Count));
        }

    }
}