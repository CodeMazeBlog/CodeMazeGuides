namespace DifferenceBetweenFieldsAndProperty;

public class Voter
{
    private int _age;

    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 18)
                throw new ArgumentException("The person is a minor and cannot vote.", nameof(value));

            _age = value;
        }
    }

    public string Name { get; set; }

    public Voter(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string DisplayIsVoter()
    {
        return $"{Name} can vote as their age is: {_age}";
    }
}
