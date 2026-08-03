using ExpressionBodiedMembersInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Test
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void WhenPublicPropertyNameIsSet_ThenValueChanges()
        {
            var employee = new Employee(string.Empty);
            var name = "john";
            employee.Name = name;
            Assert.AreEqual(name, employee.Name);
        }

        [TestMethod]
        public void WhenPropertyNameIsRead_ThenCurrentValueIsReturned()
        {
            var name = "john";
            var employee = new Employee(name);
            Assert.AreEqual(name, employee.Name);
        }

        [TestMethod]
        public void WhenConstructorUsed_ThenPrivateFieldIsSet()
        {
            var name = "john";
            var employee = new Employee(name);
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField;
            var field = employee.GetType().GetField("_name", bindingFlags);
            Assert.AreEqual(name, (string?)field?.GetValue(employee));
        }

        [TestMethod]
        public void WhenPositionFieldIsSet_PositionPropertyReturnsSentence()
        {
            var employee = new EmployeeRefactored("Senior Developer", "Baeldung");
            Assert.AreEqual("Senior Developer at Baeldung", employee.Position);
        }

        [TestMethod]
        public void WhenPositionFieldIsNotSet_PositionPropertyReturnsUnemployed()
        {
            var employee = new EmployeeRefactored("Senior Developer", null);
            Assert.AreEqual("Unemployed", employee.Position);
        }
    }
}