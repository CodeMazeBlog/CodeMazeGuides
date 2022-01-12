using Xunit;
using Shouldly;
using ActionAndFuncDelegateInCSharp.Model;
using System;

namespace Tests
{
    public class FuncExampleTests
    {
        [Fact]
        public void WhenInvokingFuncThatReturnsRandomNumber_ThenTwoConsecutiveValuesShouldNotBeSame()
        {
            var random = new Random();

            Func<int> randomNumberGenerator = () => random.Next();

            int randomNumber = randomNumberGenerator();

            randomNumberGenerator().ShouldNotBe(randomNumber);
        }

        [Fact]
        public void WhenInvokingBankIdGetter_PersonIDNumberShouldBeMentioned()
        {
            var person = new Person()
            {
                NationalIdentity = "random"
            };

            Func<Person, Bank, string> bankIdGetter = (person, bank) => bank.GetBankId(person);

            var bankId = bankIdGetter(person, new Bank());

            bankId.ShouldNotBeNull();
            bankId.ShouldContain(person.NationalIdentity);
        }

        [Fact]
        public void WhenInvokedWithInvokeMethod_TheImpactIsSame()
        {
            var person = new Person()
            {
                NationalIdentity = "random"
            };

            Func<Person, Bank, string> bankIdGetter = (person, bank) => bank.GetBankId(person);

            var bankId = bankIdGetter.Invoke(person, new Bank());

            bankId.ShouldNotBeNull();
            bankId.ShouldContain(person.NationalIdentity);
        }

        [Fact]
        public void FuncReturnsTheValueOfTheLastAttachedMethod_WhenUsedInMultiCastScenario()
        {
            Func<int> numberGenerator = () => 10;

            numberGenerator += () => 20;

            var v = numberGenerator();

            v.ShouldNotBe(10);
            v.ShouldBe(20);
        }

        [Fact]
        public void FuncCanBeCreatedUsingNewKeyword()
        {
            Func<int> numberGenerator = new Func<int>(() => 10);

            var v = numberGenerator();

            v.ShouldBe(10);
        }


        [Fact]
        public void UnSafeInvocation_WhenDelegateInstanceIsNull()
        {
            Func<int> numberGenerator = null;

            Action act = () => numberGenerator();

            act.ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void SafeInvocation_WhenDelegateInstanceIsNull()
        {
            Func<int> numberGenerator = null;

            Action act = () => numberGenerator?.Invoke();

            act.ShouldNotThrow();
        }
    }
}