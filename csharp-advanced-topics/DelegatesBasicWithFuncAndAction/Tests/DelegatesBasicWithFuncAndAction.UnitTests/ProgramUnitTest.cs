using DelegateBasicsWithFuncAndAction;
using Moq;
using Xunit;

namespace DelegatesBasicWithFuncAndAction.UnitTests
{
    public class ProgramUnitTest
    {
        readonly Mock<Program.PrivateMethodDelegate> privateMethodDelegateMock;
        readonly Mock<Program.PrivateMethodWithParameterDelegate> privateMethodWithParameterDelegateMock;
        readonly Mock<Func<string, string>> funcMethodMock;
        readonly Mock<Action<string>> actionMethodMock;

        public ProgramUnitTest()
        {
            privateMethodDelegateMock = new Mock<Program.PrivateMethodDelegate>();
            privateMethodWithParameterDelegateMock = new Mock<Program.PrivateMethodWithParameterDelegate>();
            funcMethodMock = new Mock<Func<string, string>>();
            actionMethodMock = new Mock<Action<string>>();
        }


        [Fact]
        public void WhenExecuteDelegateOfDelegateWithoutParameterIsCall_ThenStringWriteOnConsole()
        {
            privateMethodDelegateMock.Setup(s => s()).Callback(() => Console.WriteLine("Calling Private Methods"));
            DelegateWithoutParameter.ExecuteDelegate(privateMethodDelegateMock.Object);
            Assert.NotNull(privateMethodDelegateMock);
        }
        
        [Fact]
        public void WhenExecuteDelegateOfDelegateWithParameterIsCall_ThenStringWriteOnConsole()
        {
            privateMethodWithParameterDelegateMock.Setup(s => s(It.IsAny<string>()))
                .Callback(() => Console.WriteLine("Calling Private Methods"));
            DelegateWithParameter.ExecuteDelegate(privateMethodWithParameterDelegateMock.Object);
            Assert.NotNull(privateMethodWithParameterDelegateMock);
        }
        
        [Fact]
        public void WhenFuncMethodOfFuncDelegateIsCall_ThenStringWriteOnConsole()
        {
            FuncDelegate.FuncMethod();
            Assert.NotNull(funcMethodMock);
        }
        
        [Fact]
        public void WhenActionMethodOfActionDelegateIsCall_ThenStringWriteOnConsole()
        {
            ActionDelegate.ActionMethod();
            Assert.NotNull(actionMethodMock);
        }
    }
}