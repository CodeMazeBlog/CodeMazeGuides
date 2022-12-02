using ActionFuncDelegates;

namespace Tests;

public class DelegateExampleTests
{
    private DelegateExample _target;

    [SetUp]
    public void SetUp()
    {
        _target = new DelegateExample();
    }

    [Test]
    public void GivenTransformTitle_WhenCalled_ThenAssignNewTitleToEachItem()
    {
        //Arrange

        var data = Item.GetItems();
        string transformValue = "NewTitle";

        //Act

        var items = _target.TransformTitle(data, transformValue);

        //Assert

        items.ForEach(i => Assert.That(i.Title, Is.EqualTo(transformValue)));


    }
}