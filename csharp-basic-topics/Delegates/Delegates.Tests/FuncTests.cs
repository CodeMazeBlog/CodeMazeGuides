namespace Delegates.Tests
{
    public class FuncTests
    {
        [Fact]
        public void Add()
        {
            MyFuncDelegate func = new MyFuncDelegate();
            int result = func.PerformFunction(10,10, MyFuncDelegate.OperationType.Add);
            Assert.Equal(20, result);
        }

        [Fact]
        public void Subtract()
        {
            MyFuncDelegate func = new MyFuncDelegate();
            int result = func.PerformFunction(10, 5, MyFuncDelegate.OperationType.Subtract);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Multiply()
        {
            MyFuncDelegate func = new MyFuncDelegate();
            int result = func.PerformFunction(10, 10, MyFuncDelegate.OperationType.Multiply);
            Assert.Equal(100, result);
        }

        [Fact]
        public void Divide()
        {
            MyFuncDelegate func = new MyFuncDelegate();
            int result = func.PerformFunction(10, 10, MyFuncDelegate.OperationType.Divide);
            Assert.Equal(1, result);
        }
    }
}