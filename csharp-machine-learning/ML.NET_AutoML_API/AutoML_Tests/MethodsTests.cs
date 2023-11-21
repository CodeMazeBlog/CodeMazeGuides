namespace AutoML_Tests;
public class MethodsTests
{
    [Test]
    public void WhenDefaultExperiment_ThenExperimentResult()
    {
        var experimentResult = Methods.DefaultExperiment();

        Assert.IsNotNull(experimentResult);
    }

    [Test]
    public void WhenCustomExperiment_ThenExperimentResult()
    {
        var experimentResult = Methods.CustomExperiment();

        Assert.IsNotNull(experimentResult);
    }
}