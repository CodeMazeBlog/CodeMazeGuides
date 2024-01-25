namespace Tests;

public class Tests
{
    [Fact]
    public void GivenVoter_WhenAssigningAgeLessThanEighteen_ThenThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Voter(14));
    }

    [Fact]
    public void GivenVoterWithAgeGreaterThanEighteen_WhenInvokingDisplayIsVoter_ThenReturnsMessage()
    {
        var voterObject = new Voter(35);

        Assert.Equal("The person can vote as their age is: 35", voterObject.DisplayIsVoter());
    }
}