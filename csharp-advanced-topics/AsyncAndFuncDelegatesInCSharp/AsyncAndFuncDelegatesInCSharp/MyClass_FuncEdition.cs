public class MyClass_FuncEdition
{
    private Func<double> _rndValFn;
    private Func<string> _defPwdFn;
    public MyClass_FuncEdition(Func<double> rndValFn, Func<string> defPwdFn)
    {
        _rndValFn = rndValFn;
        _defPwdFn = defPwdFn;
    }
}