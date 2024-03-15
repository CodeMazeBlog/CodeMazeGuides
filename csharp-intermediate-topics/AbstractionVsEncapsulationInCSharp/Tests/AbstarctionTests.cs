public class AnimalTests
{
    [Fact]
    public void GivenDog_WhenMakeSoundCalled_ThenShouldPrintBark()
    {
        // Arrange
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        Dog dog = new Dog();

        // Act
        dog.MakeSound();
        var expected = "Bark bark!";
        var actual = sw.ToString().Trim();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenCat_WhenMakeSoundCalled_ThenShouldPrintMeow()
    {
        // Arrange
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        Cat cat = new Cat();

        // Act
        cat.MakeSound();
        var expected = "Meow!";
        var actual = sw.ToString().Trim();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenAnimal_WhenNameSet_ThenShouldReturnCorrectName()
    {
        // Arrange
        Animal animal = new Dog();
        var expectedName = "Buddy";

        // Act
        animal.Name = expectedName;
        var actualName = animal.Name;

        // Assert
        Assert.Equal(expectedName, actualName);
    }

    [Fact]
    public void GivenAnimal_WhenAgeSet_ThenShouldReturnCorrectAge()
    {
        // Arrange
        Animal animal = new Cat();
        var expectedAge = 5;

        // Act
        animal.Age = expectedAge;
        var actualAge = animal.Age;

        // Assert
        Assert.Equal(expectedAge, actualAge);
    }
}