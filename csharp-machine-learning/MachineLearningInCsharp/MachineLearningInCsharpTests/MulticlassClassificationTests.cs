using MachineLearningInCsharpEngine.DataModels.MulticlassClassification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MachineLearningInCsharpTests;

[TestClass]
public class MulticlassClassificationTests
{
    private ModelBuilder? _modelBuilder;
    private string _savedModelFilename = "multiclassCreditClassificationModel.zip";

    public MulticlassClassificationTests()
    {
        if (_modelBuilder is null)
        {
            _modelBuilder = new ModelBuilder();
            var currentDir = Directory.GetCurrentDirectory();
            var parentDir = Directory.GetParent(currentDir)?.Parent?.Parent;
            _modelBuilder.CreateModel(Path.Combine(parentDir == null ? string.Empty : parentDir.FullName, @"DataSets/credit_customers.csv"),
                Path.Combine(currentDir, _savedModelFilename));
        }
    }

    [TestMethod]
    public void WhenPredictGoodCreditClass_ThanSuccess()
    {
        var prediction = _modelBuilder?.Predict(new ModelInput()
        {
            Age = 340,
            CreditAmount = 25000,
            Duration = 80
        });

        Assert.IsTrue(prediction?.Prediction.Equals("good"));
    }

    [TestMethod]
    public void WhenPredictBadCreditClass_ThanSuccess()
    {
        var prediction = _modelBuilder?.Predict(new ModelInput()
        {
            Age = 240,
            CreditAmount = 45000,
            Duration = 480
        });

        Assert.IsTrue(prediction?.Prediction.Equals("bad"));
    }

    [TestMethod]
    public void WhenPredictUsingSavedModel_ThanSuccess()
    {
        var loadedModelBuilder = new ModelBuilder();
        var currentDir = Directory.GetCurrentDirectory();
        loadedModelBuilder.LoadModel(Path.Combine(currentDir, _savedModelFilename));

        var prediction = loadedModelBuilder?.Predict(new ModelInput()
        {
            Age = 340,
            CreditAmount = 25000,
            Duration = 80
        });

        Assert.IsTrue(prediction?.Prediction.Equals("good"));
    }
}