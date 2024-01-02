namespace Tests
{
    delegate T ModifyData<T>(T str);

    public class Tests
    {
        static string upperStr = string.Empty;

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
            upperStr = myString.ToUpperInvariant();
        }

        [Fact]
        public void WhenStringProvided_DelegateReturnsTheReversedString()
        {
            ModifyData<string> modifyString = Reverse;
            var result = modifyString("Welcome to Code Maze!");
            Assert.Equal(Reverse("Welcome to Code Maze!"), result);
        }

        [Fact]
        public void givenMulticastDelegate_whenTwoReferencedMethods_GetInvocationListContainsTwoMethods()
        {
            ModifyData<string> modifyString = Reverse;
            modifyString += LowerString;
            var delegates = modifyString.GetInvocationList();
            Assert.Equal(2, delegates.Length);
            Assert.Equal("Reverse", delegates[0].Method.Name);
            Assert.Equal("LowerString", delegates[1].Method.Name);
        }

        [Fact]
        public void WhenStringProvided_FuncReturnsTheReversedString()
        {
            Func<string, string> stringFunction = Reverse;
            var result = stringFunction("Welcome to the generic delegates world!");
            Assert.Equal(Reverse("Welcome to the generic delegates world!"), result);
        }

        [Fact]
        public void WhenStringProvided_ActionReturnsUpperString()
        {
            Action<string> modifyCase = UpperString;
            modifyCase("Welcome to the generic delegates world!");
            Assert.Equal("WELCOME TO THE GENERIC DELEGATES WORLD!", upperStr);
        }
    }
}