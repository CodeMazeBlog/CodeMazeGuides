using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TestProject
{
    [TestClass]
    public class FunctionUnitTest
    {
        [TestMethod]
        public void WhenShowExample_ThenCorrectOutput()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                FunctionSample.FuncMethods.ShowFunctionExamples();

                var output = Regex.Replace(stringWriter.ToString(), @"\s+", ",").TrimEnd(',');

                Assert.AreEqual("8,5,2.5", output);
            }
        }
    }
}