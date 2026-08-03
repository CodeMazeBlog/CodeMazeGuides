using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;

namespace CheckStringEndsWithNumberTests
{
    [TestClass]
    public class CheckStringEndsWithNumberTests
    {
        [TestMethod]
        public void GivenStringWithoutNumbers_WhenUsingMethod1_ThenReturnFalse()
        {
            string inputString = "Hello";

            bool result = char.IsDigit(inputString.Last());

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GivenStringEndingWithNumber_WhenUsingMethod1_ThenReturnTrue()
        {
            string inputString = "Hello1";

            bool result = char.IsDigit(inputString.Last());

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenStringStartingWithNumber_WhenUsingMethod1_ThenReturnFalse()
        {
            string inputString = "1Hello";

            bool result = char.IsDigit(inputString.Last());

            Assert.IsFalse(result);
        }

        //-----------------method 2
        [TestMethod]
        public void GivenStringWithoutNumbers_WhenUsingMethod2_ThenReturnFalse()
        {
            string inputString = "Hello";

            var lastChar = inputString.Last();
            bool result = lastChar >= '0' && lastChar <= '9';

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GivenStringEndingWithNumber_WhenUsingMethod2_ThenReturnTrue()
        {
            string inputString = "Hello1";

            var lastChar = inputString.Last();
            bool result = lastChar >= '0' && lastChar <= '9';

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenStringStartingWithNumber_WhenUsingMethod2_ThenReturnFalse()
        {
            string inputString = "1Hello";

            var lastChar = inputString.Last();
            bool result = lastChar >= '0' && lastChar <= '9';

            Assert.IsFalse(result);
        }

        //------------method 3
        [TestMethod]
        public void GivenStringWithoutNumbers_WhenUsingMethod3_ThenReturnFalse()
        {
            string inputString = "Hello";

            bool result = inputString.Substring(inputString.Length - 1).All(char.IsDigit);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GivenStringEndingWithNumber_WhenUsingMethod3_ThenReturnTrue()
        {
            string inputString = "Hello1";

            bool result = inputString.Substring(inputString.Length - 1).All(char.IsDigit);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenStringStartingWithNumber_WhenUsingMethod3_ThenReturnFalse()
        {
            string inputString = "1Hello";

            bool result = inputString.Substring(inputString.Length - 1).All(char.IsDigit);

            Assert.IsFalse(result);
        }

        //-------------method 4
        [TestMethod]
        public void GivenStringWithoutNumbers_WhenUsingMethod4_ThenReturnFalse()
        {
            string inputString = "Hello";

            var regex = new Regex(@"\d+$");
            bool result = regex.Match(inputString).Success;

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GivenStringEndingWithNumber_WhenUsingMethod4_ThenReturnTrue()
        {
            string inputString = "Hello1";

            var regex = new Regex(@"\d+$");
            bool result = regex.Match(inputString).Success;

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenStringStartingWithNumber_WhenUsingMethod4_ThenReturnFalse()
        {
            string inputString = "1Hello";

            var regex = new Regex(@"\d+$");
            bool result = regex.Match(inputString).Success;

            Assert.IsFalse(result);
        }
    }
}