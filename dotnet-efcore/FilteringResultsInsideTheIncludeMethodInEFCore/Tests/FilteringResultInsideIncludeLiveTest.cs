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

        [Fact]
        public void WhenUsingThenIncludeAfterAFilteredInclude_ThenTheLowerLevelInheritsTheNarrowedSet()
        {
            var context = new AppDbContext();
            var actual = Queries.GoodFilteringOnMultipleIncludeWithThenInclude(context);

            var expectedStudents = Queries.CourseCount * (Queries.StudentCountPerCourse / 2);
            var expectedAssignments = expectedStudents * Queries.AssignmentCountPerStudent;

            Assert.Equal(Queries.CourseCount, actual.Count);
            Assert.Equal(expectedStudents, actual.Sum(x => x.Students!.Count));
            Assert.Equal(expectedAssignments, actual.SelectMany(x => x.Students!).Sum(s => s.Assignments!.Count));
        }

        [Fact]
        public void WhenSortingAndPagingInsideInclude_ThenTakeAppliesPerCourse()
        {
            var context = new AppDbContext();
            var actual = Queries.FilteredIncludeWithSortingAndPaging(context);

            Assert.Equal(Queries.CourseCount, actual.Count);
            Assert.All(actual, course => Assert.Equal(3, course.Students!.Count));
            Assert.Equal(Queries.CourseCount * 3, actual.Sum(x => x.Students!.Count));
            Assert.All(actual, course => Assert.Equal(Queries.StudentCountPerCourse, course.Students!.First().Mark));
        }

        [Fact]
        public void WhenNoStudentMatchesTheFilter_ThenTheCourseIsStillReturnedWithAnEmptyCollection()
        {
            var context = new AppDbContext();
            var actual = Queries.FilteredIncludeWithoutMatchingStudents(context);

            Assert.Equal(Queries.CourseCount, actual.Count);
            Assert.All(actual, course => Assert.Empty(course.Students!));
        }

        [Fact]
        public void WhenExplicitlyLoadingWithAFilter_ThenOnlyMatchingStudentsAreLoaded()
        {
            var context = new AppDbContext();
            var course = context.Courses!.First();

            var actual = Queries.ExplicitLoadingWithFilter(context, course);

            Assert.Equal(Queries.StudentCountPerCourse / 2, actual.Count);
            Assert.All(actual, student => Assert.True(student.Mark > 50));
        }

    }
}