using ActionFuncDelegates;

namespace Tests;

public class ActionFuncExampleTests
{
    private ActionFuncExample _target;

    [SetUp]
    public void SetUp()
    {
        _target = new ActionFuncExample();
    }

    [Test]
    public void GivenGetItemsFilteredByPrice_WhenCalled_ThenReturnsCorrectCountOfFilteredItems()
    {
        //Arrange

        var data = Item.GetItems();
        int expectedCount = 5;
        decimal price = 100;

        //Act

        var items = _target.GetItemsFilteredByPrice(data, price);

        //Assert

        Assert.That(items.Count, Is.EqualTo(expectedCount));

    }

    [Test]
    public void GivenGetItemsFilteredByPrice_WhenCalled_ThenFilterItemsByTitle()
    {
        //Arrange

        var data = Item.GetItems();
        int expectedCount = 1;
        string titleContains = "7";

        //Act

        var items = _target.GetItemsFilteredByTitle(data, titleContains);

        //Assert

        Assert.That(items.Count, Is.EqualTo(expectedCount));

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