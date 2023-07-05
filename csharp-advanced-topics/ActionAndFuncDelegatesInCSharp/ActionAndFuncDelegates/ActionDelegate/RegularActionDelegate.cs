public partial  class ActionDelegateInCSharp
{
    private readonly NameDisplay nameDisplay;
    public ActionDelegateInCSharp()
    {
        nameDisplay = new();
    }

    public void ExecuteWithoutParameter()
    {
        Action showMethod = nameDisplay.DisplayValue; 
        showMethod();
    }

    public void ExecuteWithParameter()
    {
        Action<string> showMethodWithParameter = nameDisplay.DisplayValue;
        showMethodWithParameter("Code Maze from Parameters");
    }
   
}