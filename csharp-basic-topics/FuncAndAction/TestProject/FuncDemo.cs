using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Add_Test()
        {
            int result = Program.Add(5, 3);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Subtract_Test()
        {
            float result = Program.Subtract(10.0f, 3.5f);
            Assert.AreEqual(6.5f, result);
        }

        [Test]
        public void Multiply_Test()
        {
            double result = Program.Multiply(2.5, 4.0);
            Assert.AreEqual(10.0, result);
        }

        [Test]
        public void PerformOperationWithResult_Add_Test()
        {
            int result = Program.PerformOperationWithResult(5, 3, Program.Add);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void PerformOperationWithResult_Subtract_Test()
        {
            float result = Program.PerformOperationWithResult(10.0f, 3.5f, Program.Subtract);
            Assert.AreEqual(6.5f, result);
        }

        [Test]
        public void PerformOperationWithResult_Multiply_Test()
        {
            double result = Program.PerformOperationWithResult(2.5, 4.0, Program.Multiply);
            Assert.AreEqual(10.0, result);
        }
    }
}
