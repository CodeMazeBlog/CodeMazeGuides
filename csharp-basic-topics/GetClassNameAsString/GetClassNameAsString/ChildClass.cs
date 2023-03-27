namespace GetClassNameAsString;

public class ChildClass : BaseClass
{
    public override string GetNameByGetCurrentMethod()
    {
        return MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
    }
}