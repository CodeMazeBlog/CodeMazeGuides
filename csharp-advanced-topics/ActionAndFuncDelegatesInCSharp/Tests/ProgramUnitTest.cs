using Xunit;

namespace FuncAndActionDelegates.Tests
{
    public class ProgramUnitTest : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOutput;

        public ProgramUnitTest()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        [Fact]
        public void WhenWriteMessageUsingActionCalled_ThenWritesExpectedMessage()
        {
            // When
            Program.WriteMessageUsingAction();
            
            // Then
            Assert.Equal($"first message{Environment.NewLine}", _stringWriter.ToString());
        }

        [Fact]
        public void WhenWriteGreetingUsingActionLambdaCalled_ThenWritesExpectedGreeting()
        {
            // When
            Program.WriteGreetingUsingActionLambda();
            
            // Then
            Assert.Equal($"Hello, John Doe!{Environment.NewLine}", _stringWriter.ToString());
        }

        [Fact]
        public void WhenWriteHelloWorldUsingActionCalled_ThenWritesExpectedMessage()
        {
            // When
            Program.WriteHelloWorldUsingAction();
            Assert.Equal($"Hello, World!{Environment.NewLine}", _stringWriter.ToString());
        }

        [Fact]
        public void WhenWriteGreetingUsingActionDelegateCalled_ThenWritesExpectedGreeting()
        {
            // When
            Program.WriteGreetingUsingActionDelegate();
            
            // Then
            Assert.Equal($"Hello, John Doe!{Environment.NewLine}", _stringWriter.ToString());
        }

        [Fact]
        public void WhenCountAndPrintDevelopmentToolsUsingFuncCalled_ThenWritesExpectedResults()
        {
            // When
            Program.CountAndPrintDevelopmentToolsUsingFunc();

            var expected = string.Join(Environment.NewLine,
                "Found 2 results:",
                "Name: Microsoft SQL Server Management Studio 18, Development Tool: Yes",
                "Name: Visual Studio 2022, Development Tool: Yes",
                "");

            // Then
            Assert.Equal(expected, _stringWriter.ToString());
        }

        [Fact]
        public void GivenSoftwareList_WhenPrepareMessageIsCalled_ThenShouldReturnExpectedResult()
        {
            // Given
            var softwareList = new List<SoftwareInfo>
            {
                new SoftwareInfo("Test Software 1", isDevelopmentSoftware: true),
                new SoftwareInfo("Test Software 2", isDevelopmentSoftware: false),
            };

            var expectedOutput = string.Join(Environment.NewLine,
                "Name: Test Software 1, Development Tool: Yes",
                "Name: Test Software 2, Development Tool: No",
                "");

            // When
            foreach (var softwareItem in softwareList)
            {
                Console.WriteLine(softwareItem);
            }

            // Then
            Assert.Equal(expectedOutput, _stringWriter.ToString());
        }

        [Fact]
        public void GivenSoftwareList_WhenPrintSoftwareEnumerableIsCalled_ThenShouldPrintExpectedResults()
        {
            // Given
            var softwareList = new List<SoftwareInfo>
            {
                new SoftwareInfo("Test Software 1", isDevelopmentSoftware: true),
                new SoftwareInfo("Test Software 2", isDevelopmentSoftware: false),
            };

            var expectedOutput = string.Join(Environment.NewLine,
                "Name: Test Software 1, Development Tool: Yes",
                "Name: Test Software 2, Development Tool: No",
                "");

            // When
            foreach (var softwareItem in softwareList)
            {
                Console.WriteLine(softwareItem);
            }

            // Then
            Assert.Equal(expectedOutput, _stringWriter.ToString());

        }

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _stringWriter.Dispose();
        }
    }

}