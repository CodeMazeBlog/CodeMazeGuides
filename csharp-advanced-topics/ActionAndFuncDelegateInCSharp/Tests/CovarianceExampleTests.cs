using Xunit;
using Shouldly;
using ActionAndFuncDelegateInCSharp.Model;

namespace Tests
{
    public delegate TResult FuncDelegate<out TResult>();

    public class CovarianceExampleTests
    {
        [Fact]
        public void WhenFuncDelegateIsAssignedToAnotherFuncDelegate_TheTargetDelegateShouldChangeAccordingly()
        {
            FuncDelegate<Button> funcWithButton = () => new Button();
            FuncDelegate<Control> funcWithControl = () => new Control();

            funcWithControl = funcWithButton;

            funcWithControl.ShouldBeOfType<FuncDelegate<Button>>();

            funcWithControl().ShouldBeOfType<Button>();
        }
    }
}