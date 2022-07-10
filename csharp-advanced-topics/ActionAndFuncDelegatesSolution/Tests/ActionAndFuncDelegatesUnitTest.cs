using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncDelegatesUnitTest
    {
        Func<int, int, int> testFuncDelegate = (int a, int b) => { return a + b; };
        Func<Student, bool> func = (Student student) => { return student.CGPA >= 8; };

        [TestMethod]
        public void WhenAdd2PositiveIntegers_ThenResultIsAPositiveInteger()
        {
            Assert.AreEqual(200, testFuncDelegate(100, 100));
        }

        [TestMethod]
        public void WhenAdd2NegativeIntegers_ThenResultIsANegativeInteger()
        {
            Assert.AreEqual(-200, testFuncDelegate(-100, -100));
        }

        [TestMethod]
        public void WhenAdd1PositiveIntegerAnd1LargerNegativeInteger_ThenResultIsANegativeInteger()
        {
            Assert.AreEqual(-100, testFuncDelegate(200, -300));
        }

        [TestMethod]
        public void WhenAdd1LargerPositiveIntegerAnd1NegativeInteger_ThenResultIsAPositiveInteger()
        {
            Assert.AreEqual(200, testFuncDelegate(400, -200));
        }

        [TestMethod]
        public void WhenStudentCGPAGreaterThan8_ThenReturnTrue()
        {
            var student = new Student
            {
                Id = 99,
                Name = "Reyes",
                CGPA = 8.23f
            };
            Assert.AreEqual(true, func(student));
        }

        [TestMethod]
        public void WhenStudentCGPALessThan8_ThenReturnFalse()
        {
            var student = new Student
            {
                Id = 99,
                Name = "Reyes",
                CGPA = 7.5f
            };
            Assert.AreEqual(false, func(student));
        }

        [TestMethod]
        public void WhenStudentCGPAEqualTo8_ThenReturnTrue()
        {
            var student = new Student
            {
                Id = 99,
                Name = "Reyes",
                CGPA = 8f
            };
            Assert.AreEqual(true, func(student));
        }
    }
}