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
        public static readonly string Pleasant_Weather = "It is a pleasant day";
        public static readonly string Hot_Weather = "It is hot today";
        public static readonly string Very_Hot_Weather = "It is very hot today";
        public static readonly string No_Weather_Report = "No weather report";

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
                    expectedout = UnitTestSwitch.Pleasant_Weather;
                    break;
                case 30:
                    expectedout = UnitTestSwitch.Hot_Weather;
                    break;
                case 35:
                    expectedout = UnitTestSwitch.Very_Hot_Weather;
                    break;
                default:
                    expectedout = UnitTestSwitch.No_Weather_Report;
                    break;
            }

            return expectedout;
        }

        [TestMethod]
        public void whenMultipleCasesHaveSameResult()
        {
            var switchTemp = 20;
            var expectedout = GetExpectedOutputForTest(switchTemp);

            Program.SubMultipleCaseResults();
            var resultstring = stringWrite.ToString().Trim();
            Assert.AreEqual(expectedout, resultstring);
        }

        [TestMethod]
        public void whenMultipleCasesUseWhenKeyword()
        {
            var switchTemp = 20;
            var expoutput = "The value is between 50 and 150";
            var expectedout = GetExpectedOutputForTest(switchTemp);

            Program.SubMultipleCaseResultsWithWhen();
            var outputlines = stringWrite.ToString().Split(Environment.NewLine,StringSplitOptions.RemoveEmptyEntries);    
            Assert.AreEqual(expoutput, outputlines[0]);
            Assert.AreEqual(expectedout, outputlines[1]);
        }

        [TestMethod]
        public void whenMultipleCaseWithListValues()
        {   
            var tempValue = 22;
            var expectedout = GetExpectedOutputForTest(tempValue);

            Program.SubMultipleCaseWithListValues();
            var resultstring = stringWrite.ToString();
            string[] arr = resultstring.Split("-");
            resultstring = arr[0].ToString().Trim();
            Assert.AreEqual(expectedout, resultstring);
        }

        [TestMethod]
        public void whenSwitchCaseWithEasyFormat()
        {
            var tempValue = 22;
            var resultText = string.Empty;
            var expectedoutput = GetExpectedOutputForTest(tempValue);

            Program.SubMultipleCaseWithNewVersion();
            resultText = stringWrite.ToString();
            string[] arr = resultText.Split("-");
            resultText = arr[0].ToString().Trim();
            Assert.AreEqual(expectedoutput, resultText);
        }

        [TestMethod]
        public void whenSwitchCaseWithExtensionMethod()
        {
            var tempValue = 20;
            var expectedout = GetExpectedOutputForTest(tempValue);

            Program.SubMultipleCaseWithExtension();
            var result = stringWrite.ToString();
            string[] arr = result.Split("-");
            result = arr[0].ToString().Trim();
            Assert.AreEqual(expectedout, result);
        }
    }
}
