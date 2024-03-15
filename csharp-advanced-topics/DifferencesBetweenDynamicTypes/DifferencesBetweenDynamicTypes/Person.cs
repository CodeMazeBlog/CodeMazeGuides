using System.Dynamic;

namespace DifferencesBetweenDynamicTypes;

public class Person : DynamicObject
{
    private readonly Dictionary<string, object?> _personalInformation;

    public Person()
    {
        _personalInformation = new Dictionary<string, object?>();
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        var key = binder.Name;

        return _personalInformation.TryGetValue(key, out result);
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        var key = binder.Name;
        _personalInformation[key] = value;

        return true;
    }

    public void PrintInfo()
    {
        Console.WriteLine("Personal Information:");

        foreach (var info in _personalInformation)
        {
            Console.WriteLine($"{info.Key}: {info.Value}");
        }
    }
}
