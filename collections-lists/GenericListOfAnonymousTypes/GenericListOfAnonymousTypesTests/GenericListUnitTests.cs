using GenericListOfAnonymousTypes;

namespace GenericListOfAnonymousTypesTests;

[TestClass]
public class GenericListUnitTests
{
    object[] _inputObject = GenericListOfAnonymousTypesExamples.GenerateRandomAnonymousObject();

    [TestMethod]
    public void GivenAnonymousObject_WhenToListMethodInvoked_ThenValidateListCreated()
    {
        var actualOutput = GenericListOfAnonymousTypesExamples.GeneretaListOfAnonymousTypesUsingToList(_inputObject);

        Assert.IsInstanceOfType(actualOutput, typeof(List<object>));
    }

    [TestMethod]
    public void GivenAnonymousObject_WhenDynamicUsed_ThenValidateListCreated()
    {
        var actualOutput = GenericListOfAnonymousTypesExamples.GeneretaListOfAnonymousTypesUsingDynamic(_inputObject);

        Assert.IsInstanceOfType(actualOutput, typeof(List<dynamic>));
    }

    [TestMethod]
    public void GivenAnonymousObject_WhenLinqUsed_ThenValidateListCreated()
    {
        var actualOutput = GenericListOfAnonymousTypesExamples.GeneretaListOfAnonymousTypesUsingLINQ();

        Assert.IsInstanceOfType(actualOutput, typeof(List<object>));
    }

    [TestMethod]
    public void GivenAnonymousObject_WhenGenericsUsed_ThenValidateListCreated()
    {
        var actualOutput = GenericMethod<object>.CreateGenericList(_inputObject);

        Assert.IsInstanceOfType(actualOutput, typeof(List<object>));
    }

    [TestMethod]
    public void GivenAnonymousObject_WhenGenerateSampleAnonymousTypeMethodInvoked_ThenValidateListCreated()
    {
        var actualOutput = GenericListOfAnonymousTypesExamples.GenerateRandomAnonymousObject();
        
        Assert.IsInstanceOfType(actualOutput, typeof(object[]));
    }
}