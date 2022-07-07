using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using CSConstructors;

namespace Tests;

[TestClass]
public class CSConstructorsTests
{
    [TestMethod]
    public void WhenGivenEmptyConstructorOnIntialize_ThenInvokeDefaultConstructor()
    {
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            Person person = new Person();

            var consoleString = sw.ToString().Trim();

            var result = consoleString.Contains("Default Constructor Invoked");

            Assert.IsTrue(result);
        }
    }

    [TestMethod]
    public void WhenGivenNameAndAgeOnIntialize_ThenInvokeParameterizedConstructor()
    {
        using(var sw = new StringWriter())
        {
            Console.SetOut(sw);

            Person person = new Person("Test", 10);

            var consoleString = sw.ToString().Trim();

            var result = consoleString.Contains("Constructor are chained and Invoked");

            Assert.IsTrue(result);
        }
    }

    [TestMethod]
    public void WhenGivenExistingPerson_ThenInvokeCopyConstructor_OnIntialize()
    {
        Person person = new Person("Test", 10);

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            Person person2 = new Person(person);

            var consoleString = sw.ToString().Trim();

            var result = consoleString.Contains("Copy Constructor Invoked");

            Assert.IsTrue(result);
        }
    }

    [TestMethod]
    public void WhenGivenStudent_ShouldInvokeBaseConstructor_OnIntialize()
    {
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            Student student = new Student("Test", 10, "IT");

            var consoleString = sw.ToString().Trim();

            var result = consoleString.Contains("Constructor are chained and Invoked");

            Assert.IsTrue(result);
        }
    }
}
