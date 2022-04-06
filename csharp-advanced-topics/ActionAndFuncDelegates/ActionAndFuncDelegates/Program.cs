using System;

namespace ActionAndFuncDelegates 
{
    public delegate string MyFirstDelegate(string str);
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            //3 Instantiate the delegate
            MyFirstDelegate firstDelegate = myClass.MethodOne;
            //4 Invoke the delegate
            var result = firstDelegate("Hello World");

            // This method is called and firstDelegate which is an object of MyFirstDelegate goes in as the parameter
            result = myClass.MethodWithDelegateParam(firstDelegate);

            // this generic delegate has two input parameters and one output parameter
            Func<string, string, string> fullNameFuncDelegate;

            // The delegate can reference MethodeTwo because MethodeTwo has the same signature
            fullNameFuncDelegate = myClass.MethodeTwo;
            result = fullNameFuncDelegate("James", "Drinkwater");

            //Func delegate with anonymous method
            fullNameFuncDelegate = delegate (string firstName, string lastName)
            {
                return firstName + " " + lastName;
            };
            result = fullNameFuncDelegate("James", "Drinkwater2");

            //func delegate with lambda expression
            fullNameFuncDelegate = (string firstName, string lastName) =>
            {
                return firstName + " " + lastName;
            };
            result = fullNameFuncDelegate("James", "Drinkwater");


            // this generic delegate has two input paramters and one putput paramter
            Action<string, string> fullNameActionDelegate;

            // The delegate can reference MethodThree becase MethodThree has the same signature
            fullNameActionDelegate = myClass.MethodThree;
            fullNameActionDelegate("James", "Drinkwater");

            //Action delegate with anonymous method
            fullNameActionDelegate = delegate (string firstName, string lastName)
            {
                MyClass.name = firstName + " " + lastName;
            };
            fullNameActionDelegate("James", "Drinkwater");

            //Action delegate with lambda expression
            fullNameActionDelegate = (string firstName, string lastName) =>
            {
                MyClass.name = firstName + " " + lastName;
            };
            fullNameActionDelegate("James", "Drinkwater");
        }
    }

    public class MyClass
    {
        //2 Define the target method
        public string MethodOne(string message)
        {
            return "The message is: " + message;
        }

        // MyFirstDelegate is passed as a parameter to this method
        public string MethodWithDelegateParam(MyFirstDelegate delParam)
        {
            var result = delParam("Hi There");
            return result;
        }

        public string MethodeTwo(string firstName, string lastName)
        {
            var fullName = firstName + " " + lastName;
            return fullName;
        }

        public static string name;
        public void MethodThree(string firstName, string lastName)
        {
            name = firstName + " " + lastName;
        }
    }
}
