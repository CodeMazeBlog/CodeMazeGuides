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

        // ALL, ANY, CONTAINS, TAKE, SKIP
        [Fact]
        public void WhenAllStudnetsPassed_ThenStatus()
        {
            var items = FrequentlyUsedLINQExamples.GetStatusOfAllStudentsWhoPassed();
            Assert.True(items);
        }

        [Fact]
        public void WhenAnyStudnetWithDistinction_ThenStatus()
        {
            var items = FrequentlyUsedLINQExamples.GetStatusOfAnyStudentsWithDistinction();
            Assert.True(items);
        }

        [Fact]
        public void WhenStudentIndex_ThenDisplayStudentsFromIndex()
        {
            var items = FrequentlyUsedLINQExamples.TakeStudentsUptoIndex();
            Assert.Equal(2, items.Count());
        }

        [Fact]
        public void WhenStudentIndex_ThenSkipStudentsFromIndex()
        {
            var items = FrequentlyUsedLINQExamples.GetStudentsSkipAtIndex();
            Assert.Equal(3, items.Count());
        }
         
        [Fact]
        public void WhenStudentContainsId_ThenStatus()
        {
            var items = FrequentlyUsedLINQExamples.GetStudentContainsId();
            Assert.True(items);
        }

        [Fact]
        public void WhenSelectingStudentByName_ThenStudentMark()
        {
            var items = FrequentlyUsedLINQExamples.SelectStudentNames("Noha Shamil").ToList();
            Assert.Equal(88, items[0].Mark);
        }

        [Fact]
        public void WhenSumOfStudentMarks_ThenTotalMark()
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
        public void WhenMaxMarksOfStudents_ThenMaxMark()
        {
            var max = FrequentlyUsedLINQExamples.MaxMarksOfStudent();
            Assert.Equal(88, max);
        }

        [Fact]
        public void WhenMinMarksOfStudents_ThenMinMark()
        {
            var min = FrequentlyUsedLINQExamples.MinMarksOfStudent();
            Assert.Equal(51, min);
        }

        // AVG
        [Fact]
        public void WhenStudnetsMark_ThenAverageMark()
        {
            var avgMark = FrequentlyUsedLINQExamples.AverageMarksOfStudent();
            Assert.Equal(71.4, avgMark);
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