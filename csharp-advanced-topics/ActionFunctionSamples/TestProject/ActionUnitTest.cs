using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.RegularExpressions;

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

                int count = Regex.Matches(stringWriter.ToString(), "Hello World!").Count;

                Assert.AreEqual(count, 4);
            }
        }
    }
}