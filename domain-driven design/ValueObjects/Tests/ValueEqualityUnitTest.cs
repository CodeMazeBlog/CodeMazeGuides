using ValueObjects.Entities;
using ValueObjects.ValueObjects;

namespace Tests;

public class ValueEqualityUnitTest
{
    [Fact]
    public void GivenTwoRecords_WhenTheyHaveTheSameData_ThenTheyShouldBeEqual()
    {
        var hundredUsd = Money.Create(100, "USD");
        var another100Usd = Money.Create(100, "USD");

        Assert.True(hundredUsd.IsSuccess);
        Assert.True(another100Usd.IsSuccess);
        Assert.Equal(hundredUsd.Value, another100Usd.Value);
    }

    [Fact]
    public void GivenTwoRecords_WhenTheyHaveDifferentData_ThenTheyShouldNotBeEqual()
    {
        var hundredUsd = Money.Create(100, "USD");
        var hundredEur = Money.Create(100, "EUR");

        Assert.True(hundredUsd.IsSuccess);
        Assert.True(hundredEur.IsSuccess);
        Assert.NotEqual(hundredUsd.Value, hundredEur.Value);
    }

    [Fact]
    public void GivenTwoClasses_WhenTheyHaveTheSameData_ThenTheyShouldNotBeEqual()
    {
        var hundredUsd = Money.Create(100, "USD").Value;
        var payment1 = new Payment(hundredUsd);
        var payment2 = new Payment(hundredUsd);

        Assert.NotEqual(payment1, payment2);
    }
}
