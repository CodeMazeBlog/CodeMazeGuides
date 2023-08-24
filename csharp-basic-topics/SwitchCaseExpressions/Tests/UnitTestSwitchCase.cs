using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwitchCaseExpression;
using System.IO;
using System.Text;

namespace Tests
{
    [TestClass]
    public class UnitTestSwitch
    {
        private readonly string _pleasantWeather = "It is a pleasant day";
        private readonly string _hotWeather = "It is hot today";
        private readonly string _veryHotWeather = "It is very hot today";
        private readonly string _noWeatherReport = "No weather report";

        StringWriter stringWrite = new StringWriter();

        public UnitTestSwitch()
        {
            Console.SetOut(stringWrite);
        }

        public string GetExpectedOutputForTest(int temp)
        {
            var expectedout = string.Empty;
           
            switch (temp)
            {
                case 20:
                case 22:
                case 24:
                    expectedout = _pleasantWeather;
                    break;
                case 30:
                    expectedout = _hotWeather;
                    break;
                case 35:
                    expectedout = _veryHotWeather;
                    break;
                default:
                    expectedout = _noWeatherReport;
                    break;
            }

            return expectedout;
        }

        [TestMethod]
        public void whenMultipleCasesHaveSameResult()
        {
            var switchTemp = 20;
            var expectedout = GetExpectedOutputForTest(switchTemp);

            Program.SubMultipleCaseResults(switchTemp);

            var resultstring = stringWrite.ToString().Trim();

            Assert.AreEqual(expectedout, resultstring);
        }

        [TestMethod]
        public void whenMultipleCasesUseWhenKeyword()
        {
            var expoutput = "The value is between 50 and 150";

            Program.SubMultipleCaseResultsWithWhen(100);

            var resultstring = stringWrite.ToString().Trim();

            Assert.AreEqual(expoutput, resultstring);
        }

        [TestMethod]
        public void whenMultipleCaseWithListValues()
        {   
            var tempValue = 22;
            var expectedout = GetExpectedOutputForTest(tempValue);

            Program.SubMultipleCaseWithListValues(tempValue);

            var resultstring = stringWrite.ToString();
            var arr = resultstring.Split("-");
            resultstring = arr[0].ToString().Trim();

            Assert.AreEqual(expectedout, resultstring);
        }

        [TestMethod]
        public void whenSwitchCaseWithEasyFormat()
        {
            var tempValue = 22;
            var resultText = string.Empty;
            var expectedoutput = GetExpectedOutputForTest(tempValue);

            Program.SubMultipleCaseWithNewVersion(tempValue);

            resultText = stringWrite.ToString();
            var arr = resultText.Split("-");
            resultText = arr[0].ToString().Trim();

            Assert.AreEqual(expectedoutput, resultText);
        }

        [TestMethod]
        public void whenSwitchCaseWithExtensionMethod()
        {
            var tempValue = 22;
            var expectedout = GetExpectedOutputForTest(tempValue);

            Program.SubMultipleCaseWithExtension(tempValue);

            var result = stringWrite.ToString();
            var arr = result.Split("-");
            result = arr[0].ToString().Trim();

            Assert.AreEqual(expectedout, result);
        }
    }
}
