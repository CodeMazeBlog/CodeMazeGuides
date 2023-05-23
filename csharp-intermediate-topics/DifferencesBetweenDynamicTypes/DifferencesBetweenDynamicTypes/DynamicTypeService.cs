using System.ComponentModel;
using System.Dynamic;

namespace DifferencesBetweenDynamicTypes;

public class DynamicTypeService
{
    public void WorkingWithDynamicType()
    {
        dynamic count = 1;
        dynamic description = "String literal";

        dynamic car = new
        {
            Make = "Toyota",
            Model = "Crown",
            Year = 1960
        };
    }

    public ExpandoObject CreateExpandoObject()
    {
        dynamic book = new ExpandoObject();

        book.Author = "John Doe";
        book.Year = 2023;

        return book;
    }

    public ExpandoObject ReadValuesFromExpandoObject()
    {
        dynamic country = new ExpandoObject();

        country.Continent = "Asia";
        country.Population = "3 Billion people";

        foreach (KeyValuePair<string, object> keyValuePair in country)
        {
            Console.WriteLine($"{keyValuePair.Key} : {keyValuePair.Value}");
        }

        return country;
    }

    public ExpandoObject RemoveValuesFromExpandoObject()
    {
        dynamic person = new ExpandoObject();

        person.Age = 30;
        person.Name = "Jane Doe";

        ((IDictionary<string, object>)person).Remove("Age");

        return person;
    }

    public ExpandoObject HandlePropertyChanges()
    {
        dynamic person = new ExpandoObject();

        ((INotifyPropertyChanged)person).PropertyChanged += (sender, e) =>
        {
            Console.WriteLine($"Property changed: {e.PropertyName}");
        };

        person.Name = "John Doe";

        return person;
    }
}