using System;

namespace ActionAndFuncDelegates 
{
    public delegate string MyFirstDelegate(string str);
    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();

            MyFirstDelegate firstDelegate = myClass.MethodOne;
            var result = firstDelegate("Hello World");

            result = myClass.MethodWithDelegateParam(firstDelegate);

            Func<string, string, string> fullNameFuncDelegate;

            fullNameFuncDelegate = myClass.MethodTwo;
            result = fullNameFuncDelegate("James", "Drinkwater");

            fullNameFuncDelegate = delegate (string firstName, string lastName)
            {
                return $"{firstName} {lastName}";
            };
            result = fullNameFuncDelegate("James", "Drinkwater2");

            fullNameFuncDelegate = (string firstName, string lastName) =>
            {
                return $"{firstName} {lastName}";
            };
            result = fullNameFuncDelegate("James", "Drinkwater");


            Action<string, string> fullNameActionDelegate;

            fullNameActionDelegate = myClass.MethodThree;
            fullNameActionDelegate("James", "Drinkwater");

            fullNameActionDelegate = delegate (string firstName, string lastName)
            {
                MyClass.name = $"{firstName} {lastName}";
            };
            fullNameActionDelegate("James", "Drinkwater");

            fullNameActionDelegate = (string firstName, string lastName) =>
            {
                MyClass.name = $"{firstName} {lastName}";
            };
            fullNameActionDelegate("James", "Drinkwater");
        }
    }
}
