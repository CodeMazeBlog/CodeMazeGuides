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
            Program.Student.Id = 1;
            Program.Student.Name = "John Doe";
            Program.Student.DateOfBirth = new DateTime(1994, 12, 31);
            int expectedAge = 26;
            int actualAge = Program.Student.CalculateAge(Program.Student.DateOfBirth);
            Assert.AreEqual(expectedAge, actualAge);
        }

        [TestMethod]
        //test the non-static version of the same class
        public void GivenStudentAgeNonStatic_ThenReturnCorrectAge() 
        {
            //instantiate non static class
            CollegeStudent student = new CollegeStudent();
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
            Program.Student.Id = 1;
            Program.Student.Name = "John Doe";
            Program.Student.DateOfBirth = new DateTime(1994, 12, 31);
            var staticVersion = Program.Student.StudentDetails;

            //lets compare whether the class is the same as it's non-static counterpart
            CollegeStudent student = new CollegeStudent();
            student.Id = 1;
            student.Name = "John Doe";
            student.DateOfBirth = new DateTime(1994, 12, 31);
            var nonStaticVersion = student.StudentDetails;
            Assert.AreNotEqual(staticVersion, nonStaticVersion);
        }
    }
}