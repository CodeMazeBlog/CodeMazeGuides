using Delegates;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void GivenDelegate_WhenStringProvided_ThenReturnsReversedString()
        {
            // Arrange
            var str = "Hello World!";
            ModifyData<string> modifyData = Program.Reverse;

            // Act
            var result = Program.ReverseUsingDelegate(modifyData, str);

            // Assert
            Assert.Equal(Program.Reverse("Hello World!"), result);
        }

        [Fact]
        public void GivenMulticastDelegate_WhenStringProvided_ThenReturnsModifiedStringByLastReferencedMethod()
        {
            // Arrange
            var str = "Hello World!";
            ModifyData<string> modifyData = Program.Reverse;
            modifyData += Program.LowerString;

            // Act
            var result = Program.UseMulticastDelegate(modifyData, str);

            // Assert
            Assert.Equal(Program.LowerString("Hello World!"), result);
        }

        [Fact]
        public void GivenMulticastDelegate_WhenTwoMethodsReferenced_ThenReturnsTwoMethodNames()
        {
            // Arrange
            ModifyData<string> modifyString = Program.LowerString;
            modifyString += Program.Reverse;

            // Act
            var result = Program.GetInvocationListFromMulticastDelegate(modifyString);

            // Assert
            Assert.Equal("LowerString Reverse", result);
        }

        [Fact]
        public void GivenMulticastFunc_WhenStringProvided_ThenReturnsModifiedStringByLastReferencedMethod()
        {
            // Arrange
            var str = "Hello World!";
            Func<string, string> modifyFunc = Program.Reverse;
            modifyFunc += Program.LowerString;

            // Act
            var result = Program.UseMulticastFunc(modifyFunc, str);

            // Assert
            Assert.Equal(Program.LowerString("Hello World!"), result);
        }

        [Fact]
        public void GivenAction_WhenStringProvided_ThenGetsModifiedStringByReferencedMethod()
        {
            // Arrange
            var str = "Hello World!";
            Action<string> modifyAction = Program.UpperString;

            // Act
            var result = Program.UseAction(modifyAction, str);

            // Assert
            Assert.Equal(str.ToUpperInvariant(), result);
        }

        [Fact]
        public void GivenPredicate_WhenNotCapitalizedStringProvided_ThenReturnsFalse()
        {
            // Arrange
            var str = "Hello World!";
            Predicate<string> checkString = Program.IsUpperString;

            // Act
            var result = Program.UsePredicate(checkString, str);

            // Assert
            Assert.False(result);
        }
    }
}