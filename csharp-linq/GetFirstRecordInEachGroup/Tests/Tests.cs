using GetFirstRecordInEachGroup;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly List<Student> students;
        private readonly Dictionary<string, Student> grouppedStudents = 
            new Dictionary<string, Student>();

        public Tests()
        {
            students = Methods.GenerateStudents();
            foreach (var student in students)
            {
                if (!grouppedStudents.ContainsKey(student.Class))
                    grouppedStudents.Add(student.Class, student);
                else if (student.BirthYear < 
                    grouppedStudents[student.Class].BirthYear)
                    grouppedStudents[student.Class] = student;
            }
        }

        private bool ValidateResults(List<Student> students)
        {
            foreach (var student in students)
                if (!student.Equals(grouppedStudents[student.Class]))
                    return false;
            
            return true;
        }

        [Fact]
        public void WhenLinqGroupBy1_ThenSuccess()
        {
            var youngestStudents = 
                students.GetYoungestStudentInClassLinqGroupBy1();

            Assert.True(ValidateResults(youngestStudents));
        }

        [Fact]
        public void WhenLinqGroupBy2_ThenSuccess()
        {
            var youngestStudents =
                students.GetYoungestStudentInClassLinqGroupBy2();

            Assert.True(ValidateResults(youngestStudents));
        }

        [Fact]
        public void WhenLinqLookup_ThenSuccess()
        {
            var youngestStudents =
                 students.GetYoungestStudentInClassLinqLookup();

            Assert.True(ValidateResults(youngestStudents));
        }

        [Fact]
        public void WhenLinqDictionary_ThenSuccess()
        {
            var youngestStudents =
                 students.GetYoungestStudentInClassLinqDictionary();

            Assert.True(ValidateResults(youngestStudents));
        }

        [Fact]
        public void WhenIterativeDictionary_ThenSuccess()
        {
            var youngestStudents =
                students.GetYoungestStudentInClassIterativeDictionary();

            Assert.True(ValidateResults(youngestStudents));
        }
    }
}