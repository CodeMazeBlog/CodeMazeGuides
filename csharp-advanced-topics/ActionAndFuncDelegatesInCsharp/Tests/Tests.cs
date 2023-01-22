namespace Tests;

public class Tests

{
    private static string _fullName = string.Empty;

    private static string BuildFullName(string firstName, string lastName)
    {
        return $"{firstName} {lastName}";
    }

    private static void PrintFullName(string firstName, string lastName)
    {
        Console.WriteLine($"Triggered by Action delegate {firstName} {lastName}");
        _fullName = $"{firstName} {lastName}";
    }

    [Fact]
    public void ConcatName_WhenActionDelegate_ShouldConcatNameAndDelegateInvocationListNotEmpty()
    {
        var actionDelegate = PrintFullName;  
        actionDelegate("John", "Doe");
        var invocationList = actionDelegate.GetInvocationList();
        Assert.Equal("John Doe", _fullName);
        Assert.Single(invocationList);
    }
    
    [Fact]
    public void FullName_WhenFuncDelegate_ShouldReturnFullNameAndDelegateInvocationListNotEmpty()
    {
        var funcDelegate = BuildFullName;
        var result = funcDelegate("John", "Doe");
        var invocationList = funcDelegate.GetInvocationList();
        Assert.Equal("John Doe", result);
        Assert.Single(invocationList);
    }
}
