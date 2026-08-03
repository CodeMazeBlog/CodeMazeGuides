using Microsoft.ML;
namespace MachineLearningInCsharpEngine.DataModels.MulticlassClassification;

public class ModelBuilder
{
    private MLContext _mlContext = new MLContext(seed: 0);
    private PredictionEngine<ModelInput, ModelOutput> _predictionEngine;
    private IDataView _trainingDataView;
    private IDataView _testDataView;
    private ITransformer _mlModel;

    public void CreateModel(string dataFilePath, string savingPath)
    {
        LoadAndSplitData(dataFilePath);

        var pipeline = PreProcessData();
        
        BuildAndTrainModel(_trainingDataView, pipeline);
       
        EvaluateModel();

        SaveModel(savingPath);

        CreatePredictionEngine();
    }

    public void LoadModel(string path)
    {
        _mlModel = _mlContext.Model.Load(path, out _);
        CreatePredictionEngine();    }

    private void LoadAndSplitData(string dataFilePath)
    {
        var allDataView = _mlContext.Data.LoadFromTextFile<ModelInput>(
                                      path: dataFilePath,
                                      hasHeader: true,
                                      separatorChar: ',');

        var split = _mlContext.Data.TrainTestSplit(allDataView, testFraction: 0.1);
        _trainingDataView = split.TrainSet;
        _testDataView = split.TestSet;
    }

    public IEstimator<ITransformer> PreProcessData()
    {
        var pipeline = _mlContext.Transforms.Conversion
            .MapValueToKey(inputColumnName: "class", outputColumnName: "Label")
            .Append(_mlContext.Transforms.Concatenate("Features", "duration", "credit_amount", "age"));

        return pipeline;
    }

    public IEstimator<ITransformer> BuildAndTrainModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
    {
        var trainingPipeline = pipeline
                .Append(_mlContext.MulticlassClassification.Trainers.SdcaNonCalibrated("Label", "Features"))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

        _mlModel = trainingPipeline.Fit(trainingDataView);

        return trainingPipeline;
    }

    public void EvaluateModel()
    {
        var testMetrics = _mlContext.MulticlassClassification.Evaluate(_mlModel.Transform(_testDataView));
        Console.WriteLine($"Evaluation Metrics:");
        Console.WriteLine($"- MicroAccuracy:\t{testMetrics.MicroAccuracy:0.###}");
        Console.WriteLine($"- MacroAccuracy:\t{testMetrics.MacroAccuracy:0.###}");
        Console.WriteLine($"- LogLoss:\t\t{testMetrics.LogLoss:#.###}");
        Console.WriteLine($"- LogLossReduction:\t{testMetrics.LogLossReduction:#.###}");
    }

    private void SaveModel(string saveModelPath)
    {
        _mlContext.Model.Save(_mlModel, _trainingDataView.Schema, 
            Path.Combine(Environment.CurrentDirectory, saveModelPath));
    }

    private void CreatePredictionEngine()
    {
        _predictionEngine = _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(_mlModel);
    }

    public ModelOutput Predict(ModelInput input)
    {
        return _predictionEngine.Predict(input);
    }
}