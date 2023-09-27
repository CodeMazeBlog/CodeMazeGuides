using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace AddParametersToStringTests
{
    [TestClass]
    public class AddParametersToStringTests
    {
        private readonly string name = "John Doe";

        private readonly int age = 26;

        private readonly string output = "Hi, my name is John Doe. I am 26 years old.";

        [TestMethod]
        public void GivenStringFormat_WhenValid_ParameterAddedSuccessfully()
        {
            Assert.AreEqual(output, string.Format("Hi, my name is {0}. I am {1} years old.", name, age));
        }

        [TestMethod]
        public void GivenStringReplace_WhenVailid_ParameterAddedSuccessfully()
        {
            var greeting = "Hi, my name is username. I am age years old.";

            Assert.AreEqual(output, greeting.Replace("username", name).Replace("age", age.ToString()));
        }

        [TestMethod]
        public void GivenStringInterpolation_WhenVailid_ParameterAddedSuccessfully()
        {
            Assert.AreEqual(output, $"Hi, my name is {name}. I am {age} year{(age == 1 ? "" : "s")} old.");
        }

        [TestMethod]
        public void GivenStringBuilderAppendFormat_WhenVailid_ParameterAddedSuccessfully()
        {
            var builder = new StringBuilder();

            builder.AppendFormat("Hi, my name is {0}. I am {1} years old.", name, age);

            Assert.AreEqual(output, builder.ToString());
        }
    }
}
