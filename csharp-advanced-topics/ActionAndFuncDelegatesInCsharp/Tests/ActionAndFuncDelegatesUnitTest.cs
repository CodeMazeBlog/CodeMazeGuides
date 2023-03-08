using ActionAndFuncDelegatesInCsharp;
using System;
namespace Tests
{
    public class ActionAndFuncDelegatesUnitTest
    {        
        // Test using delegate keyword
        [Theory]
        [InlineData(new int[] { 7, 6, 4, 5, 3 }, 4)]
        public void GivenListContainsOnlyOneOcurranceOfItem_WhenFindOnlyOne_ThenReturnsTheOnlyItem(int[] list, int input)
        {
            Program.Find find = Finder.FindOnlyOne;
            int index = find.Invoke(list, input);

            Assert.Equal(2, index);
        }

        [Theory]
        [InlineData(new int[] { 7, 6, 4, 5, 3 }, 1)]
        public void GivenListLacksItem_WhenFindOnlyOne_ThenReturnException(int[] list, int input)
        {
            Program.Find find = Finder.FindOnlyOne;

            Assert.Throws<Exception>(() => find.Invoke(list, input));
        }
        
        [Theory]
        [InlineData(new int[] { 7, 6, 4, 5, 7 }, 7)]
        public void GivenListContainsTheItemMoreThanOnce_WhenFindOnlyOne_ThenReturnException(int[] list, int input)
        {
            Program.Find find = Finder.FindOnlyOne;

            Assert.Throws<Exception>(() => find.Invoke(list, input));
        }
                
        // Test using Func<I1,I2,...,O>        
        [Theory]
        [InlineData(new int[] { 7, 6, 4, 5, 3 }, 4)]
        public void GivenListContainsOnlyOneOcurranceOfItem_WhenFindOnlyOneUsingFunc_ThenReturnsTheOnlyItem(int[] list, int input)
        {
            Func<int[], int, int> find = Finder.FindOnlyOne;
            int index = find.Invoke(list, input);

            Assert.Equal(2, index);
        }

        [Theory]
        [InlineData(new int[] { 7, 6, 4, 5, 3 }, 1)]
        public void GivenListLacksItem_WhenFindOnlyOneUsingFunc_ThenReturnException(int[] list, int input)
        {
            Func<int[], int, int> find = Finder.FindOnlyOne;

            Assert.Throws<Exception>(() => find.Invoke(list, input));
        }

        [Theory]
        [InlineData(new int[] { 7, 6, 4, 5, 7 }, 7)]
        public void GivenListContainsTheItemMoreThanOnce_WhenFindOnlyOneUsingFunc_ThenReturnException(int[] list, int input)
        {

            Func<int[], int, int> find = Finder.FindOnlyOne;

            Assert.Throws<Exception>(() => find.Invoke(list, input));
        }
        
        // Test using anonymous delegate definition 
        [Theory]
        [InlineData(new int[] { 7, 6, 4, 5, 7 }, 8)]
        public void GivenListLacksItem_WhenFindMaximumOne_ThenReturnsMinuesOne(int[] list, int input)
        {
            int index = Finder.FindMaximumOne(list, input);

            Assert.Equal(-1, index);
        }
       
        [Theory]
        [InlineData(new int[] { 7, 6, 4, 5, 7 }, 7)]
        public void GivenListContainsItemMoreThanOnce_WhenFindMaximumOne_ThenReturnsException(int[] list, int input)
        {
            Assert.Throws<Exception>(() => Finder.FindMaximumOne(list, input));
        }
        
        [Theory]
        [InlineData(new int[] { 7, 6, 4, 5, 6 }, 5)]
        public void GivenListContainsItemOnlyOnce_WhenFindMaximumOne_ThenReturnsIndex(int[] list, int input)
        {
            int index = Finder.FindMaximumOne(list, input);

            Assert.Equal(3, index);
        }
        
        // Test using lambda        
        [Theory]
        [InlineData(new int[] { 1, 7, 9, 1, 6 }, 1)]
        public void GivenListContainsItemTwice_WhenFindLastIndex_ThenReturnsSecondIndex(int[] list, int input)
        {
            int index = Finder.FindLastIndex(list, input);

            Assert.Equal(3, index);
        }

        [Theory]
        [InlineData(new int[] { 1, 7, 9, 6 }, 5)]
        public void GivenListLacksItem_WhenFindLastIndex_ThenReturnsMinuesOne(int[] list, int input)
        {
            int index = Finder.FindLastIndex(list, input);

            Assert.Equal(-1, index);
        }

        [Theory]
        [InlineData(new int[] { 1, 7, 9, 6 }, 6)]
        public void GivenListContainItemOnlyOnce_WhenFindLastIndex_ThenReturnsIndex(int[] list, int input)
        {
            int index = Finder.FindLastIndex(list, input);

            Assert.Equal(3, index);
        }

        /// Test Action       
        [Theory]
        [InlineData("John", "Smith")]
        public void GivenNameAndFamily_WhenFormalGreeting_ThenWritesToConsoleCorrectly(string name, string family)
        {
            var mockConsoleWriter = new MockConsoleWriter();
            GreetingManager greetingManager = new GreetingManager(mockConsoleWriter);
            Action<string, string> greeting = greetingManager.FormalGreeting;
            string expectedString = $"Hi {name} {family}!\r\nWelcome to Code Maze, your .NET learning website!"
                + $"\r\nWhatever you want to learn, we are here to help!\r\nLet's start...\r\n\r\n";
            greeting.Invoke(name, family);
            var exception = Record.Exception(() => mockConsoleWriter.VerifyOutput(expectedString, 1));
                     
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("John", "")]
        public void GivenOnlyName_WhenFormalGreeting_ThenWritesToConsoleCorrectly(string name, string family)
        {
            var mockConsoleWriter = new MockConsoleWriter();
            GreetingManager greetingManager = new GreetingManager(mockConsoleWriter);
            Action<string, string> greeting = greetingManager.FormalGreeting;
            string expectedString = $"Hi {name}!\r\nWelcome to Code Maze, your .NET learning website!"
               + $"\r\nWhatever you want to learn, we are here to help!\r\nLet's start...\r\n\r\n";
            greeting.Invoke(name, family);
            var exception = Record.Exception(() => mockConsoleWriter.VerifyOutput(expectedString, 1));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData(null, "Smith")]
        public void GivenOnlyFamily_WhenFormalGreeting_ThenWritesToConsoleCorrectly(string name, string family)
        {
            var mockConsoleWriter = new MockConsoleWriter();
            GreetingManager greetingManager = new GreetingManager(mockConsoleWriter);
            Action<string, string> greeting = greetingManager.FormalGreeting;
            string expectedString = $"Hi {family}!\r\nWelcome to Code Maze, your .NET learning website!"
                + $"\r\nWhatever you want to learn, we are here to help!\r\nLet's start...\r\n\r\n";
            greeting.Invoke(name, family);
            var exception = Record.Exception(() => mockConsoleWriter.VerifyOutput(expectedString, 1));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData(null, null)]
        public void GivenNoNameAndFamily_WhenFormalGreeting_ThenWritesToConsoleCorrectly(string name, string family)
        {
            var mockConsoleWriter = new MockConsoleWriter();
            GreetingManager greetingManager = new GreetingManager(mockConsoleWriter);
            Action<string, string> greeting = greetingManager.FormalGreeting;
            string expectedString = $"Hi !\r\nWelcome to Code Maze, your .NET learning website!"
                + $"\r\nWhatever you want to learn, we are here to help!\r\nLet's start...\r\n\r\n";
            greeting.Invoke(name, family);
            var exception = Record.Exception(() => mockConsoleWriter.VerifyOutput(expectedString, 1));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("John", "Smith")]
        public void GivenNameAndFamily_WhenInformalGreeting_ThenWritesToConsoleCorrectly(string name, string family)
        {
            var mockConsoleWriter = new MockConsoleWriter();
            GreetingManager greetingManager = new GreetingManager(mockConsoleWriter);
            Action<string, string> greeting = greetingManager.InformalGreeting;
            string expectedString = $"Hey {name} {family}!\r\nIt's Code Maze here!" +
                $"\r\nWhatever you want to learn, we are here to help!\r\nLet's have fun :)";
            greeting.Invoke(name, family);
            var exception = Record.Exception(() => mockConsoleWriter.VerifyOutput(expectedString, 1));

            Assert.Null(exception);
        }
    }
}