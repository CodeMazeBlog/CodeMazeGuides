using System;
using NUnit.Framework;

namespace ActionFuncDelegateTests
{
    public class FuncProgramTests
    {
        [Test]
        public void TestGetRandomNumber()
        {
            //Arrange
            Func<int> getRandomNumber = () => new Random().Next();

            //Act
            int number = getRandomNumber();

            //Assert
            Assert.IsTrue(number >= 0 && number <= int.MaxValue);
        }

        [Test]
        public void TestSquare()
        {
            //Arrange
            Func<int, int> square = x => x * x;
            int expectedResult = 25;

            //Act
            int result = square(5);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestAreEqual()
        {
            //Arrange
            Func<int, int, bool> areEqual = (x, y) => x == y;
            bool expectedResult = true;

            //Act
            bool result = areEqual(5, 5);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
