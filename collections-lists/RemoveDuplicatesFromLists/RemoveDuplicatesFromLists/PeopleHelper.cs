namespace RemoveDuplicatesFromLists;

public static class PeopleHelper
{
    public static List<Person> UsingDistinct(List<Person> people)
    {
        return people.Distinct().ToList();
    }

    public static List<PersonRecord> UsingDistinct(List<PersonRecord> people)
    {
        return people.Distinct().ToList();
    }

    public static List<Person> UsingDistinctBy(List<Person> people)
    {
        return people.DistinctBy(p => p.Email).ToList();
    }
}
