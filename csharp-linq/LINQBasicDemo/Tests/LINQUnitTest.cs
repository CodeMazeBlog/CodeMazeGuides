using LINQBasicExample;
using System.Linq;
using Xunit;

namespace Tests
{
    public class LINQUnitTest
    {
        [Fact]
        public void WhenTestingLINQQueryOperation_ThenTotalStudentCount()
        {
            var studnets = FrequentlyUsedLINQExamples.DemoLINQQueryOperation().ToList();
            Assert.Equal(2, studnets.Count);
        }

        [Fact]
        public void WhenRetrievingHighPerformingStudents_ThenTotalStudentCount()
        {
            var studnets = FrequentlyUsedLINQExamples.DemoHighPerformingStudents().ToList();
            Assert.Equal(2, studnets.Count);
        }

        [Fact]
        public void WhenSelectingHighPerformingStudents_ThenTotalStudentCount()
        {
            var studnets = FrequentlyUsedLINQExamples.SelectHighPerformingStudents().ToList();
            Assert.Equal(2, studnets.Count);
        }

        [Fact]
        public void WhenSelectingStudentsOrderById_ThenTotalStudentCount()
        {
            var studnets = FrequentlyUsedLINQExamples.SelectStudentsOrderById().ToList();
            Assert.Equal(1, studnets[0].StudentID);
        }

        [Fact]
        public void WhenStudentsGetOrderByDescending_ThenStudentIdAtZeroIndex()
        {
            var studnets = FrequentlyUsedLINQExamples.StudentsGetOrderByDescending().ToList();
            Assert.Equal(5, studnets[0].StudentID);
        }

        [Fact]
        public void WhenStudentsGroupBy_ThenCityNameAtZeroIndex()
        {
            var items = FrequentlyUsedLINQExamples.SelectStudentsGroupBy().ToList();
            Assert.Equal("NYC", items[0].Key);
        }

        [Fact]
        public void WhenSumOfStudentMarks_ThenTotalMarks()
        {
            var mark = FrequentlyUsedLINQExamples.SumOfStudentMarks();
            Assert.Equal(357, mark);
        }

        [Fact]
        public void WhenCountOfStudents_ThenNumberOfStudents()
        {
            var count = FrequentlyUsedLINQExamples.CountOfStudents();
            Assert.Equal(3, count);
        }

        [Fact]
        public void WhenMaxMarksOfStudents_ThenMaxMarks()
        {
            var max = FrequentlyUsedLINQExamples.MaxMarksOfStudent();
            Assert.Equal(88, max);
        }

        [Fact]
        public void WhenMinMarksOfStudents_ThenMinMarks()
        {
            var min = FrequentlyUsedLINQExamples.MinMarksOfStudent();
            Assert.Equal(51, min);
        }

        [Fact]
        public void WhenFirstStudentOccurence_ThenStudentCount()
        {
            var student = FrequentlyUsedLINQExamples.FirstStudentOccurence();
            Assert.Equal(2, student.StudentID);
        }

        [Fact]
        public void WhenFirstOrDefaultStudentOccurence_ThenStudentCount()
        {
            var student = FrequentlyUsedLINQExamples.FirstOrDefaultStudentOccurence();
            Assert.Equal(1, student.StudentID);
        }

        [Fact]
        public void WhenSingleStudentOccurence_ThenStudentCount()
        {
            var student = FrequentlyUsedLINQExamples.SingleStudentOccurence();
            Assert.Equal(1, student.StudentID);
        }

        [Fact]
        public void WhenSingleOrDefaultStudentOccurence_ThenStudentCount()
        {
            var student = FrequentlyUsedLINQExamples.SingleOrDefaultStudentOccurence();
            Assert.Equal(1, student.StudentID);
        }
    }
}