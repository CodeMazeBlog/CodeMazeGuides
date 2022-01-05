using Xunit;
using Shouldly;
using ActionAndFuncDelegateInCSharp.Model;
using ActionAndFuncDelegateInCSharp.Examples;

namespace Tests
{
    public class ContravarianceExampleTests
    {
        [Fact]
        public void WhenActionDelegateIsAssignedByContravarianceRelation_TheTargetDelegateShouldChangeAccordingly()
        {
            var contravarianceExample = new ContravarianceExamples();

            contravarianceExample.Assign();

            contravarianceExample.ActWithButton.ShouldBeOfType<ActionDelegate<Control>>();

            var button = new Button();

            button.OperateCount.ShouldBe(0);
            button.ClickCount.ShouldBe(0);

            contravarianceExample.ActWithButton(button);

            button.OperateCount.ShouldBe(1);
            button.ClickCount.ShouldBe(0);
        }

        [Fact]
        public void WhenActionDelegateInvokedAsUsual_TheOutputShouldResembleWhatShouldHappenForInvarianceRelation()
        {
            var contravarianceExample = new ContravarianceExamples();

            contravarianceExample.ActWithButton.ShouldBeOfType<ActionDelegate<Button>>();

            var button = new Button();

            button.OperateCount.ShouldBe(0);
            button.ClickCount.ShouldBe(0);

            contravarianceExample.ActWithButton(button);

            button.OperateCount.ShouldBe(0);
            button.ClickCount.ShouldBe(1);
        }
    }
}