using Xunit;
using Shouldly;
using ActionAndFuncDelegateInCSharp.Model;
using ActionAndFuncDelegateInCSharp.Examples;

namespace Tests
{
public class ActionExampleTests
{
    [Fact]
    public void WhenInvokingActionWithLaptopInstance_PriceChanges()
    {
        var laptop = new Laptop();

        laptop.Price.ShouldBe(0);

        new ActionExamples().LaptopPriceUpdater(laptop);

        laptop.Price.ShouldBeGreaterThan(0);
    }
}
}