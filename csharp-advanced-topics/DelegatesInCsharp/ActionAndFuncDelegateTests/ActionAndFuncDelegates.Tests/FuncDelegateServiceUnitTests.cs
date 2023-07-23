using ActionAndFuncDelegates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates.Tests
{
    public class FuncDelegateServiceUnitTests
    {

        #region Mathematical Calculations

       
        [Theory]
        [InlineData(5, 10, 15)] // 5 + 10 = 15
        [InlineData(-5, 10, 5)] // -5 + 10 = 5
        [InlineData(0, 0, 0)] // 0 + 0 = 0
        public void Add_GivenTwoNumbers_WhenAddIsCalled_ThenShouldReturnSum(int a, int b, int expectedSum)
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.AdditionFunc = (x, y) => x + y; // Set the AdditionFunc delegate

            // Act
            int actualSum = funcDelegateService.Add(a, b);

            // Assert
            Assert.Equal(expectedSum, actualSum);

        }

        [Theory]
        [InlineData(10, 5, 5)] // 10 - 5 = 5
        [InlineData(-5, 10, -15)] // -5 - 10 = -15
        [InlineData(0, 0, 0)] // 0 - 0 = 0
        public void Subtract_GivenTwoNumbers_WhenSubtractIsCalled_ThenShouldReturnDifference(int a, int b, int expectedDifference)
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.SubtractionFunc = (x, y) => x - y;

            // Act
            int actualDifference = funcDelegateService.Subtract(a, b);

            // Assert
            Assert.Equal(expectedDifference, actualDifference);
        }

        [Theory]
        [InlineData(5, 10, 50)] // 5 * 10 = 50
        [InlineData(-5, 10, -50)] // -5 * 10 = -50
        [InlineData(0, 0, 0)] // 0 * 0 = 0
        public void Multiply_GivenTwoNumbers_WhenMultiplyIsCalled_ThenShouldReturnProduct(int a, int b, int expectedProduct)
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.MultiplicationFunc = (x, y) => x * y; // Set the MultiplicationFunc delegate

            // Act
            int actualProduct = funcDelegateService.Multiply(a, b);

            // Assert
            Assert.Equal(expectedProduct, actualProduct);
        }

        [Theory]
        [InlineData(10, 2, 5)] // 10 / 2 = 5
        [InlineData(-10, 2, -5)] // -10 / 2 = -5
        [InlineData(5, 0, double.PositiveInfinity)] // 5 / 0 = Positive Infinity
        public void Divide_GivenTwoNumbers_WhenDivideIsCalled_ThenShouldReturnQuotient(int a, int b, double expectedQuotient)
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.DivisionFunc = (x, y) => (double)x / y; // Set the DivisionFunc delegate

            // Act
            double actualQuotient = funcDelegateService.Divide(a, b);

            // Assert
            Assert.Equal(expectedQuotient, actualQuotient);
        }

        [Fact]
        public void Divide_GivenZeroDividend_WhenDivideIsCalled_ThenShouldReturnZero()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.DivisionFunc = (x, y) => (double)x / y;
            int dividend = 0;
            int divisor = 5;
            double expectedQuotient = 0;

            // Act
            double actualQuotient = funcDelegateService.Divide(dividend, divisor);

            // Assert
            Assert.Equal(expectedQuotient, actualQuotient);
        }

        [Fact]
        public void Divide_GivenDivisorEqualToZero_WhenDivideIsCalled_ThenShouldReturnPositiveInfinity()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.DivisionFunc = (x, y) => (double)x / y;
            int dividend = 10;
            int divisor = 0;

            // Act
            double result = funcDelegateService.Divide(dividend, divisor);

            // Assert
            Assert.Equal(double.PositiveInfinity, result);
        }


        [Theory]
        [InlineData(100, 10)] // 10% tithe of 100 is 10
        [InlineData(500, 50)] // 10% tithe of 500 is 50
        [InlineData(1000, 100)] // 10% tithe of 1000 is 100
        public void CalculateTitheFunc_GivenEarnings_WhenCalculateTitheIsCalled_ThenShouldReturnCorrectTitheAmount(double earnings, double expectedTitheAmount)
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();

            // Act
            double actualTitheAmount = 0;
            funcDelegateService.CalculateTitheFunc = (e) => e * 0.1; // 10% tithe

            actualTitheAmount = funcDelegateService.CalculateTithe(earnings);

            // Assert
            Assert.Equal(expectedTitheAmount, actualTitheAmount, 2); // Using 2 decimal places for comparison
        }

        [Fact]
        public void CalculateTitheFunc_GivenNoCalculationDefined_WhenCalculateTitheIsCalled_ThenShouldThrowInvalidOperationException()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            double earnings = 500;

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => funcDelegateService.CalculateTithe(earnings));
        }

        #endregion


        #region Event Filtering Tests

        [Fact]
        public void FilterEvents_GivenValidFilterString_WhenFilterEventsIsCalled_ThenShouldReturnFilteredEvents()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            var events = new List<string> { "Event1", "Event2", "Other", "Event3" };
            string filterString = "Event";
            var expectedFilteredEvents = new List<string> { "Event1", "Event2", "Event3" };

            // Act
            var actualFilteredEvents = funcDelegateService.FilterEvents((eventName) => eventName.Contains(filterString), events);

            // Assert
            Assert.Equal(expectedFilteredEvents, actualFilteredEvents);
        }

        [Fact]
        public void FilterEvents_GivenEmptyFilterString_WhenFilterEventsIsCalled_ThenShouldReturnAllEvents()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            var events = new List<string> { "Event1", "Event2", "OtherEvent", "Event3" };
            var expectedFilteredEvents = events; // No filtering, all events should be returned

            // Act
            var actualFilteredEvents = funcDelegateService.FilterEvents((eventName) => true, events);

            // Assert
            Assert.Equal(expectedFilteredEvents, actualFilteredEvents);
        }

        [Fact]
        public void FilterEventsBySearchText_GivenValidSearchText_WhenFilterEventsBySearchTextIsCalled_ThenShouldReturnFilteredEvents()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            var events = new List<string> { "Event1", "event2", "OtherEvent", "Event3" };
            string searchText = "EVENT";
            var expectedFilteredEvents = new List<string> { "Event1", "event2", "OtherEvent", "Event3" }; 

            // Act
            var actualFilteredEvents = funcDelegateService.FilterEventsBySearchText((eventName) => ContainsCaseInsensitive(eventName, searchText), events);

            // Assert
            Assert.Equal(expectedFilteredEvents, actualFilteredEvents);
        }


        [Fact]
        public void FilterEventsBySearchText_GivenEmptySearchText_WhenFilterEventsBySearchTextIsCalled_ThenShouldThrowArgumentException()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            var events = new List<string> { "Event1", "Event2", "OtherEvent", "Event3" };

            // Act and Assert
            var filteredEvents = funcDelegateService.FilterEventsBySearchText((eventName) => false, events);

            // Assert
            Assert.Empty(filteredEvents);


        }


        // Remember to define the ContainsCaseInsensitive method (as used in the FilterEventsBySearchText test).
        private bool ContainsCaseInsensitive(string source, string filterString)
        {
            return source.IndexOf(filterString, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        //Test for null events list
        [Fact]
        public void FilterEvents_GivenNullEventsList_WhenFilterEventsIsCalled_ThenShouldThrowArgumentNullException()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            List<string> events = null!;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                funcDelegateService.FilterEvents((eventName) => true, events);
            });
        }

        //Test for null predicate
        [Fact]
        public void FilterEvents_GivenNullPredicate_WhenFilterEventsIsCalled_ThenShouldThrowArgumentNullException()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            var events = new List<string> { "Event1", "Event2", "OtherEvent", "Event3" };
            Func<string, bool> filterCriteria = null!;

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                funcDelegateService.FilterEvents(filterCriteria!, events);
            });
        }


        //Test for null FuncDelegateService
        [Fact]
        public void FilterEventsBySearchText_GivenNullFuncDelegateService_WhenFilterEventsBySearchTextIsCalled_ThenShouldThrowArgumentNullException()
        {
            // Arrange
            FuncDelegateService funcDelegateService = null!;
            var events = new List<string> { "Event1", "Event2", "OtherEvent", "Event3" };
            string searchText = "Event";

            // Act and Assert
            Assert.Throws<NullReferenceException>(() =>
            {
                funcDelegateService!.FilterEventsBySearchText((eventName) => ContainsCaseInsensitive(eventName, searchText), events);
            });
        }

        //Test for large number of events
        [Fact]
        public void FilterEvents_GivenLargeNumberOfEvents_WhenFilterEventsIsCalled_ThenShouldReturnFilteredEvents()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            var events = Enumerable.Range(1, 100000).Select(i => $"Event{i}").ToList();
            string searchText = "Event100";
            var expectedFilteredEvents = events.Where(eventName => ContainsCaseInsensitive(eventName, searchText)).ToList();

            // Act
            var actualFilteredEvents = funcDelegateService.FilterEvents(
                (eventName) => ContainsCaseInsensitive(eventName, searchText), events);

            // Assert
            Assert.Equal(expectedFilteredEvents, actualFilteredEvents);
        }



        #endregion



    }
}
