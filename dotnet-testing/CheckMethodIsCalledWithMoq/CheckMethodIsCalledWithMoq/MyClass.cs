namespace CheckMethodIsCalledWithMoq;

public class MyClass
{
    private Dependency _dep;
    private IDependency _idep;
    private AbstractDependency _abstractDep;

    public MyClass(Dependency dep, IDependency idep, AbstractDependency abstractDep)
    {
        _dep = dep;
        _idep = idep;
        _abstractDep = abstractDep;
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

    public void CallingInterfaceDependencyPublicMethod() 
    {
        _idep.DepInterfacePublicMethod();
    }

    public void CallingAbstractDependencyPublicMethod() 
    {
        _abstractDep.DepAbstractPublicMethod();
    }
}
