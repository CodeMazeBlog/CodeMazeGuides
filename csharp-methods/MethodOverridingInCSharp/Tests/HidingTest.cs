using MethodOverridingInCSharp;

namespace Tests
{
    public class HidingTest
    {
        [Fact]
        public void GivenDerivedReference_WhenHiddenMethodCalled_ThenCallDerivedMethod()
        {
            var sketch = new Sketch { Color = "Black" };

            var actual = sketch.Draw();

            Assert.Equal("Sketching a Black outline", actual);
        }

        [Fact]
        public void GivenBaseReferenceToHidingObject_WhenMethodCalled_ThenCallBaseMethod()
        {
            Shape sketchAsShape = new Sketch { Color = "Black" };

            var actual = sketchAsShape.Draw();

            Assert.Equal("Drawing a Black colored shape", actual);
        }

        [Fact]
        public void GivenBaseReferenceToOverridingObject_WhenMethodCalled_ThenCallDerivedMethod()
        {
            Shape circleAsShape = new Circle { Color = "Black", Radius = 2 };

            var actual = circleAsShape.Draw();

            Assert.Equal("Drawing a Black colored circle with a radius of 2 units.", actual);
        }
    }
}
