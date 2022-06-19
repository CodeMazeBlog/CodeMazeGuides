using ActionAndFuncDelegatesInCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class Tests
    {
        static void WriteCurrentDateTime() => Console.WriteLine(DateTime.Now);
        static string GetGreetingsMessage(string name, int age)
        {
            return $"Hello, my name is {name} and I'm {age} years old!";
        }

        static double CalculateOrderPrice(List<Ticket> ticketList, bool isDiscountAplied)
        {
            var totalPrice = ticketList.Sum(ticket => ticket.Price);

            if (isDiscountAplied)
            {
                return totalPrice * 0.90;
            }

            return totalPrice;
        }

        static void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }


        [Fact]
        public void givenActionDelegate_whenCurrentDateTimeIsWritten_DelegateInvocationListNotEmpty()
        {
            Action writeCurrentDateTimeDelegate = WriteCurrentDateTime;
            var invocationList = writeCurrentDateTimeDelegate.GetInvocationList();
            Assert.NotEmpty(invocationList);
        }

        [Fact]
        public void givenFuncDelegate_whenNameAndAgeAreSet_DelegateReturnsTheExpectedStringValue()
        {
            Func<string, int, string> getGreetingsMessageDelegate = GetGreetingsMessage;
            var result = getGreetingsMessageDelegate("John", 26);
            Assert.Equal("Hello, my name is John and I'm 26 years old!", result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void givenFuncDelegate_whenFuncDelegateIsPassedAsParameter_DelegateReturnsTheExpectedValueBasedOnTheDiscountParameter(bool isDiscoundApplied)
        {
            var movieOrder = GetTestMovieOrder();
            var calculatedPrice = movieOrder.CalculateTotalPrice(CalculateOrderPrice, isDiscoundApplied);

            if (isDiscoundApplied)
            {
                Assert.Equal(GetTestTicketList().Sum(ticket => ticket.Price) * 0.9, calculatedPrice);
            }
            else
            {
                Assert.Equal(GetTestTicketList().Sum(ticket => ticket.Price), calculatedPrice);
            }
        }

        [Fact]
        public void givenActionDelegate_whenActionDelegateIsPassedAsParameter_DelegateInvocationListNotEmpty()
        {
            var movieOrder = GetTestMovieOrder();
            Action<string> writeToConsoleDelegate = WriteToConsole;
            movieOrder.Pay(writeToConsoleDelegate);
            var invocationList = writeToConsoleDelegate.GetInvocationList();
            Assert.NotEmpty(invocationList);
        }

        //Helper methods

        private MovieOrder GetTestMovieOrder()
        {
            List<Ticket> ticketList = GetTestTicketList();
            return new MovieOrder(ticketList, "The Shawshank Redemption");
        }

        private List<Ticket> GetTestTicketList()
        {
            return new List<Ticket>
            {
                new Ticket(50),
                new Ticket(40)
            };
        }
    }
}
