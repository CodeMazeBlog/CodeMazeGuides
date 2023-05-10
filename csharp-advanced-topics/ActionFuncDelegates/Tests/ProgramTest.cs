using ActionFuncDelegates;

namespace Tests
{
    public class ProgramTest
    {
        [Fact]
        public void GivenTheFormatStringDelegateIsDeclared_WhenIUseItToDeclareAVariable_ThenICanInvokeIt()
        {
            // Given
            Program.FormatString trim = s => s.Trim();

            // When
            string result = trim(" foo ");

            // Then
            Assert.Equal("foo", result);
        }

        [Fact]
        public void GivenADelegateVariableIsDeclared_WhenIInvokeIt_ThenItRunsSomeCode()
        {
            // Given
            var instance = new Program();
        
            // When
            var result = instance.Format(" bar ");
        
            // Then
            Assert.Equal("bar", result);
        }

        [Fact]
        public void GivenTheDoSomethingMethodAcceptsADelegate_WhenIInvokeItAndPassADelegate_ThenMyDelegateIsInvoked()
        {
            // Given
            var doSomething = Program.DoSomething;

            // When
            var result = doSomething(s => s + " and additional text");
        
            // Then
            Assert.Equal("a string and additional text", result);
        }
    }
}
