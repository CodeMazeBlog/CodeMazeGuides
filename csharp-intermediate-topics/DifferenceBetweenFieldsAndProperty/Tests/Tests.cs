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

    [Fact]
    public void GivenRectangleWithFieldKeyword_WhenAssigningNegativeWidth_ThenThrowsException()
    {
        var rectangle = new RectangleWithFieldKeyword();

        Assert.Throws<ArgumentException>(() => rectangle.Width = -2);
    }

    [Fact]
    public void GivenRectangleWithFieldKeyword_WhenAssigningValidWidth_ThenStoresValue()
    {
        var rectangle = new RectangleWithFieldKeyword { Width = 14 };

        Assert.Equal(14, rectangle.Width);
    }
}