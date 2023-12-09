using ActionFuncDelegates;

namespace Tests;

public class ActionUnitTest
{
    [Fact]
    public void WhenActionRunDemo_ThenNameUpdated()
    {
        var employee = new Employee { Id = 7, Name = "Jane Doe" };
        
        ActionDemo.RunDemo(employee);
        
        Assert.Equal("Jane Doe Updated", employee.Name);
    }
}