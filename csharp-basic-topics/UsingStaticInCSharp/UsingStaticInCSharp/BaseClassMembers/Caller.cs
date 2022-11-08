using static UsingStaticInCSharp.BaseClassMembers.ClassB;

namespace UsingStaticInCSharp.BaseClassMembers;
public class Caller
{
    public virtual void Invoke()
    {
        MethodB();
    }
}
