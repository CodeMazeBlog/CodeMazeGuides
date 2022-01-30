namespace ConstantVSStaticVSReadonly.StaticReadOnly;

public class StaticReadonlyVariable
{
    public static readonly string firstVariable = "First static readonly variable";
    public static readonly string secondVariable;

    static StaticReadonlyVariable()
    {
        secondVariable = "Second static readonly varaible";
    }
    
}

public class StaticReadonlyVariableException
{
    public static readonly string newariable;

    /*public StaticReadonlyVariable()
    {
        secondVariable = "Second static readonly varaible";
    }*/
}
