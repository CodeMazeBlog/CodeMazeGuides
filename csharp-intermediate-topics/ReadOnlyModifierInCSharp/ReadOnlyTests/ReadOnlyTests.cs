using ReadOnlyModifierInCSharp;

namespace ReadOnlyTests
{
    public class ReadOnlyTests
    {
        [Fact]
        public void GivenCircleWhenRadiusSetInCtorThenAreaCalculatedUsingRadius()
        {
            var circle = new Circle(7.5);
            var expectedArea = 176.71;

            Assert.Equal(expectedArea, Math.Round(circle.Area, 2));
        }

        [Fact]
        public void GivenPersonWhenCallingChangeNameThenNameChanged()
        {
            var person = new Person("John");
            person.ChangeName("Darren");
            var expectedName = "Darren";

            Assert.Equal(expectedName, person.Name);
        }
    }
}