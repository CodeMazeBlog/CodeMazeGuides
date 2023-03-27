namespace GetClassNameAsString;

public class BaseClass
{
    private int _myPropertyInt;
    public string MyPropertyString = nameof(BaseClass);

    public int MyPropertyInt {
        get 
        {
            var name = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            Console.WriteLine($"BaseClass GetCurrentMethod in the property getter result: {name}");

            name = this.GetType().Name;
            Console.WriteLine($"BaseClass GetType in the property getter result: {name}");
            
            return _myPropertyInt;
        }
        set 
        {
            var name = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            Console.WriteLine($"BaseClass GetCurrentMethod in the property setter result: {name}");

            name = this.GetType().Name;
            Console.WriteLine($"BaseClass GetType in the property setter result: {name}");
            
            _myPropertyInt = value; 
        }
    }
    public virtual string GetNameByGetCurrentMethod()
    {
        return MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
    }

    public virtual string GetNameByGetType()
    {
        return this.GetType().Name;
    }

    public static string StaticGetNameByGetCurrentMethod()
    {
        return MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
    }
}