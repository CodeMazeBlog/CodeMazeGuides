using ActionandFuncDelegatesinCSharp;

namespace ActionandFuncDelegatesinCSharp_Test
{
    public class ActionandFuncDelegatesinCSharpTests
    {
        [Fact]
        public void TestAddActionDelegate()
        {
            var funcDelegatesinCSharpCode = new ActionandFuncDelegatesinCSharpCode();
            funcDelegatesinCSharpCode.add(3, 5);
        }

        [Fact]
        public void TestPrintMyNameActionDelegate()
        {
            var funcDelegatesinCSharpCode = new ActionandFuncDelegatesinCSharpCode();
            funcDelegatesinCSharpCode.printMyName();
        }

        [Fact]
        public void TestSquareFuncDelegate()
        {
            var funcDelegatesinCSharpCode = new ActionandFuncDelegatesinCSharpCode();
            var result = funcDelegatesinCSharpCode.square(4);
            Assert.Equal(16, result);
        }

        [Fact]
        public void TestMultiplyFuncDelegate()
        {
            var funcDelegatesinCSharpCode = new ActionandFuncDelegatesinCSharpCode();
            var result = funcDelegatesinCSharpCode.multiply(3, 5);
            Assert.Equal(15, result);
        }

        [Fact]
        public void TestPrintArrayActionDelegate()
        {
            var funcDelegatesinCSharpCode = new ActionandFuncDelegatesinCSharpCode();
            funcDelegatesinCSharpCode.printArray(new[] { 1, 2, 3 });
        }

        [Fact]
        public void TestMaxNumberFuncDelegate()
        {
            var funcDelegatesinCSharpCode = new ActionandFuncDelegatesinCSharpCode();
            var result = funcDelegatesinCSharpCode.maxNumber(new[] { 5, 10, 3, 8 });
            Assert.Equal(10, result);
        }

        [Fact]
        public void TestLogMessageActionDelegate()
        {
            var funcDelegatesinCSharpCode = new ActionandFuncDelegatesinCSharpCode();
            funcDelegatesinCSharpCode.logMessage("Testing logging");
        }

        [Fact]
        public void TestIsEvenFuncDelegate()
        {
            var funcDelegatesinCSharpCode = new ActionandFuncDelegatesinCSharpCode();
            var result = funcDelegatesinCSharpCode.isEven(6);
            Assert.True(result);
        }

        [Fact]
        public void TestArithmeticOperationActionDelegate()
        {
            var funcDelegatesinCSharpCode = new ActionandFuncDelegatesinCSharpCode();
            funcDelegatesinCSharpCode.arithmeticOperation(10, 2);
        }

        [Fact]
        public void TestConcatenateFuncDelegate()
        {
            var funcDelegatesinCSharpCode = new ActionandFuncDelegatesinCSharpCode();
            var result = funcDelegatesinCSharpCode.concatenate("Hello, ", "World!");
            Assert.Equal("Hello, World!", result);
        }
    }
}