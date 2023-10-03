using FunctionActionDelegatesInCsharp;

namespace FunctionActionTests
{
    [TestClass]
    public class CSharpFunctionsAndActionTests
    {
        [TestMethod]
        public void Should_Add_Two_Numbers_Correctly()
        {
            //arrange
            Func<int, int, int> add = (int first, int second) => first + second;

            //act
            var resultAdd = add(1, 2);

            //assert
            Assert.AreEqual(3, resultAdd);
        }

        [TestMethod]
        public void Should_Subtract_Two_Numbers_Correctly()
        {
            //arrange
            Func<int, int, int> sub = FunctionAction.Subtract;

            //act
            var resultSub = sub(2, 1);

            //assert
            Assert.AreEqual(1, resultSub);
        }

        [TestMethod]
        public void Should_Multiply_Two_Numbers_Correctly()
        {
            //arrange
            var random = new Random();

            //act
            Func<int> mult = () => random.Next(0, 20) * 2;

            //assert
            Assert.IsNotNull(mult);
        }

        [TestMethod]
        public void Should_Update_Action_Value_Correctly()
        {
            //arrange
            int value = 1;
            Action<int> action = x => value = x;

            //act
            action(value * 50);
            //assert
            Assert.AreEqual(50, value);
        }
    }
}