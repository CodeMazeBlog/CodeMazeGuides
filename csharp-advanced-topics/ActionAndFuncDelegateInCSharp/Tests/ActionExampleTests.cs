using Xunit;
using Shouldly;
using ActionAndFuncDelegateInCSharp.Model;
using System;

namespace Tests
{
    public class ActionExampleTests
    {
        [Fact]
        public void WhenInvokingActionWithLaptopInstance_PriceChanges()
        {
            var laptop = new Laptop();

            laptop.Price.ShouldBe(0);

            Action<Laptop> priceUpdater = laptop => laptop.Price = 56;

            priceUpdater(laptop);

            laptop.Price.ShouldBeGreaterThan(0);
        }
    }
}