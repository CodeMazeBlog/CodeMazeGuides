namespace Tests;

public class Tests
{
    [Fact]
    public void GivenPersonAgeLessThanEighteen_WhenAssignedToProperty_ThenReturnErrorMessage()
    {
        var voterObject = new Voter();

        Assert.Throws<ArgumentException>(() => voterObject.Age = 14);
    }

    [Fact]
    public void GivenPersonAgeGreaterThanEighteen_WhenAssignedToPropertyAndCallMethod_ThenReturnMessage()
    {
        var voterObject = new Voter(35);

        Assert.Equal("The person can vote as their age is: 35", voterObject.DisplayIsVoter());
    }
}