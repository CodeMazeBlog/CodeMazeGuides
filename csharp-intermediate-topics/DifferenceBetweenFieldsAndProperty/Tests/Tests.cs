namespace Tests;

public class Tests
{
    [Fact]
    public void GivenVoter_WhenAssigningAgeLessThanEighteen_ThenThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Voter("Kramer", 14));
    }

    [Fact]
    public void GivenVoterWithAgeGreaterThanEighteen_WhenInvokingDisplayIsVoter_ThenReturnsMessage()
    {
        var voterObject = new Voter("Steve", 35);

        Assert.Equal("The person can vote as their age is: 35", voterObject.DisplayIsVoter());
    }
}