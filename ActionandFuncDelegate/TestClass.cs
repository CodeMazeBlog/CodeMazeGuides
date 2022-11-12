using Xunit;




public class TestClass
{
    [Fact]
    public void PassSumTest()
    {
        Assert.Equal(4,FuncDelegate.sum(2,2));
    }
    [Fact]
    public void FailSumTest()
    {
        Assert.NotEqual(5,FuncDelegate.sum(2,2));
    }
    [Fact]
    public void PassdispSumTest()
    {
        string text="Hello";
        Assert.Equal(text,FuncDelegate.displaySum(4,2));
    }
    
    
  

}