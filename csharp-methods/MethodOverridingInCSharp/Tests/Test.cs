using MethodOverridingInCSharp;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void GivenBaseClassInstance_WhenMethodCalled_ThenCallBaseClassMethod()
        {
            var shape = new Shape { Color = "Black" };
            var actual = shape.Draw();

            var expected = string.Format("Drawing a Black colored shape");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenDerivedClassInstance_WhenMethodCalled_ThenCallDerivedClassMethod()
        {
            var circle = new Circle { Color = "Gray", Radius = 22.7 };
            var actual = circle.Draw();

            var expected = string.Format("Drawing a Gray colored circle with a radius of 22.7 units.");

            Assert.Equal(expected, actual);
        }
    }
}