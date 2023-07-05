public partial class FuncDelegateInCSharp
{
    public void ExecuteWithoutParameterUsingAnonymousMethod()
    {
        Func<bool> validationMethodUsingAnonymousMethod 
                =  delegate(){return nameValidator.IsNameValid();} ;  
        Console.WriteLine(validationMethodUsingAnonymousMethod());
    }

    public void ExecuteWithParameterUsingAnonymousMethod()
    {
       Func<string, bool> validationFromParameterMethodUsingAnonymousMethod 
            = delegate(string name){return nameValidator.IsNameValid(name);} ;
        Console.WriteLine(validationFromParameterMethodUsingAnonymousMethod("Code Maze from Parameter should return false"));
    }

}