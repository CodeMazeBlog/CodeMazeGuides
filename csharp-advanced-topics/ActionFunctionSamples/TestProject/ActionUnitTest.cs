using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestProject
{
    [TestClass]
    public class ActionUnitTest
    {
        [TestMethod]
        public void WhenShowExample_ThenCorrectOutput()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                ActionSample.ActionMethods.ShowActionExamples();

                var output = stringWriter.ToString().Replace("\r\n", ",").TrimEnd(',');

                Assert.AreEqual("Hello World!,Hello World!,Hello World!,Hello World!", output);
            }
        }
    }
}