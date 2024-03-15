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
}