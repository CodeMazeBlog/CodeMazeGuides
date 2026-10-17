namespace ReadOnlyTests;

public class ReadOnlyTests
{
    [Fact]
    public void GivenCircle_WhenRadiusSetInCtor_ThenAreaCalculatedUsingRadius()
    {
        var circle = new Circle(7.5);
        const double expectedArea = Math.PI * 7.5 * 7.5;

        Assert.Equal(expectedArea, circle.Area, 2);
    }

    [Fact]
    public void GivenPerson_WhenCallingChangeName_ThenNameChanged()
    {
        var person = new Person("John",21);
        person.ChangeName("Darren");
        const string expectedName = "Darren";

        Assert.Equal(expectedName, person.Name);
    }

    [Fact]
    public void GivenReadonlyListField_WhenAddingSongs_ThenListChanges()
    {
        var playlist = new Playlist();
        playlist.Add("Bohemian Rhapsody");
        playlist.Add("Hotel California");

        Assert.Equal(2, playlist.Count);
    }

    [Fact]
    public void GivenReadonlyStructField_WhenCountingTwice_ThenTotalStaysZero()
    {
        var tally = new Tally();
        tally.Count();
        tally.Count();

        Assert.Equal(0, tally.Total);
    }

    [Fact]
    public void GivenCounterVariable_WhenIncrementingTwice_ThenValueIsTwo()
    {
        var counter = new Counter();
        counter.Increment();
        counter.Increment();

        Assert.Equal("Counted 2 times", counter.Describe());
    }
}
