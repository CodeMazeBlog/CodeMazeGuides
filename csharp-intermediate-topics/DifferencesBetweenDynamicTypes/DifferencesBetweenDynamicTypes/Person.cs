using System.Dynamic;

namespace DifferencesBetweenDynamicTypes;

public class Person : DynamicObject
{
    private Dictionary<string, object> personalInformation;

    public Person()
    {
        personalInformation = new Dictionary<string, object>();
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        var key = binder.Name;
        return personalInformation.TryGetValue(key, out result);
    }

    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        var key = binder.Name;
        personalInformation[key] = value;
        return true;
    }

    public void PrintInfo()
    {
        Console.WriteLine("Personal Information:");
        foreach (var info in personalInformation)
        {
            Console.WriteLine($"{info.Key}: {info.Value}");
        }
    }
}
