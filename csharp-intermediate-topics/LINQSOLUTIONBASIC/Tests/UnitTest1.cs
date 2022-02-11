using LINQExample;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DemoLINQQueryOperationTest()
        {
            IList<Student> studnets = Program.DemoLINQQueryOperation().ToList();
            Assert.Equal(2, studnets.Count);
        }

        [Fact]
        public void DemoHighPerformingStudentsATest()
        {
            IList<Student> studnets = Program.DemoHighPerformingStudents().ToList();
            Assert.Equal(2, studnets.Count);
        }

        [Fact]
        public void SelectHighPerformingStudentsTest()
        {
            IList<Student> studnets = Program.SelectHighPerformingStudents().ToList();
            Assert.Equal(2, studnets.Count);
        }

        [Fact]
        public void SelectStudentsOrderByIdTest()
        {
            IList<Student> studnets = Program.SelectStudentsOrderById().ToList();
            Assert.Equal(5, studnets.Count);
        }

        [Fact]
        public void StudentsGetOrderByDescendingTest()
        {
            IList<Student> studnets = Program.StudentsGetOrderByDescending().ToList();
            Assert.Equal(5, studnets.Count);
        }

        [Fact]
        public void SelectStudentsGroupByTest()
        {
            var items = Program.SelectStudentsGroupBy().ToList();
            Assert.Equal("NYC", items[0].Key);
        }

        [Fact]
        public void SumOfStudentMarksTest()
        {
            int marks = Program.SumOfStudentMarks();
            Assert.Equal(357, marks);
        }

        [Fact]
        public void CountOfStudentsTest()
        {
            int count = Program.CountOfStudents();
            Assert.Equal(2, count);
        }

        [Fact]
        public void MaxMarksOfStudentTest()
        {
            int max = Program.MaxMarksOfStudent();
            Assert.Equal(88, max);
        }

        [Fact]
        public void MinMarksOfStudentTest()
        {
            int min = Program.MinMarksOfStudent();
            Assert.Equal(51, min);
        }

        [Fact]
        public void FirstStudentOccurenceTest()
        {
            Student student = Program.FirstStudentOccurence();
            Assert.Equal(2, student.StudentID);
        }
        [Fact]
        public void FirstOrDefaultStudentOccurenceTest()
        {
            Student student = Program.FirstOrDefaultStudentOccurence();
            Assert.Equal(1, student.StudentID);
        }
        [Fact]
        public void SingleStudentOccurenceTest()
        {
            Student student = Program.SingleStudentOccurence();
            Assert.Equal(1, student.StudentID);
        }
        [Fact]
        public void SingleOrDefaultStudentOccurenceTest()
        {
            Student student = Program.SingleOrDefaultStudentOccurence();
            Assert.Equal(1, student.StudentID);
        }

    }
}