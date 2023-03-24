namespace GetClassNameAsString;

public class BaseClass
{
    public string MyPropertyString = nameof(BaseClass);
    private int myPropertyInt;

    public int MyPropertyInt {
        get 
        {
            var name = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            Console.WriteLine($"BaseClass GetCurrentMethod in the property getter result: {name}");
            name = this.GetType().Name;
            Console.WriteLine($"BaseClass GetType in the property getter result: {name}");
            return myPropertyInt;
        }
        set 
        {
            var name = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            Console.WriteLine($"BaseClass GetCurrentMethod in the property setter result: {name}");
            name = this.GetType().Name;
            Console.WriteLine($"BaseClass GetType in the property setter result: {name}");
            myPropertyInt = value; 
        }
    }
    public virtual string GetNameByGetCurrentMethod()
    {
        var name = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
        return name;
    }

    public virtual string GetNameByGetType()
    {
        var name = this.GetType().Name;
        return name;
    }

    public static string StaticGetNameByGetCurrentMethod()
    {
        var name = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
        return name;
    }
}