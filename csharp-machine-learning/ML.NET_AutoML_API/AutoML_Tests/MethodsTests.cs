namespace AutoML_Tests;
public class MethodsTests
{
    [Test]
    public async Task DefaultExperiment()
    {
        var experimentResult = await Methods.DefaultExperiment();
        Assert.IsNotNull(experimentResult);
    }

    [Test]
    public async Task CustomExperiment()
    {
        var experimentResult = await Methods.CustomExperiment();
        Assert.IsNotNull(experimentResult);
    }
}
