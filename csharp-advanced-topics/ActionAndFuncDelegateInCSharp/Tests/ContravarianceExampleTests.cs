using Xunit;
using Shouldly;
using ActionAndFuncDelegateInCSharp.Model;

namespace Tests
{
    public delegate void ActionDelegate<in T>(T obj);

    public class ContravarianceExampleTests
    {
        [Fact]
        public void WhenActionDelegateIsAssignedByContravarianceRelation_TheTargetDelegateShouldChangeAccordingly()
        {
            ActionDelegate<Button> clickOnButton = button => button.Click();

            ActionDelegate<Control> operateOnControl = control => control.Operate();

            clickOnButton.ShouldBeOfType<ActionDelegate<Button>>();

            var button = new Button();

            button.OperateCount.ShouldBe(0);
            button.ClickCount.ShouldBe(0);

            clickOnButton = operateOnControl;

            clickOnButton.ShouldBeOfType<ActionDelegate<Control>>();

            clickOnButton(button);

            button.OperateCount.ShouldBe(1);
            button.ClickCount.ShouldBe(0);
        }
    }
}