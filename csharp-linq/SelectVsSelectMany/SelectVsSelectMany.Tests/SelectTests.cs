namespace SelectVsSelectMany.Tests;

public class Tests
{
    [Test]
    public void WhenUsingSelectOnCollection_ThenResultContainsTranformedCollection()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var expectedResult = new List<int> { 2, 4, 6, 8, 10 };

        var doubledNumbers = numbers.Select(num => num * 2);
        
        Assert.That(doubledNumbers, Is.EquivalentTo(expectedResult));
    }
    
    [Test]
    public void WhenUsingSelectWithIndexOnCollection_ThenResultContainsTranformedCollection()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var expectedResult = new List<int> { 0, 2, 6, 12, 20 };

        var transformedNumbers = numbers.Select((num, index) => num * index);
        
        Assert.That(transformedNumbers, Is.EquivalentTo(expectedResult));
    }
}