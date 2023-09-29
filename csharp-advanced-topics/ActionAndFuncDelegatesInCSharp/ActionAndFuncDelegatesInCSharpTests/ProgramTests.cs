using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionAndFuncDelegatesInCSharp;
using System;
using System.Collections.Generic;

namespace ActionAndFuncDelegatesInCSharp.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void FuncDelegateTest()
        {
            // Arrange
            List<Person> persons = new List<Person>
            {
                new Person {Name = "Jane", Gender = "Female", Country = "Australia"},
                new Person {Name = "Mark", Gender = "Male", Country = "Germany"},
                new Person {Name = "John", Gender = "Male", Country = "Mexico"},
            };

            // Act
            List<string> results = Program.FuncDelegate(persons);

            // Assert
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("Jane is a Female from Australia", results[0]);
            Assert.AreEqual("Mark is a Male from Germany", results[1]);
            Assert.AreEqual("John is a Male from Mexico", results[2]);
        }

        [TestMethod()]
        public void ActionDelegateTest()
        {
            // Arrange
            List<Person> persons = new List<Person>
            {
                new Person {Name = "Jane", Gender = "Female", Country = "Australia"},
                new Person {Name = "Mark", Gender = "Male", Country = "Germany"},
                new Person {Name = "John", Gender = "Male", Country = "Mexico"},
            };

            // Act
            List<string> results = Program.ActionDelegate(persons);

            // Assert
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("Jane is a Female", results[0]);
            Assert.AreEqual("Mark is a Male", results[1]);
            Assert.AreEqual("John is a Male", results[2]);
        }
    }
}
