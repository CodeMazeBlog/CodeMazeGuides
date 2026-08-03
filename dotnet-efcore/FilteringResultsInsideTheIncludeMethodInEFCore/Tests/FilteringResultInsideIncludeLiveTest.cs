using FilteringResultsInsideInclude;
using FilteringResultsInsideInclude.Models;
using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class FilteringResultInsideIncludeLiveTest
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
            var actual = Queries.GoodFilteringOnMultipleInclude(context);

            var expected = Queries.CourseCount * (Queries.StudentCountPerCourse / 2);

            Assert.Equal(expected, actual.Sum(x => x.Students!.Count()));
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
            var actual = Queries.FilteredIncludeWithTrackingQueries1(context);
            var students1 = actual.Item1.SelectMany(x => x.Students!).ToList();
            var students2 = actual.Item2.SelectMany(x => x.Students!).ToList();

            var expected = Queries.CourseCount * Queries.StudentCountPerCourse;

            Assert.True(students1.Count == expected && students2.Count == expected);
        }

        [Fact]
        public void WhenFilteringOnIncludeWithNotTrackingQueries_ThenTheResults()
        {
            var context = new AppDbContext();
            var actual = Queries.FilteredIncludeWithNotTrackingQueries(context);
            var students1 = actual.Item1.SelectMany(x => x.Students!).ToList();
            var students2 = actual.Item2.SelectMany(x => x.Students!).ToList();

            var expected = Queries.CourseCount * (Queries.StudentCountPerCourse / 2);

            Assert.True(students1.Count == expected && students2.Count == expected);
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

            Assert.Equal(expected, actual.Select(x => x.Students).Sum(x => x!.Count));
        }

        [Fact]
        public void WhenUsingFilterInsideSelectMethodWithoutInclude_ThenTheFilterApplies()
        {
            var context = new AppDbContext();
            var actual = Queries.FilteringInsideSelectMethodWithoutInclude(context);

            var expected = Queries.CourseCount * (Queries.StudentCountPerCourse / 2);

            Assert.Equal(expected, actual.Select(x => x.Students).Sum(x => x!.Count));
        }

    }
}