using MethodOverridingInCSharp;

namespace Tests
{
    public class BaseCallTest
    {
        [Fact]
        public void GivenCubeInstance_WhenMethodCalled_ThenCallBaseMethodFirst()
        {
            var cube = new Cube { Color = "Yellow", Edge = 7 };

            var lines = cube.Draw()
                .ReplaceLineEndings("\n")
                .Split('\n', StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(2, lines.Length);
            Assert.Equal("Drawing a Yellow colored shape", lines[0]);
            Assert.Equal("Drawing a cube with edges of length, width, and height of 7 units", lines[1]);
        }
    }
}
