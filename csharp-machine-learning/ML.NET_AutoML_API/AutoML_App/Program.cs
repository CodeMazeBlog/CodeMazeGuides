using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.Data;

var mlContext = new MLContext();

var dataPath = "DataSets/framingham.csv";
var columnInfo = mlContext.Auto().InferColumns(dataPath, labelColumnName: "TenYearCHD", groupColumns: false);

IDataView data = mlContext.Data.LoadFromTextFile(dataPath, columnInfo.TextLoaderOptions);
var splitData = mlContext.Data.TrainTestSplit(data, testFraction: 0.1);

var pipeline = mlContext.Auto().Featurizer(data, columnInformation: columnInfo.ColumnInformation)
        .Append(mlContext.Auto().BinaryClassification(labelColumnName: columnInfo.ColumnInformation.LabelColumnName));

var experiment = mlContext.Auto().CreateExperiment();
experiment
    .SetPipeline(pipeline)
    .SetTrainingTimeInSeconds(10)
    .SetBinaryClassificationMetric(BinaryClassificationMetric.Accuracy, columnInfo.ColumnInformation.LabelColumnName)
    .SetDataset(splitData);

var experimentResults = await experiment.RunAsync();

var bestModel = experimentResults.Model;
Console.WriteLine($"Accuracy: {experimentResults.Metric}");

mlContext.Model.Save(bestModel, data.Schema, "model.zip");

var input = new ModelInput()
{
    Male = 0F,
    Age = 18F,
    Education = 2F,
    CurrentSmoker = 0F,
    CigsPerDay = 0F,
    BPMeds = 0F,
    PrevalentStroke = 0F,
    PrevalentHyp = 1F,
    Diabetes = 1F,
    TotChol = 250F,
    SysBP = 221F,
    DiaBP = 91F,
    BMI = 3873F,
    HeartRate = 95F,
    Glucose = 86F
};

var directPrediction = bestModel.Transform(mlContext.Data.LoadFromEnumerable(new List<ModelInput>() { input }));
Console.WriteLine("Heart Disease Risk exists: {0}", directPrediction.GetColumn<bool>("PredictedLabel").FirstOrDefault());

var ctx = new MLContext();
ITransformer predictionPipeline = ctx.Model.Load("model.zip", out _);
var predictionEngine = ctx.Model.CreatePredictionEngine<ModelInput, ModelOutput>(predictionPipeline);
var prediction = predictionEngine.Predict(input);
Console.WriteLine("Heart Disease Risk exists: {0}", prediction.PredictedLabel);