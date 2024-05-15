using System.Diagnostics.CodeAnalysis;

namespace StaticAbstractMembersOnInterfaces.StronglyTypedImplementation;

public class Developer : IEmployee, IParsable<Developer>
{
    private readonly string _firstName;
    private readonly string _lastName;

    public string FirstName => _firstName;

    public string LastName => _lastName;

    private Developer(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    public static IEmployee Create(string firstName, string lastName)
    {
        return new Developer(firstName, lastName);
    }

    public static Developer Parse(string s, IFormatProvider? provider)
    {
        var components = s.Split(',');

        if (components.Count() != 2)
        {
            throw new FormatException("Expected FirstName,LastName format.");
        }

        return new Developer(components[0], components[1]);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Developer result)
    {
        result = null;

        if (s is null)
        {
            return false;
        }

        try
        {
            result = Parse(s, provider);
            return true;
        }
        catch
        {
            return false;
        }
    }
}