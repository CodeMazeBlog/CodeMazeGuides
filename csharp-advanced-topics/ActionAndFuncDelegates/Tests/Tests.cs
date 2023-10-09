using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private static readonly List<string> _names = new() {
            "Paul",
            "Aaron",
            "Amy",
            "World"
        };

        [TestMethod]
        public void whenTrueIsSent_FuncDelegateReturnsGoodbyeMesssage()
        {
            Func<bool, string, string> funcMsg = IsThisGoodBye;
            string result = funcMsg(true, "Paul");
            Assert.AreEqual("Goodbye, Paul", result);
        }

        [TestMethod]
        public void whenFalseIsSent_FuncDelegateReturnsHelloMesssage()
        {
            Func<bool, string, string> funcMsg = IsThisGoodBye;
            string result = funcMsg(false, "Aaron");
            Assert.AreEqual("Hello, Aaron", result);
        }

        [TestMethod]
        public void givenListOfNames_WhenTrueIsSent_FuncDelegateLambdaReturnsCountOfItemsStaringWithPrefix()
        {
            string prefix = "A";
            int result = CountOfNamesContaining(prefix, true);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void givenListOfNames_WhenFalseIsSent_FuncDelegateLambdaReturnsCountOfItemsEndingWithSuffix()
        {
            string sufffix = "d";
            int result = CountOfNamesContaining(sufffix, false);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void when5IsSent_AnonymousFuncDelegateReturnsTrue()
        {
            bool result = AnonymousLessThanTen(5);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void when15IsSent_AnonymousFuncDelegateReturnsFalse()
        {
            bool result = AnonymousLessThanTen(15);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void when5IsSent_LambdaFuncDelegateReturnsTrue()
        {
            bool result = LambdaLessThanTen(5);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void when15IsSent_LambdaFuncDelegateReturnsFalse()
        {
            bool result = LambdaLessThanTen(15);
            Assert.AreEqual(false, result);
        }

        private static bool AnonymousLessThanTen(int number) { return (number < 10); }

        private static readonly Func<int, bool> LambdaLessThanTen = (i) => { return i < 10; };

        private static string IsThisGoodBye(bool goodbye, string name)
        {
            if (goodbye)
                return $"Goodbye, {name}";
            else
                return $"Hello, {name}";
        }

        private static int CountOfNamesContaining(string searchString, bool searchFromBeginning)
        {
            // use a lambda to filter names from the list
            Func<string, string, bool> compare;

            if (searchFromBeginning)
                compare = NameStartsWith;
            else
                compare = NameEndsWith;

            return _names.Count(n => compare(n, searchString));
        }

        private static bool NameStartsWith(string name, string beginsWith)
        {
            return (name.StartsWith(beginsWith));
        }
        
        private static bool NameEndsWith(string name, string endsWith)
        {
            return (name.EndsWith(endsWith));
        }
    }
}