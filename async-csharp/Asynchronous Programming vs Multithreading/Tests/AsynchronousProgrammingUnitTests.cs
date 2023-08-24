using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsynchronousProgramming;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Threading;

namespace AsynchronousProgrammingTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public async Task GivenFunction_WhenExecutedFirstAsync_ShoudRunOnSameThread()
        { 
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                await Program.FirstAsync();

                var consoleString = sw.ToString().Trim();

                var result = consoleString.Contains("First Async Method on Thread");

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task GivenFunction_WhenExecutedSecondAsync_ShoudRunOnSameThread()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                await Program.SecondAsync();

                var consoleString = sw.ToString().Trim();

                var result = consoleString.Contains("Second Async Method on Thread");

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task GivenFunction_WhenExecutedThirdAsync_ShoudRunOnSameThread()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                await Program.ThirdAsync();

                var consoleString = sw.ToString().Trim();

                var result = consoleString.Contains("Third Async Method on Thread");

                Assert.IsTrue(result);
            }
        }
    }
}