namespace ConstantVSStaticVSReadonly.Readonly;

public class ReadonlyVaraible
{
    //first example
    public readonly string newVariable = "Readonly variable";
    
    //second example
    public readonly string myVariable;

    public ReadonlyVaraible()
    {
        myVariable = "Readonly variable";
    }
}

public class ReadOnlyVariableException
{
    public readonly string newVaraible = "Readonly varaible";
    
    //this will throw the exception 
    public void ChangeValue()
    {
        //myVariable = "New Readonly variable";
    }
}