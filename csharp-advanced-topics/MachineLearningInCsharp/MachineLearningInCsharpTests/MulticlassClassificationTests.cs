using MachineLearningInCsharpEngine.DataModels.MulticlassClassification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MachineLearningInCsharpTests;

[TestClass]
public class MulticlassClassificationTests  
{
    private static ModelBuilder modelBuilder;

    public MulticlassClassificationTests()
    {
        if(modelBuilder == null)
        {
            modelBuilder = new ModelBuilder();
            var currentDir = Directory.GetCurrentDirectory();
            modelBuilder.CreateModel(Path.Combine(currentDir, @"DataSets\credit_customers.csv"),
                Path.Combine(currentDir,"multiclassCreditClassificationModel.zip"));
        }
    }

    [TestMethod]
    public void WhenPredictGoodCreditClass_ThanSuccess()
    {
        var prediction = modelBuilder.Predict(new ModelInput()
        {
            age = 340,
            credit_amount = 25000,
            duration = 80
        });

        Assert.IsTrue(prediction.Prediction == "good");
    }


    [TestMethod]
    public void WhenPredictBadCreditClass_ThanSuccess()
    {
        var prediction = modelBuilder.Predict(new ModelInput()
        {
            age = 240,
            credit_amount = 45000,
            duration = 480
        });

        Assert.IsTrue(prediction.Prediction == "bad");
    }

}