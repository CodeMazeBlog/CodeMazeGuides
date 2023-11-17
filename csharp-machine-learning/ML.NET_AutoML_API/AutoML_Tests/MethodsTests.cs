namespace AutoML_Tests;
public class MethodsTests
{
    [Test]
    public void DefaultExperiment()
    {
        var experimentResult = Methods.DefaultExperiment();

        Assert.IsNotNull(experimentResult);
    }

    [Test]
    public void CustomExperiment()
    {
        var experimentResult = Methods.CustomExperiment();

        Assert.IsNotNull(experimentResult);
    }
}
