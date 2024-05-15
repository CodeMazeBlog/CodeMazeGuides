namespace StaticAbstractMembersOnInterfaces.StronglyTypedImplementation;

public static class GenericEmployeeFactory
{
    public static IEmployee CreateEmployee<T>(string firstName, string lastName) where T : IEmployee
    {
        return T.Create(firstName, lastName);
    }
}