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
    }
}