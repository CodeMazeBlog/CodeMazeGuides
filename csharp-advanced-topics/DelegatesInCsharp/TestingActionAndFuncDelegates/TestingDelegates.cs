using System;
using System.Linq;
using Xunit;

namespace TestingActionAndFuncDelegates
{
    public class TestingDelegates
    {

        [Fact]
        public void TestingActionDelegateInvokesTheMethodUsingLambdaExpression()
        {
            //Testing Action delegate invokes the method using Lambda expression properly  
            Action<string> printActionDelegate = input => Console.WriteLine(input);
            printActionDelegate("Lambda expression way of Action delegate");
            var invocation = printActionDelegate.GetInvocationList();
            Assert.Single(invocation);
        }

        [Fact]
        public void TestingActionDelegateInvokesUsingDirectMethodAssign()
        {
            //Testing Action delegate invokes the method which assigned directly  
            Action<string> printActionDelegate2 = Print;
            printActionDelegate2("Print this!");
            var invocation2 = printActionDelegate2.GetInvocationList();
            Assert.Single(invocation2);
        }

        [Fact]
        public void TestingActionDelegateInitializedUsingNewKeyword()
        {
            //Testing Action delegate Initialized using the new keyword
            Action<string> printActionDelegate3 = new Action<string>(Print);
            printActionDelegate3.Invoke("Invoke action delegate");
            var invocation3 = printActionDelegate3.GetInvocationList();
            Assert.Single(invocation3);
        }

        [Fact]
        public void TestFuncDelegateReturnConcatenatedStringConvertedToCapital()
        {
            //Testing getFullName Func delegate which accepts 2 strings and return concatenated string converted to caps-lock 
            Func<string, string, string> getFullName = FullNameInCapital;
            string fullNameInCaps = getFullName("john", "doe");
            Assert.Equal("JOHN DOE",fullNameInCaps );
        }

        [Fact]
        public void TestingFuncDelegateReturnsAnObjectFromAListOfObjectsBasedOnACondition()
        {
            //From the array of users, we are going to filter who are living in USA.
            User[] users =
            {
                new(1, "Peter", "UK"), 
                new(2, "John", "USA"), 
                new(3, "Mark", "KSA"), 
                new(4, "Pal", "UAE"),
            };

            var country = "USA";
            Func<User, bool> livesIn = e => e.Country == country;
            //Iterate through user list and return the user object of whose country attribute is equal to the 'country' variable.
            var result = users.Where(livesIn);

            foreach (var user in result)
            {
                Assert.Equal(2,user.Id);
                Assert.Equal("John", user.Name);
            }
        }

        private record User(int Id, string Name, string Country);

        static string FullNameInCapital(string firstName, string lastName)
        {
            return (firstName+ " " + lastName).ToUpper();
        }

        static void Print(string input)
        {
            Console.WriteLine(input);
        }

    }
}