namespace JsonSerializeToDictionaryDataModel.Tests;

public class PersonRecordTests
{
    [Fact]
    public void GivenPerson_WhenToString_ThenProducesFirstSpaceLast()
    {
        const string expected = "Han Solo";
        var names = expected.Split(" ");
        var person = new Person(names[0], names[1]);

        Assert.Equal(expected, person.ToString());
    }

    [Fact]
    public void GivenPersonWithEmptyFirstName_WhenToString_ThenProducesLast()
    {
        const string last = "Solo";
        var person = new Person(string.Empty, last);

        Assert.Equal(last, person.ToString());
    }

    [Fact]
    public void GivenPersonWithEmptyLastName_WhenToString_ThenProducesFirst()
    {
        const string first = "Han`";
        var person = new Person(first, string.Empty);

        Assert.Equal(first, person.ToString());
    }

    [Fact]
    public void GivenPersonWithEmptyFirstAndLast_WhenToString_ThenProducesEmpty()
    {
        var person = new Person(string.Empty, string.Empty);

        Assert.Equal(string.Empty, person.ToString());
    }
}