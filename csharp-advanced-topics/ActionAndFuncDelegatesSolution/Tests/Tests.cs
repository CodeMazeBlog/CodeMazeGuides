using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void whenGetCubeActionDelegateInvoked_ThenOutputResult()
        {
            int number = 7;
            string expected = "The result is 343";
            string actual = "";

            Action<int> actionDelegate = Programs.GetCube;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                actionDelegate.Invoke(number);
                actual = sw.ToString().Trim();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void whenGetSquareFuncDelegateInvoked_ThenReturnResult()
        {
            int number = 6;
            int expected = 36;
            int actual = 0;

            Func<int, int> funcDelegate = Programs.GetSquare;
            actual = funcDelegate.Invoke(number);

            Assert.AreEqual(expected, actual);
        }
    }

    public class Programs
    {
        public static void GetCube(int number)
        {
            int result = number * number * number;
            Console.WriteLine($"The result is {result}");
        }

        public static int GetSquare(int number)
        {
            return number * number;
        }
    }
}