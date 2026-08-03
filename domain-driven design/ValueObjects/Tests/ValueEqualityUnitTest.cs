using ValueObjects.Entities;
using ValueObjects.ValueObjects;

namespace Tests;

public class ValueEqualityUnitTest
{
    [Test]
    public void GivenTwoRecords_WhenTheyHaveTheSameData_ThenTheyShouldBeEqual()
    {
        var hundredUsd = Money.Create(100, "USD");
        var another100Usd = Money.Create(100, "USD");
        
        Assert.That(hundredUsd.IsSuccess, Is.True);
        Assert.That(another100Usd.IsSuccess, Is.True);
        Assert.That(another100Usd.Value, Is.EqualTo(hundredUsd.Value));
    }
    
    [Test]
    public void GivenTwoRecords_WhenTheyHaveTheDifferentData_ThenTheyShouldNotBeEqual()
    {
        var hundredUsd = Money.Create(100, "USD");
        var hundredEur = Money.Create(100, "EUR");
        
        Assert.That(hundredUsd.IsSuccess, Is.True);
        Assert.That(hundredEur.IsSuccess, Is.True);
        Assert.That(hundredEur.Value, Is.Not.EqualTo(hundredUsd.Value));
    }
    
    [Test]
    public void GivenTwoClasses_WhenTheyHaveTheSameData_ThenTheyShouldNotBeEqual()
    {
        var hundredUsd = Money.Create(100, "USD");
        var payment1 = new Payment(hundredUsd.Value!);
        var payment2 = new Payment(hundredUsd.Value!);
        
        Assert.That(payment1, Is.Not.EqualTo(payment2));
    }
}