namespace Tests;

public class Tests
{
    [Fact]
    public void GivenRectangle_WhenAssigningNegativeWidth_ThenThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(-2, 14));
    }

    [Fact]
    public void GivenRectangle_WhenScaling_ThenReturnsScaledDimensions()
    {
        var rectangle = new Rectangle(40, 35);
        Rectangle.ScalingFactor = 3;

        var scaledRectangle = rectangle.CreateScaledRectangle();

        Assert.Equal(120, scaledRectangle.Width);

        Assert.Equal(105, scaledRectangle.Height);
    }
}