using Microsoft.ML;

namespace MachineLearningInCsharpEngine.DataModels.MulticlassClassification;

public class ModelBuilder
{
    private MLContext mlContext = new MLContext(seed: 0);
    private PredictionEngine<ModelInput, ModelOutput> predictionEngine;
    private IDataView trainingDataView;
    private IDataView testDataView;
    ITransformer mlModel;

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
        
        BuildAndTrainModel(trainingDataView, pipeline);
       
        EvaluateModel();

        SaveModel(savingPath);

        predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
    }

    public void LoadModel(string path)
    {
        mlModel = mlContext.Model.Load(path, out _);
        predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
    }

    public IEstimator<ITransformer> ProcessData()
    {
        var pipeline = mlContext.Transforms.Conversion
            .MapValueToKey(inputColumnName: "class", outputColumnName: "Label")
            .Append(mlContext.Transforms.Concatenate("Features", "duration", "credit_amount", "age"));
        return pipeline;
    }

    public IEstimator<ITransformer> BuildAndTrainModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
    {
        var trainingPipeline = pipeline
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

        mlModel = trainingPipeline.Fit(trainingDataView);

        return trainingPipeline;
    }

    public void EvaluateModel()
    {
        var testMetrics = mlContext.MulticlassClassification.Evaluate(mlModel.Transform(testDataView));
        Console.WriteLine($"=============== Evaluating to get model's accuracy metrics - Ending time: {DateTime.Now.ToString()} ===============");
        Console.WriteLine($"*************************************************************************************************************");
        Console.WriteLine($"*       Metrics for Multi-class Classification model - Test Data     ");
        Console.WriteLine($"*------------------------------------------------------------------------------------------------------------");
        Console.WriteLine($"*       MicroAccuracy:    {testMetrics.MicroAccuracy:0.###}");
        Console.WriteLine($"*       MacroAccuracy:    {testMetrics.MacroAccuracy:0.###}");
        Console.WriteLine($"*       LogLoss:          {testMetrics.LogLoss:#.###}");
        Console.WriteLine($"*       LogLossReduction: {testMetrics.LogLossReduction:#.###}");
        Console.WriteLine($"*************************************************************************************************************");

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
