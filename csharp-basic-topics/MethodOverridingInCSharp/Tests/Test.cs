using MethodOverridingInCSharp;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void GivenBaseClassInstance_WhenMethodCalled_ThenCallBaseClassMethod()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                var shape = new Shape { Color = "Black" };
                shape.Draw();

                var expected = string.Format("Drawing a Black colored shape");

                Assert.Equal(expected, Convert.ToString(writer)?.Trim());
            }
        }

        [Fact]
        public void GivenDerivedClassInstance_WhenMethodCalled_ThenCallDerivedClassMethod()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                var circle = new Circle { Color = "Gray", Radius = 22.7 };
                circle.Draw();

                var expected = string.Format("Drawing a Gray colored circle with a radius of 22.7 units.");

                Assert.Equal(expected, Convert.ToString(writer)?.Trim());
            }
        }
    }
}