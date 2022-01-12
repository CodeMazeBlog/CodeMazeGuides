using Xunit;
using Shouldly;
using ActionAndFuncDelegateInCSharp.Model;
using System;
using Xunit.Abstractions;

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

        [Fact]
        public void WhenInvokingUsingInvokeMethodAndWithALaptopInstance_PriceChanges()
        {
            var laptop = new Laptop();

            laptop.Price.ShouldBe(0);

            Action<Laptop> priceUpdater = laptop => laptop.Price = 56;

            priceUpdater.Invoke(laptop);

            laptop.Price.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void DelegateThatContainsNullWillThrowNullReferenceExeption_WhenInvoked()
        {
            var laptop = new Laptop();

            laptop.Price.ShouldBe(0);

            Action<Laptop> priceUpdater = null;

            Action act = () => priceUpdater(laptop);

            act.ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void SafeInvocationOfDelegate_WhenDelegateInstanceIsNull()
        {
            var laptop = new Laptop();

            laptop.Price.ShouldBe(0);

            Action<Laptop> priceUpdater = null;

            Action act = () => priceUpdater?.Invoke(laptop);

            act.ShouldNotThrow();
        }

        [Fact]
        public void MulticastBehaviorIsShown_WhenActionsAreAppendedToAnDelegateInstance()
        {
            var laptop = new Laptop();

            laptop.Price.ShouldBe(0);

            Action<Laptop> priceUpdater = (laptop) => laptop.Price += 34;

            priceUpdater += (laptop) => laptop.Price += 56;

            priceUpdater.Invoke(laptop);

            laptop.Price.ShouldBe(90);

            Action<Laptop> _priceUpdater = new Action<Laptop>(laptop => laptop.Price += 34);

            Action v = new Action(() => { });
        }
    }
}