public partial class FuncDelegateInCSharp
{
    private readonly NameValidator nameValidator;
    public FuncDelegateInCSharp()
    {
        nameValidator = new();
    }

    public void ExecuteWithoutParameter()
    {
        Func<bool> validationMethod = nameValidator.IsNameValid; 
        Console.WriteLine(validationMethod());
    }

    public void ExecuteWithParameter()
    {
        Func<string, bool> validationFromParameterMethod = nameValidator.IsNameValid;
        Console.WriteLine(validationFromParameterMethod("Code Maze from Parameter should return false"));
    }

}