using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using StaticClasses;

namespace StaticClassesTest
{
    [TestClass]
    public class StaticClassUnitTest
    {
        [TestMethod]
        public void GivenStudentDate_ThenReturnCorrectAge()
        {
            //assign variables to the Student class
            Student.Id = 1;
            Student.Name = "John Doe";
            Student.DateOfBirth = new DateTime(1994, 12, 31);
            int expectedAge = 26;
            int actualAge = Student.CalculateAge(Student.DateOfBirth);

            Assert.AreEqual(expectedAge, actualAge);
        }

        [TestMethod]
        //test the non-static version of the same class
        public void GivenStudentAgeNonStatic_ThenReturnCorrectAge() 
        {
            //instantiate non static class
            var student = new CollegeStudent();
            student.Id = 1;
            student.Name = "John Doe";
            student.DateOfBirth = new DateTime(1994, 12, 31);
            int expectedAge = 26;
            int actualAge = student.CalculateAge(student.DateOfBirth);

            Assert.AreEqual(expectedAge, actualAge);
        }

        [TestMethod]
        //test the type of the object returned by the static class is not equal to the non-static class type
        public void GivenStaticAndNonStaticClass_ThenReturnConfirmNotSame() 
        {
            Student.Id = 1;
            Student.Name = "John Doe";
            Student.DateOfBirth = new DateTime(1994, 12, 31);
            var staticVersion = Student.StudentDetails;

            //lets compare whether the class is the same as it's non-static counterpart
            var student = new CollegeStudent();
            student.Id = 1;
            student.Name = "John Doe";
            student.DateOfBirth = new DateTime(1994, 12, 31);
            var nonStaticVersion = student.StudentDetails;

            Assert.AreNotEqual(staticVersion, nonStaticVersion);
        }
    }
}