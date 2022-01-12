using Shouldly;
using System;
using Xunit;

namespace Tests
{
    public class DelegateExampleTests
    {
        [Fact]
        public void InvestigateBaseTypes_WhenVariableIsAction()
        {
            Action act = () => { };

            act.GetType().ToString().ShouldBe("System.Action");
            act.GetType().BaseType.ToString().ShouldBe("System.MulticastDelegate");
            act.GetType().BaseType.BaseType.ToString().ShouldBe("System.Delegate");
            act.GetType().BaseType.BaseType.BaseType.ToString().ShouldBe("System.Object");
        }

        [Fact]
        public void InvestigateBaseTypes_WhenVariableIsFunc()
        {
            Func<int> act = () => default;

            act.GetType().ToString().ShouldContain("System.Func");
            act.GetType().BaseType.ToString().ShouldBe("System.MulticastDelegate");
            act.GetType().BaseType.BaseType.ToString().ShouldBe("System.Delegate");
            act.GetType().BaseType.BaseType.BaseType.ToString().ShouldBe("System.Object");
        }
    }
}