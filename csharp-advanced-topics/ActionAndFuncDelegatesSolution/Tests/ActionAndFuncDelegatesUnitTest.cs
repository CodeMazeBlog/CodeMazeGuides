using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncDelegatesUnitTest
    {
        ActionDelegates actionDelegate = new();
        FuncDelegates funcDelegate = new();
        StudentEligibility studentEligibility = new();

        [TestMethod]
        public void WhenAdd1PositiveIntAnd1PositiveDecimalViaActionDelegate_ThenResultIsAPositiveDecimal()
        {
            var expectedSum = 400.65M;

            actionDelegate.IntDecimalActionDelegate(200, 200.65M);
            var actualSum = actionDelegate.Sum;
            
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void WhenAdd1LargerPositiveIntAnd1NegativeDecimalViaActionDelegate_ThenResultIsAPositiveDecimal()
        {
            var expectedSum = 199.35M;

            actionDelegate.IntDecimalActionDelegate(400, -200.65M);
            var actualSum = actionDelegate.Sum;

            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void WhenAdd1NegativeIntAnd1PositiveDecimalViaActionDelegate_ThenResultIsAPositiveDecimal()
        {
            var expectedSum = 100.65M;

            actionDelegate.IntDecimalActionDelegate(-100, 200.65M);
            var actualSum = actionDelegate.Sum;

            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void WhenAdd1NegativeIntAnd1NegativeDecimalViaActionDelegate_ThenResultIsANegativeDecimal()
        {
            var expectedSum = -400.65M;

            actionDelegate.IntDecimalActionDelegate(-200, -200.65M);
            var actualSum = actionDelegate.Sum;

            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void WhenAdd2PositiveDecimalsViaFuncDelegate_ThenResultIsAPositiveDecimal()
        {
            var expectedSum = 201;
            
            var actualSum = funcDelegate.DecimalFuncDelegate(100.55M, 100.45M);

            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void WhenAdd2NegativeDecimalsViaFuncDelegate_ThenResultIsANegativeDecimal()
        {
            var expectedSum = -150.51M;
            
            var actualSum = funcDelegate.DecimalFuncDelegate(-50.25M, -100.26M);

            Assert.AreEqual(expectedSum, actualSum);
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
            var expectedOutput = true;
            
            var actualOutput = studentEligibility.StudentFunc(student);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void WhenStudentCGPALessThan8_ThenReturnFalse()
        {
            var student = new Student
            {
                Id = 100,
                Name = "Rose",
                CGPA = 7.5f
            };
            var expectedOutput = false;

            var actualOutput = studentEligibility.StudentFunc(student);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void WhenStudentCGPAEqualTo8_ThenReturnTrue()
        {
            var student = new Student
            {
                Id = 101,
                Name = "Ramone",
                CGPA = 8f
            };
            var expectedOutput = true;

            var actualOutput = studentEligibility.StudentFunc(student);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}