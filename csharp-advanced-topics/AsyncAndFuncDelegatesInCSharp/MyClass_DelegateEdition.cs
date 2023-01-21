// Traditional delegate definitions.
public delegate double RandomValueFunc();
public delegate string DefaultPasswordFunc();
// We may now use the delegates above, or we could have used Func all along:
public class MyClass_DelegateEdition
{
    private RandomValueFunc _rndValFn;
    private DefaultPasswordFunc _defPwdFn;
    public MyClass_DelegateEdition(RandomValueFunc rndValFn, DefaultPasswordFunc defPwdFn)
    {
        _rndValFn = rndValFn;
        _defPwdFn = defPwdFn;
    }
}