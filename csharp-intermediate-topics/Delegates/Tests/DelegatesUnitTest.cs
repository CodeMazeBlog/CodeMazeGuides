using Delegates.Closures;

namespace Tests;

public class DelegatesUnitTest
{
    [Test]
    public void WhenIncorrectlyImplementedClosures_ThenWrongResult()
    {
        const int rounds = 5;
        var result = new Main().SumUntilWrong(rounds);
        
        const int expectedResult = (rounds + 1) * rounds; //the last value of i is rounds+1 and we have rounds iterations
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void WhenCorrectlyImplementedClosures_ThenCorrectResult()
    {
        var result = new Main().SumUntilFixed(5);
        
        const int expectedResult = 1 + 2 + 3 + 4 + 5;
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}