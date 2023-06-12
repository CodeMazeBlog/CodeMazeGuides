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
        var person = new Person();

        Assert.AreEqual(person.Name, "testName");
        Assert.AreEqual(person.Age, 25);
    }

    [TestMethod]
    public void WhenGivenNameAndAgeOnIntialize_ThenInvokeParameterizedConstructor()
    {
        var person = new Person("Test", 10);

        Assert.AreEqual(person.Name, "Test");
        Assert.AreEqual(person.Age, 10);
    }

    [TestMethod]
    public void WhenGivenExistingPerson_ThenInvokeCopyConstructor_OnIntialize()
    {
        var person = new Person("Test", 10);
        var person2 = new Person(person);

        Assert.AreEqual(person.Name, "Test");
        Assert.AreEqual(person.Age, 10);
    }

    [TestMethod]
    public void WhenGivenStudent_ShouldInvokeBaseConstructor_OnIntialize()
    {
        var student = new Student("Test", 10, "IT");

        Assert.AreEqual(student.Name, "Test");
        Assert.AreEqual(student.Age, 10);
        Assert.AreEqual(student.Department, "IT");
    }
}
