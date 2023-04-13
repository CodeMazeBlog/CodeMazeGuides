using MachineLearningInCsharpEngine.DataModels.BinaryClassification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MachineLearningInCsharpTests;

[TestClass]
public class BinaryClassificationTests
{
    private static ModelBuilder modelBuilder;

    public BinaryClassificationTests()
    {
        if(modelBuilder == null)
        {
            modelBuilder = new ModelBuilder();
            modelBuilder.CreateModel(@"DataSets\credit_customers.csv", "binaryCreditClassificationModel.zip");
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
        Console.WriteLine(prediction.ToString());

        Assert.IsTrue(prediction.Prediction);
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
        Console.WriteLine(prediction.ToString());

        Assert.IsFalse(prediction.Prediction);
    }

}