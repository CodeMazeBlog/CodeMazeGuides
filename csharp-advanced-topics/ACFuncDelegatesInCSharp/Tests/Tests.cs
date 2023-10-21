using ACFuncDelegatesInCSharp;
using Xunit;

namespace Tests;

public class Tests
{

    public class MyCustomerFacadeUnitTest
    {
        [Fact]
        public void GivenMyUpdateData_WhenActionDelegate_ThenCallsNotificationCallback()
        {

            var facade = new MyCustomerFacade();
            bool notificationCalled = false;


            facade.MyUpdateData(message => notificationCalled = true);


            Assert.True(notificationCalled);
        }

        [Fact]
        public void GivenMyUpdateData_WhenFuncDelegate_ThenReturnsExpectedString()
        {

            var facade = new MyCustomerFacade();
            string expectedReturnValue = "verifies that the Func delegates have a string return value";


            string result = facade.MyUpdateData(isSuccess => expectedReturnValue);


            Assert.Equal(expectedReturnValue, result);
        }

    }


    public class MyCustomerPresentationUnitTest
    {
        [Fact]
        public void WhenCheckUpdate_ThenCallsActionDelegateAndFuncDelegate()
        {

            var presentation = new MyCustomerPresentation();

            bool actionDelegateCalled = false;

            bool funcDelegateCalled = false;


            var consoleOutput = new System.IO.StringWriter();

            System.Console.SetOut(consoleOutput);


            presentation.CheckUpdate();


            string consoleOutputText = consoleOutput.ToString();


            Assert.Contains("Update data object completed from Action Delegates", consoleOutputText);

            Assert.Contains("Update was successful from Func Delegates", consoleOutputText);
        }
    }


}