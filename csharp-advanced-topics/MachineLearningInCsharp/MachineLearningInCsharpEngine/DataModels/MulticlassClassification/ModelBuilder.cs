using Microsoft.ML;
namespace MachineLearningInCsharpEngine.DataModels.MulticlassClassification;

public class ModelBuilder
{
    private MLContext mlContext = new MLContext(seed: 0);
    private PredictionEngine<ModelInput, ModelOutput> predictionEngine;
    private IDataView trainingDataView;
    private IDataView testDataView;
    private ITransformer mlModel;

    public void CreateModel(string dataFilePath, string savingPath)
    {
        LoadAndSplitData(dataFilePath);

        var pipeline = PreProcessData();
        
        BuildAndTrainModel(trainingDataView, pipeline);
       
        EvaluateModel();

        SaveModel(savingPath);

        CreatePredictionEngine();
    }

    public void LoadModel(string path)
    {
        mlModel = mlContext.Model.Load(path, out _);
        CreatePredictionEngine();    }

    private void LoadAndSplitData(string dataFilePath)
    {
        var allDataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                      path: dataFilePath,
                                      hasHeader: true,
                                      separatorChar: ',');

        var split = mlContext.Data.TrainTestSplit(allDataView, testFraction: 0.1);
        trainingDataView = split.TrainSet;
        testDataView = split.TestSet;
    }

    public IEstimator<ITransformer> PreProcessData()
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
        Console.WriteLine($"Evaluation Metrics:");
        Console.WriteLine($"- MicroAccuracy:\t{testMetrics.MicroAccuracy:0.###}");
        Console.WriteLine($"- MacroAccuracy:\t{testMetrics.MacroAccuracy:0.###}");
        Console.WriteLine($"- LogLoss:\t\t{testMetrics.LogLoss:#.###}");
        Console.WriteLine($"- LogLossReduction:\t{testMetrics.LogLossReduction:#.###}");
    }

    private void SaveModel(string saveModelPath)
    {
        mlContext.Model.Save(mlModel, trainingDataView.Schema, 
            Path.Combine(Environment.CurrentDirectory, saveModelPath));
    }

    private void CreatePredictionEngine()
    {
        predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
    }

    public ModelOutput Predict(ModelInput input)
    {
        return predictionEngine.Predict(input);
    }
}