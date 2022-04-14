using ActionAndFuncDelegates;
using System;
using Xunit;

namespace ActionAndFuncDelegatesTest
{
    public class Test
    {
        MyClass sut;
        public Test()
        {
            sut = new MyClass();
        }

        [Fact]
        public void WhenDelegateIsAssigned_ThenDelegateExecutesReferencedMethod()
        {
            MyFirstDelegate del = sut.MethodOne;
            var result = sut.MethodOne("Hey");

            Assert.Equal(del("Hey"), result);
        }

        [Fact]
        public void WhenDelegateIsPassedAsParameter_ThenDelegateExecutesReferencedMethod()
        {
            MyFirstDelegate del = sut.MethodOne;
            var result = sut.MethodWithDelegateParam(del);

            Assert.Equal(del("Hi There"), result);
        }

        [Fact]
        public void WhenFuncDelegateIsAssigned_ThenDelegateExecutesReferencedMethod()
        {
            Func<string, string, string> FuncDelegate = sut.MethodTwo;
            var result = sut.MethodTwo("james", "jones");

            Assert.Equal(FuncDelegate("james", "jones"), result);
        }

        [Fact]
        public void WhenFuncDelegateIsAssignedToAnonymousMethod_ThenDelegateExecutesTheAnonymousdMethod()
        {
            Func<string, string, string> FuncDelegate = delegate (string firstName, string lastName)
            {
                return $"{firstName} {lastName}";
            };
            var result = FuncDelegate("One", "Two");

            Assert.Equal("One Two", result);
        }

        [Fact]
        public void WhenFuncDelegateIsAssignedToLambdaExpression_ThenDelegateExecutesTheLambdaExpression()
        {
            Func<string, string, string> FuncDelegate = (string firstName, string lastName) =>
            {
                return $"{firstName} {lastName}";
            };
            var result = FuncDelegate("One", "Two");

            Assert.Equal("One Two", result);
        }


        [Fact]
        public void WhenActionDelegateIsAssigned_ThenDelegateExecutesReferencedMethod()
        {
            Action<string, string> actionDelegate = sut.MethodThree;
            actionDelegate("john", "doe");

            Assert.Equal("john doe", MyClass.name);
        }

        [Fact]
        public void WhenActionDelegateIsAssignedToAnonymousMethod_ThenDelegateExecutesTheAnonymousdMethod()
        {
            Action<string, string> actionDelegate = delegate (string firstName, string lastName)
            {
                MyClass.name = $"{firstName} {lastName}";
            };
            actionDelegate("James", "Drinkwater");

            Assert.Equal("James Drinkwater", MyClass.name);
        }

        [Fact]
        public void WhenActionDelegateIsAssignedToLambdaExpression_ThenDelegateExecutesTheLambdaExpression()
        {
            Action<string, string> actionDelegate = (string firstName, string lastName) =>
            {
                MyClass.name = $"{firstName} {lastName}";
            };
            actionDelegate("Jamees", "Drinkwater");

            Assert.Equal("Jamees Drinkwater", MyClass.name);
        }
    }
}