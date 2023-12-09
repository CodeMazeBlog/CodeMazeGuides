using ActionFuncDelegates;

namespace Tests;

public class FuncUnitTest
{
    [Fact]
    public void WhenFuncRunDemo_ThenNameUpdated()
    {
        var employee = new Employee { Id = 7, Name = "Jane Doe" };
        
        FuncDemo.RunDemo(employee);
        
        Assert.Equal("Jane Doe Updated", employee.Name);
    }
}