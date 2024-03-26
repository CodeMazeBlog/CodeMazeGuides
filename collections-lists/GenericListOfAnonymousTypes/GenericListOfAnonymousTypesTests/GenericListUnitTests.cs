using GenericListOfAnonymousTypes;
using System.Collections;

namespace GenericListOfAnonymousTypesTests;

[TestClass]
public class GenericListUnitTests<T>
{
    object[] _inputObject = GenericListOfAnonymousTypesExamples<T>.GenerateRandomAnonymousObject();

    [TestMethod]
    public void GivenAnonymousObject_WhenToListMethodInvoked_ThenValidateListCreated()
    {
        var actualOutput = GenericListOfAnonymousTypesExamples<object>.GeneretaListOfAnonymousTypesUsingToList(_inputObject);

        Assert.IsInstanceOfType(actualOutput, typeof(List<object>));
    }

    [TestMethod]
    public void GivenAnonymousObject_WhenArrayListMethodInvoked_ThenValidateListCreated()
    {
        var actualOutput = GenericListOfAnonymousTypesExamples<object>.GeneretaListOfAnonymousTypesUsingArrayList(_inputObject);

        Assert.IsInstanceOfType(actualOutput, typeof(ArrayList));
    }

    [TestMethod]
    public void GivenAnonymousObject_WhenCustomMethodInvoked_ThenValidateListCreated()
    {
        var actualOutput = GenericListOfAnonymousTypesExamples<object>.GenerateListOfAnonymousTypesUsingCustomMethod(_inputObject);

        Assert.IsInstanceOfType(actualOutput, typeof(List<object>));
    }
}