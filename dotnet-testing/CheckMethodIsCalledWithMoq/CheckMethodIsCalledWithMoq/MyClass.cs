namespace CheckMethodIsCalledWithMoq;

public class MyClass
{
    private Dependency _dep;
    private IDependency _idep;

    public MyClass(Dependency dep, IDependency idep)
    {
        _dep = dep;
        _idep = idep;
    }

    public void CallingPublicMethod() 
    {
        PublicMethod();
    }

    public virtual void PublicMethod() {}

    public void CallingProtectedMethod() 
    {
        ProtectedMethod();
    }

    protected virtual void ProtectedMethod() {}

    public void CallingInternalMethod() 
    {
        InternalMethod();
    }

    virtual internal void InternalMethod() {}

    public void CallingDependencyPublicMethod() 
    {
        _dep.DepPublicMethod();
    }

    public void CallingAbstractDependencyPublicMethod() 
    {
        _idep.DepAbstractPublicMethod();
    }
}
