using Xunit;
using Shouldly;
using ActionAndFuncDelegateInCSharp;
using ActionAndFuncDelegateInCSharp.Model;

namespace Tests
{
    public class FuncExampleTests
    {
        [Fact]
        public void WhenInvokingFuncThatReturnsRandomNumber_ThenTwoConsecutiveValuesShouldNotBeSame()
        {
            int randomNumber = new FuncExamples().RandomNumberGenerator();

            new FuncExamples()
                .RandomNumberGenerator()
                .ShouldNotBe(randomNumber);
        }

        [Fact]
        public void WhenInvokingBankIdGetter_PersonIDNumberShouldBeMentioned()
        {
            Person person = new Person()
            {
                NationalIdentity = "random"
            };

            var bankId = new FuncExamples().BankIdGetter(person, new Bank());

            bankId.ShouldNotBeNull();
            bankId.ShouldContain(person.NationalIdentity);
        }
    }
}