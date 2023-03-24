namespace GetClassNameAsString;

public class ChildClass : BaseClass
{
    public override string GetNameByGetCurrentMethod()
    {
        var name = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
        return name;
    }
}