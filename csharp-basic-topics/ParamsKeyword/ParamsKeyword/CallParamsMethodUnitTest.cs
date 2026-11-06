using NUnit.Framework;

namespace ParamsKeyword;

[TestFixture]
public class CallParamsMethodUnitTest
{
    private StringWriter _writer = null!;

    [SetUp]
    public void CaptureConsole()
    {
        _writer = new StringWriter();
        Console.SetOut(_writer);
    }

    [TearDown]
    public void ReleaseConsole() => _writer.Dispose();

    private string[] Lines() =>
        _writer.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    [Test]
    public void WhenCommaDelimitedListOfArgs_ThenReturnsValidResult()
    {
        var shoppingList = new ShoppingList();
        shoppingList.Add("Bananas", "Grapes", "Ham", "Cheese");
        shoppingList.Add("Headphones");

        string[] expectedResult =
        [
            "Added: Bananas",
            "Added: Grapes",
            "Added: Ham",
            "Added: Cheese",
            "Added: Headphones",
        ];

        Assert.That(Lines(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void WhenCollectionArgument_ThenReturnsValidResult()
    {
        var shoppingList = new ShoppingList();
        string[] groceries = ["Bananas", "Grapes", "Ham", "Cheese"];
        shoppingList.Add(groceries);

        string[] expectedResult = ["Added: Bananas", "Added: Grapes", "Added: Ham", "Added: Cheese"];

        Assert.That(Lines(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void WhenNoArguments_ThenReturnsValidResult()
    {
        var shoppingList = new ShoppingList();
        shoppingList.Add();

        Assert.That(_writer.ToString(), Is.Empty);
    }

    [Test]
    public void WhenNullArgument_ThenThrowsAnException()
    {
        var shoppingList = new ShoppingList();
        string[]? groceries = default;

#pragma warning disable CS8604 // Possible null reference argument.
        Assert.Throws<NullReferenceException>(() => shoppingList.Add(groceries));
#pragma warning restore CS8604
    }

    [Test]
    public void WhenParamsIEnumerable_ThenAcceptsListAndLinqResult()
    {
        var shoppingList = new ShoppingList();
        shoppingList.AddRange("Milk", "Eggs");

        List<string> pantry = ["Rice", "Beans", "Pasta"];
        shoppingList.AddRange(pantry.Where(item => item.StartsWith('B')));

        string[] expectedResult = ["Added: Milk", "Added: Eggs", "Added: Beans"];

        Assert.That(Lines(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void WhenParamsReadOnlySpan_ThenCountsArguments()
    {
        var shoppingList = new ShoppingList();

        Assert.That(shoppingList.Count("Bananas", "Grapes", "Ham"), Is.EqualTo(3));
        Assert.That(shoppingList.Count(), Is.EqualTo(0));
    }

    [Test]
    public void WhenOtherParametersBeforeParams_ThenTheRestGoToParams()
    {
        Assert.That(ParamsSignatures.StringBeforeStringParams("Required", "And", "Free"), Is.EqualTo("Required + 2"));
        Assert.That(ParamsSignatures.ArrayBeforeParams(["Required", "Array"], "And", "Free", "Arguments"), Is.EqualTo("2 + 3"));
        Assert.That(ParamsSignatures.ArrayBeforeParams(["Required", "Array"], ["And", "Array", "For Params"]), Is.EqualTo("2 + 3"));
        Assert.That(ParamsSignatures.OtherArgumentsBeforeParams(2, true, "Yeah", "Now", "All good"), Is.EqualTo("2, True, 3"));
        Assert.That(ParamsSignatures.UseParamsWithNamedArguments(firstArgument: 10, items: ["Now", "all", "good"]), Is.EqualTo("10 + 3"));
    }

    [Test]
    public void WhenArrayAndSpanOverloads_ThenListPicksSpanAndArrayPicksArray()
    {
        var basket = new Basket();
        basket.Store("Bananas", "Grapes");
        string[] groceries = ["Bananas", "Grapes"];
        basket.Store(groceries);

        string[] expectedResult = ["Span overload: 2 items", "Array overload: 2 items"];

        Assert.That(Lines(), Is.EqualTo(expectedResult));
    }

    [Test]
    public void WhenArrayPassedToParamsObject_ThenOnlyReferenceTypeArraysExpand()
    {
        string[] names = ["Bananas", "Grapes"];
        int[] quantities = [3, 5];

        Assert.That(ParamsSignatures.CountObjects(names), Is.EqualTo(2));
        Assert.That(ParamsSignatures.CountObjects(quantities), Is.EqualTo(1));
    }

    [Test]
    public void WhenNamedArgumentWithSingleValue_ThenCompilesAsOneElementArray()
    {
        Assert.That(ParamsSignatures.UseParamsWithNamedArguments(firstArgument: 10, items: "Single"), Is.EqualTo("10 + 1"));
    }
}
