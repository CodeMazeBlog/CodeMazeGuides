using Microsoft.VisualStudio.TestTools.UnitTesting;
using MachineLearningInCsharpEngine.DataModels.MulticlassClassification;

namespace MachineLearningInCsharpTests;

[TestClass]
public class MulticlassClassificationTests
{
    private const string SavedModelFilename = "multiclassCreditClassificationModel.zip";
    private static ModelBuilder _modelBuilder = null!;

    [ClassInitialize]
    public static void TrainModelOnce(TestContext _)
    {
        _modelBuilder = new ModelBuilder();
        _modelBuilder.CreateModel(
            Path.Combine(AppContext.BaseDirectory, "DataSets", "credit_customers.csv"),
            Path.Combine(AppContext.BaseDirectory, SavedModelFilename));
    }

    [TestMethod]
    public void WhenPredictGoodCreditClass_ThenSuccess()
    {
        var prediction = _modelBuilder.Predict(new ModelInput
        {
            Age = 35,
            CreditAmount = 2000,
            Duration = 12
        });

        Assert.AreEqual("good", prediction.Prediction);
    }

    [TestMethod]
    public void WhenPredictBadCreditClass_ThenSuccess()
    {
        var prediction = _modelBuilder.Predict(new ModelInput
        {
            Age = 22,
            CreditAmount = 15000,
            Duration = 60
        });

        Assert.AreEqual("bad", prediction.Prediction);
    }

    [TestMethod]
    public void WhenPredictUsingSavedModel_ThenSuccess()
    {
        var loadedModelBuilder = new ModelBuilder();
        loadedModelBuilder.LoadModel(Path.Combine(AppContext.BaseDirectory, SavedModelFilename));

        var prediction = loadedModelBuilder.Predict(new ModelInput
        {
            Age = 35,
            CreditAmount = 2000,
            Duration = 12
        });

        Assert.AreEqual("good", prediction.Prediction);
    }
}