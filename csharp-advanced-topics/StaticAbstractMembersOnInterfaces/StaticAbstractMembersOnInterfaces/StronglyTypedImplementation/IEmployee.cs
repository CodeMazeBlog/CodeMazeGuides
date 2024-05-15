namespace StaticAbstractMembersOnInterfaces.StronglyTypedImplementation;

public interface IEmployee
{
    public string FirstName { get; }
    public string LastName { get; }
    public static abstract IEmployee Create(string firstName, string lastName);
}