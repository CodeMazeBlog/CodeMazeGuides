using Xunit;
using Shouldly;
using ActionAndFuncDelegateInCSharp.Model;
using ActionAndFuncDelegateInCSharp.Examples;

namespace Tests
{
    public class CovarianceExampleTests
    {
        [Fact]
        public void WhenFuncDelegateIsAssignedToAnotherFuncDelegate_TheTargetDelegateShouldChangeAccordingly()
        {
            var covarianceExample = new CovarianceExamples();

            covarianceExample.Assign();

            covarianceExample.FuncWithControl.ShouldBeOfType<FuncDelegate<Button>>();

            covarianceExample.FuncWithControl().ShouldBeOfType<Button>();
        }
    }
}