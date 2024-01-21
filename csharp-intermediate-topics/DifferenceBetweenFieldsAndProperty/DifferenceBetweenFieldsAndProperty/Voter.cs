namespace DifferenceBetweenFieldsAndProperty;
public class Voter
{
    private int _age;

    public int Age
    {
        get { return _age; }
        set
        {
            if (value >= 18)
            {
                _age = value;
            }
            else
            {
                throw new ArgumentException("The person is a minor and cannot vote.", nameof(value));
            }
        }
    }
    public static string Name { get; set; }

    public Voter() { }

    public Voter(int initialValue)
    {
        Age = initialValue;
    }

    public string DisplayIsVoter()
    {
        return $"The person can vote as their age is: {_age}";
    }
}
