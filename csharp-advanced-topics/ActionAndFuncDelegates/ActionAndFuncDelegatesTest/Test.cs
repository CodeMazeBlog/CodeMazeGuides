using ActionAndFuncDelegates;
using System;
using Xunit;

namespace ActionAndFuncDelegatesTest
{
    public class Test
    {
        MyClass sut;
        static string hh = "musa";

        public Test()
        {
            sut = new MyClass();
        }

        [Fact]
        public void WhenDelegateIsAssigned_DelegateExecutesReferencedMethod()
        {
            MyFirstDelegate del = sut.MethodOne;
            var result = sut.MethodOne("Hey");
            Assert.Equal(del("Hey"), result);
        }

        [Fact]
        public void WhenDelegateIsPassedAsParameter_DelegateExecutesReferencedMethod()
        {
            MyFirstDelegate del = sut.MethodOne;
            var result = sut.MethodWithDelegateParam(del);
            Assert.Equal(del("Hi There"), result);
        }

        [Fact]
        public void WhenFuncDelegateIsAssigned_DelegateExecutesReferencedMethod()
        {
            Func<string, string, string> FuncDelegate = sut.MethodeTwo;
            var result = sut.MethodeTwo("james", "jones");
            Assert.Equal(FuncDelegate("james", "jones"), result);
        }

        [Fact]
        public void WhenFuncDelegateIsAssignedToAnonymousMethod_DelegateExecutesTheAnonymousdMethod()
        {
            Func<string, string, string> FuncDelegate = delegate (string firstName, string lastName)
            {
                return firstName + " " + lastName;
            };
            var result = FuncDelegate("One", "Two");
            Assert.Equal("One Two", result);
        }

        [Fact]
        public void WhenFuncDelegateIsAssignedToLambdaExpression_DelegateExecutesTheLambdaExpression()
        {
            Func<string, string, string> FuncDelegate = (string firstName, string lastName) =>
            {
                return firstName + " " + lastName;
            };
            var result = FuncDelegate("One", "Two");
            Assert.Equal("One Two", result);
        }


        [Fact]
        public void WhenActionDelegateIsAssigned_DelegateExecutesReferencedMethod()
        {
            Action<string, string> actionDelegate = sut.MethodThree;
            actionDelegate("john", "doe");
            Assert.Equal("john doe", MyClass.name);
        }

        [Fact]
        public void WhenActionDelegateIsAssignedToAnonymousMethod_DelegateExecutesTheAnonymousdMethod()
        {
            Action<string, string> actionDelegate = delegate (string name, string lastName)
            {
                MyClass.name = name + " " + lastName;
            };
            actionDelegate("James Drinkwater", MyClass.name);
        }

        [Fact]
        public void WhenActionDelegateIsAssignedToLambdaExpression_DelegateExecutesTheLambdaExpression()
        {
            Action<string, string> actionDelegate = (string name, string lastName) =>
            {
                MyClass.name = name + " " + lastName;
            };
            actionDelegate("James Drinkwater", MyClass.name);
        }
    }
}