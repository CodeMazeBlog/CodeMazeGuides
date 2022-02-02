using NamedAndOptionalArgumentsInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CSArgumentTests
    {
        [TestMethod]
        public void GivenLastAndFirstName_ShouldReturnFullName_WhenNamedArgsIsUsed()
        {
            var name = Program.GetFullName(lastName: "Miller", firstName: "John");

            Assert.AreEqual("John Miller", name);
        }

        [TestMethod]
        public void GivenOptionalArgs_ShouldReturnSum_WhenDefaultValuesAreUsed()
        {
            var sum = Program.Add(5);

            Assert.AreEqual(35, sum);
        }

        [TestMethod]
        public void GivenOptionalArgs_ShouldReturnSum_WhenOptionalAttributeIsUsed()
        {
            var sum = Program.Sum(10, 20);
                
            Assert.AreEqual(30, sum);
        }
    }
}