using MachineLearningInCsharpEngine.DataModels.BinaryClassification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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
            var currentDir = Directory.GetCurrentDirectory();
            var parentDir = Directory.GetParent(currentDir).Parent.Parent;  
            modelBuilder.CreateModel(Path.Combine(parentDir.FullName, @"DataSets\credit_customers.csv"),
                Path.Combine(currentDir, "binaryCreditClassificationModel.zip"));
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