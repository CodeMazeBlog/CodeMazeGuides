using Microsoft.ML;
using Microsoft.ML.Data;

namespace MachineLearningInCsharpEngine.DataModels.BinaryClassification;

public class ModelBuilder
{
    private MLContext mlContext = new MLContext(seed: 0);
    private PredictionEngine<ModelInput, ModelOutput> predictionEngine;
    private IDataView trainingDataView;
    private IDataView testDataView;
    ITransformer mlModel;

    private class LookupMap
    {
        public string Key { get; set; }
        public bool Value { get; set; }
    }

    public void CreateModel(string dataFilePath, string savingPath)
    {
        // Load Data
        var allDataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                        path: dataFilePath,
                                        hasHeader: true,
                                        separatorChar: ',');

        var split = mlContext.Data.TrainTestSplit(allDataView, testFraction: 0.1);
        trainingDataView = split.TrainSet;
        testDataView = split.TestSet;

        var pipeline = ProcessData();
        
        var trainingPipeline = BuildAndTrainModel(trainingDataView, pipeline);
       
        EvaluateModel(trainingPipeline);

        SaveModel(savingPath);

        predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
    }

    public IEstimator<ITransformer> ProcessData()
    {
        var lookupData = new[] {
                new LookupMap { Key = "good", Value = true },
                new LookupMap { Key = "bad", Value = false }
            };

        // Convert to IDataView
        var lookupIdvMap = mlContext.Data.LoadFromEnumerable(lookupData);

        var pipeline = mlContext.Transforms.Conversion
            .MapValue("Label", lookupIdvMap, lookupIdvMap.Schema["Key"], lookupIdvMap.Schema["Value"], "class")
            .Append(mlContext.Transforms.Concatenate("Features", "duration", "credit_amount", "age"));

        return pipeline;
    }

    public IEstimator<ITransformer> BuildAndTrainModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
    {
        var trainingPipeline = pipeline
                .Append(mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression("Label", "Features"));

        mlModel = trainingPipeline.Fit(trainingDataView);

        return trainingPipeline;
    }

    public void EvaluateModel(IEstimator<ITransformer> trainingPipeline)
    {
        var crossValidationResults = mlContext.BinaryClassification.CrossValidateNonCalibrated(trainingDataView, trainingPipeline, numberOfFolds: 5, labelColumnName: "Label");
        PrintBinaryClassificationFoldsAverageMetrics(crossValidationResults);
    }

    public static void PrintBinaryClassificationFoldsAverageMetrics(IEnumerable<TrainCatalogBase.CrossValidationResult<BinaryClassificationMetrics>> crossValResults)
    {
        var metricsInMultipleFolds = crossValResults.Select(r => r.Metrics);

        var AccuracyValues = metricsInMultipleFolds.Select(m => m.Accuracy);
        var AccuracyAverage = AccuracyValues.Average();
        var AccuraciesStdDeviation = CalculateStandardDeviation(AccuracyValues);
        var AccuraciesConfidenceInterval95 = CalculateConfidenceInterval95(AccuracyValues);


        Console.WriteLine($"*************************************************************************************************************");
        Console.WriteLine($"*       Metrics for Binary Classification model      ");
        Console.WriteLine($"*------------------------------------------------------------------------------------------------------------");
        Console.WriteLine($"*       Average Accuracy:    {AccuracyAverage:0.###}  - Standard deviation: ({AccuraciesStdDeviation:#.###})  - Confidence Interval 95%: ({AccuraciesConfidenceInterval95:#.###})");
        Console.WriteLine($"*************************************************************************************************************");
    }

    public static double CalculateStandardDeviation(IEnumerable<double> values)
    {
        double average = values.Average();
        double sumOfSquaresOfDifferences = values.Select(val => (val - average) * (val - average)).Sum();
        double standardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / (values.Count() - 1));
        return standardDeviation;
    }

    public static double CalculateConfidenceInterval95(IEnumerable<double> values)
    {
        double confidenceInterval95 = 1.96 * CalculateStandardDeviation(values) / Math.Sqrt((values.Count() - 1));
        return confidenceInterval95;
    }

    private void SaveModel(string modelRelativePath)
    {
        mlContext.Model.Save(mlModel, trainingDataView.Schema, GetAbsolutePath(modelRelativePath));
    }

    public string GetAbsolutePath(string relativePath)
    {
        return Path.Combine(Environment.CurrentDirectory, relativePath);
    }

    public ModelOutput Predict(ModelInput input)
    {
        return predictionEngine.Predict(input);
    }
}
