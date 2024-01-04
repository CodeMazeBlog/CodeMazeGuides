using Delegates;

namespace Tests
{
    public class Tests
    {
        static string testStr = string.Empty;

        static string Reverse(string myString)
        {
            var characters = myString.ToCharArray();
            Array.Reverse(characters);
            return new string(characters);
        }

        static string LowerString(string myString)
        {
            return myString.ToLowerInvariant();
        }

        static void UpperString(string myString)
        {
            testStr = myString.ToUpperInvariant();
        }

        static bool IsUpperString(string str)
        {
            return str.Equals(str.ToUpperInvariant());
        }

        [Fact]
        public void GivenDelegate_WhenStringProvided_ThenReturnsReversedString()
        {
            // Arrange
            var str = "Hello World!";
            ModifyData<string> modifyData = Reverse;

            // Act
            var result = Program.ReverseUsingDelegate(modifyData, str);

            // Assert
            Assert.Equal(Reverse("Hello World!"), result);
        }

        [Fact]
        public void GivenMulticastDelegate_WhenStringProvided_ThenReturnsModifiedStringByLastReferencedMethod()
        {
            // Arrange
            var str = "Hello World!";
            ModifyData<string> modifyData = Reverse;
            modifyData += LowerString;

            // Act
            var result = Program.UseMulticastDelegate(modifyData, str);

            // Assert
            Assert.Equal(LowerString("Hello World!"), result);
        }

        [Fact]
        public void GivenMulticastDelegate_WhenTwoMethodsReferenced_ThenReturnsTwoMethodNames()
        {
            // Arrange
            ModifyData<string> modifyString = LowerString;
            modifyString += Reverse;

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
            Func<string, string> modifyFunc = Reverse;
            modifyFunc += LowerString;

            // Act
            var result = Program.UseMulticastFunc(modifyFunc, str);

            // Assert
            Assert.Equal(LowerString("Hello World!"), result);
        }

        [Fact]
        public void GivenAction_WhenStringProvided_ThenGetsModifiedStringByReferencedMethod()
        {
            // Arrange
            var str = "Hello World!";
            Action<string> modifyAction = UpperString;

            // Act
            Program.UseAction(modifyAction, str);

            // Assert
            Assert.Equal(str.ToUpperInvariant(), testStr);
        }

        [Fact]
        public void GivenPredicate_WhenNotCapitalizedStringProvided_ThenReturnsFalse()
        {
            // Arrange
            var str = "Hello World!";
            Predicate<string> checkString = IsUpperString;

            // Act
            var result = Program.UsePredicate(checkString, str);

            // Assert
            Assert.False(result);
        }
    }
}