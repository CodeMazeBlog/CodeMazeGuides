using System.Text;
using Xunit;
using FuncAndActionDelegatesInCSharp;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests
{
    public class FuncAndActionDelegatesInCSharpUnitTest
    {
        [Fact]
        public void GivenRepeatWordMethod_WhenArgumentsWordAndRepsArePassed_ThenWordIsRepeatedRepsTimes()
        {
            // Arrange
            var word = "hey";
            var reps = 3;

            // Act
            var result = Utilities.RepeatWord(word, reps);

            // Assert
            var expected = "hey hey hey ";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenGreetMethod_WhenArgumentIsPassed_ThenStringIsCreatedCorrectly()
        {
            // Arrange
            var name = "Bill";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Utilities.Greet(name);
            var output = stringWriter.ToString().Trim(); // trim to remove "\r\n" added by WriteLine()

            // Assert
            var expected = "Hey, Bill!";
            Assert.Equal(expected, output);
        }

        [Fact]
        public void GivenDescribePersonMethod_WhenArgumentsArePassed_ThenStringIsCreatedCorrectly()
        {
            // Arrange
            var name = "Annie";
            var adjective = "intelligent";
            var hasFeature = true;

            // Act
            var result = Utilities.DescribePerson(name, adjective, hasFeature);

            // Assert
            var expected = "Annie is rather intelligent.";
            Assert.Equal(expected, result);
        }


        [Fact]
        public void GivenDescribeBookMethod_WhenArgumentsArePassed_ThenStringIsCreatedCorrectly()
        {
            // Arrange
            var name = "Annie";
            var adjective = "funny";
            var isGood = false;

            // Act
            var result = Utilities.DescribeBook(name, adjective, isGood);

            // Assert
            var expected = "Annie's latest book is quite funny but not to my taste.";
            Assert.Equal(expected, result);
        }


        // Func delegate
        [Fact]
        public void WhenFuncReferencesAMethod_ThenDelegateCallsTheMethod()
        {
            // Arrange
            var word = "hey";
            var reps = 2;

            // Act
            Func<string, int, string> GenerateText = Utilities.RepeatWord;
            var methodResult = Utilities.RepeatWord(word, reps);
            var funcResult = GenerateText(word, reps);

            // Assert
            var expected = methodResult == funcResult;
            Assert.True(expected);
        }


        // Action delegate
        [Fact]
        public void WhenActionReferencesAMethod_ThenDelegateCallsTheMethod()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Action MakeSound = Utilities.Bark;
            Utilities.Bark();
            MakeSound();
            var outputLines = stringWriter
                .ToString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            
            // Assert
            var expected = outputLines[0] == outputLines[1];
            Assert.True(expected);
        }


        [Fact]
        public void WhenGenericActionReferencesAMethod_ThenDelegateCallsTheMethod()
        {
            // Arrange
            var name = "Liam";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Action<string> BePolite = Utilities.Greet;
            Utilities.Greet(name);
            BePolite(name);
            var outputLines = stringWriter
                .ToString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Assert
            var expected = outputLines[0] == outputLines[1];
            Assert.True(expected);
        }

        // Instantiation
        [Fact]
        public void WhenLongNewKeywordInitiation_ThenDelegateIsCreatedCorrectly()
        {
            // Arrange
            var name = "Lisa";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Action<string> BePolite = new Action<string>(Utilities.Greet);
            BePolite(name);
            var output = stringWriter.ToString().Trim();

            // Assert
            var expected = "Hey, Lisa!";
            Assert.Equal(expected, output);
        }

        [Fact]
        public void WhenShortNewKeywordInitiation_ThenDelegateIsCreatedCorrectly()
        {
            // Arrange
            var name = "Lisa";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Action<string> BePolite = new(Utilities.Greet);
            BePolite(name);
            var output = stringWriter.ToString().Trim();

            // Assert
            var expected = "Hey, Lisa!";
            Assert.Equal(expected, output);
        }

        [Fact]
        public void WhenAnonymousMethodInitiation_ThenDelegateIsCreatedCorrectly()
        {
            // Arrange
            var name = "Lisa";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Action<string> BePolite = delegate(string name) 
            {
                Console.WriteLine($"Hey, {name}!");
            };

            BePolite(name);
            var output = stringWriter.ToString().Trim();

            // Assert
            var expected = "Hey, Lisa!";
            Assert.Equal(expected, output);
        }

        [Fact]
        public void WhenLambdaExpressionInitiation_ThenDelegateIsCreatedCorrectly()
        {
            // Arrange
            var name = "Lisa";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Action<string> BePolite = (string name) => Console.WriteLine($"Hey, {name}!");
            BePolite(name);
            var output = stringWriter.ToString().Trim();

            // Assert
            var expected = "Hey, Lisa!";
            Assert.Equal(expected, output);
        }

        // Delegates as arguments
        

        [Fact]
        public void GivenGenerateGreetingMethod_WhenMethodAndStringArePassedAsArguments_ThenMethodIsCalledWithString()
        {
            // Arrange
            var name = "Lisa";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Utilities.GenerateGreeting(Utilities.Greet, name);
            var output = stringWriter.ToString().Trim();

            // Assert
            var expected = "Hey, Lisa!";
            Assert.Equal(expected, output);
        }

        [Fact]
        public void GivenGenerateDescriptionMethod_WhenMethodAndArgumentsArePassed_ThenMethodIsCalledWithArguments()
        {
            // Arrange
            var name = "Luke";
            var adjective = "honest";
            var hasFeature = true;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Utilities.GenerateDescription(Utilities.DescribePerson, name, adjective, hasFeature);
            var output = stringWriter.ToString().Trim();

            // Assert
            var expected = "What can I say about Luke? Well, Luke is rather honest.";
            Assert.Equal(expected, output);
        }


        [Fact]
        public void GivenUseFuncAsArgumentMethod_WhenMethodIsCalled_ThenGenerateDescriptionMethodIsCalledTwice()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Utilities.UseFuncAsArgument();
            var outputLines = stringWriter
                .ToString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Assert
            var expected = 2;
            Assert.Equal(expected, outputLines.Length);
        }


        [Fact]
        public void GivenUseDynamicMethodAssignment_WhenDIsEntered_ThenInformationAboutPersonIsDisplayed()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var stringReader = new StringReader("D");
            Console.SetIn(stringReader);

            // Act
            Utilities.UseDynamicMethodAssignment();
            var outputLines = stringWriter
                .ToString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Assert            
            var expected = outputLines[^1].Trim() == "Danny is not very popular."
                && outputLines[^2].Trim() == "Danny is rather mysterious.";
            Assert.True(expected);
        }

        [Fact]
        public void GivenUseDynamicMethodAssignment_WhenBIsEntered_ThenInformationAboutBookIsDisplayed()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var stringReader = new StringReader("B");
            Console.SetIn(stringReader);

            // Act
            Utilities.UseDynamicMethodAssignment();
            var outputLines = stringWriter
                .ToString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Assert          
            var expected = outputLines[^2].Trim() == "Danny's latest book is quite mysterious and pretty good."
                && outputLines[^1].Trim() == "Danny's latest book is quite popular but not to my taste.";
            Assert.True(expected);
        }
    }
}