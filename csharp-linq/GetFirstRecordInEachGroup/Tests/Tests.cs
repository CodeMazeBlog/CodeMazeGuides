using GetFirstRecordInEachGroup;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly List<Student> _students;
        private readonly Dictionary<int, Student> _groupedStudents = new();

        public Tests()
        {
            _students = Methods.GenerateStudents();
            foreach (var student in _students)
            {
                if (!_groupedStudents.TryAdd(student.Class, student) &&
                    student.DateOfBirth > _groupedStudents[student.Class].DateOfBirth)
                    _groupedStudents[student.Class] = student;
            }
        }

        private bool ValidateResults(List<Student> students)
        {
            foreach (var student in students)
                if (!student.Equals(_groupedStudents[student.Class]))
                    return false;
            
            return true;
        }

        [Fact]
        public void WhenLinqGroupBy1_ThenSuccess()
        {
            var youngestStudents = 
                _students.GetYoungestStudentInClassLinqGroupBy1();

            Assert.True(ValidateResults(youngestStudents));
        }

        [Fact]
        public void WhenLinqGroupBy2_ThenSuccess()
        {
            var youngestStudents =
                _students.GetYoungestStudentInClassLinqGroupBy2();

            Assert.True(ValidateResults(youngestStudents));
        }

        [Fact]
        public void WhenLinqLookup_ThenSuccess()
        {
            var youngestStudents =
                 _students.GetYoungestStudentInClassLinqLookup();

            Assert.True(ValidateResults(youngestStudents));
        }

        [Fact]
        public void WhenLinqDictionary_ThenSuccess()
        {
            var youngestStudents =
                 _students.GetYoungestStudentInClassLinqDictionary();

            Assert.True(ValidateResults(youngestStudents));
        }

        [Fact]
        public void WhenIterativeDictionary_ThenSuccess()
        {
            var youngestStudents =
                _students.GetYoungestStudentInClassIterativeDictionary();

            Assert.True(ValidateResults(youngestStudents));
        }
    }
}