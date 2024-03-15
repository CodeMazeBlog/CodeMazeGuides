using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperatorOverloading;

namespace Tests
{
    [TestClass]
    public class OperatorOverloadingUnitTest
    {
        [TestMethod]
        public void WhenOverloadIncrementOperator_ThenCorrectOutput()
        {
            var input = new Student(1, 1, "John", 7, 3);
            var expected = 4;
            input++;
            var actual = input.GetNumberOfPassedCourses();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenOverloadGreaterThanOperator_ThenCorrectOutput()
        {
            var input1 = new Student(1, 1, "John", 10, 3);
            var input2 = new Student(1, 2, "Alice", 7, 3);
            var expected = true;
            var actual = input1 > input2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenOverloadLessThanOperator_ThenCorrectOutput()
        {
            var input1 = new Student(1, 1, "John", 10, 3);
            var input2 = new Student(1, 2, "Alice", 7, 3);
            var expected = false;
            var actual = input1 < input2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenOverrideEqualsMethod_ThenExpectedOutput()
        {
            var input1 = new Student(1, 1, "John", 10, 3);
            var input2 = new Student(1, 1, "John", 10, 5);
            var expected = true;
            var actual = input1.Equals(input2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenOverloadEqualToOperator_ThenExpectedOutput()
        {
            var input1 = new Student(1, 1, "John", 10, 3);
            var input2 = new Student(1, 1, "John", 10, 5);
            var expected = true;
            var actual = input1 == input2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenOverloadNotEqualToOperator_ThenExpectedOutput()
        {
            var input1 = new Student(1, 1, "John", 10, 3);
            var input2 = new Student(1, 2, "Alice", 10, 5);
            var expected = true;
            var actual = input1 != input2;

            Assert.AreEqual(expected, actual);
        }
    }
}