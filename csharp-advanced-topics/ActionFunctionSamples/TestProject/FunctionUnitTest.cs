using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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

                var output = stringWriter.ToString().Replace("\r\n", ",").TrimEnd(',');

                Assert.AreEqual("8,5,2.5", output);
            }
        }
    }
}