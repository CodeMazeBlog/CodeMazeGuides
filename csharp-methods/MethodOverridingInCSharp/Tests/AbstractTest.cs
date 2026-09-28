using MethodOverridingInCSharp.Abstract;

namespace Tests
{
    public class AbstractTest
    {
        [Fact]
        public void GivenAbstractBaseClass_WhenDerivedMethodsCalled_ThenCallDerivedImplementations()
        {
            var circle = new Circle { Color = "Red", Radius = 5.5 };
            var square = new Square { Color = "Blue", Side = 12 };

            Assert.Equal("Drawing a Red colored circle with a radius of 5.5 units.", circle.Draw());
            Assert.Equal("Drawing a square of color Blue with its sides having length and width of 12 units", square.Draw());
        }
    }
}
