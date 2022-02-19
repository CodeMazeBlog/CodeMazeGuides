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
            var studnets = Program.DemoLINQQueryOperation().ToList();
            Assert.Equal(2, studnets.Count);
        }

        [Fact]
        public void WhenRetrievingHighPerformingStudents_ThenTotalStudentCount()
        {
            var studnets = Program.DemoHighPerformingStudents().ToList();
            Assert.Equal(2, studnets.Count);
        }

        [Fact]
        public void WhenSelectingHighPerformingStudents_ThenTotalStudentCount()
        {
            var studnets = Program.SelectHighPerformingStudents().ToList();
            Assert.Equal(2, studnets.Count);
        }

        [Fact]
        public void WhenSelectingStudentsOrderById_ThenTotalStudentCount()
        {
            var studnets = Program.SelectStudentsOrderById().ToList();
            Assert.Equal(1, studnets[0].StudentID);
        }

        [Fact]
        public void WhenStudentsGetOrderByDescending_ThenStudentIdAtZeroIndex()
        {
            var studnets = Program.StudentsGetOrderByDescending().ToList();
            Assert.Equal(5, studnets[0].StudentID);
        }

        [Fact]
        public void WhenStudentsGroupBy_ThenCityNameAtZeroIndex()
        {
            var items = Program.SelectStudentsGroupBy().ToList();
            Assert.Equal("NYC", items[0].Key);
        }

        [Fact]
        public void WhenSumOfStudentMarks_ThenTotalMarks()
        {
            int marks = Program.SumOfStudentMarks();
            Assert.Equal(357, marks);
        }

        [Fact]
        public void WhenCountOfStudents_ThenNumberOfStudents()
        {
            int count = Program.CountOfStudents();
            Assert.Equal(3, count);
        }

        [Fact]
        public void WhenMaxMarksOfStudents_ThenMaxMarks()
        {
            int max = Program.MaxMarksOfStudent();
            Assert.Equal(88, max);
        }

        [Fact]
        public void WhenMinMarksOfStudents_ThenMinMarks()
        {
            int min = Program.MinMarksOfStudent();
            Assert.Equal(51, min);
        }

        [Fact]
        public void WhenFirstStudentOccurence_ThenStudentCount()
        {
            Student student = Program.FirstStudentOccurence();
            Assert.Equal(2, student.StudentID);
        }

        [Fact]
        public void WhenFirstOrDefaultStudentOccurence_ThenStudentCount()
        {
            Student student = Program.FirstOrDefaultStudentOccurence();
            Assert.Equal(1, student.StudentID);
        }

        [Fact]
        public void WhenSingleStudentOccurence_ThenStudentCount()
        {
            Student student = Program.SingleStudentOccurence();
            Assert.Equal(1, student.StudentID);
        }

        [Fact]
        public void WhenSingleOrDefaultStudentOccurence_ThenStudentCount()
        {
            Student student = Program.SingleOrDefaultStudentOccurence();
            Assert.Equal(1, student.StudentID);
        }
    }
}