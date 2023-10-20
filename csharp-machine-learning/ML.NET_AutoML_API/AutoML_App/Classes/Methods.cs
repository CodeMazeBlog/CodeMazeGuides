using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.Data;
using Microsoft.ML.SearchSpace;
using Microsoft.ML.SearchSpace.Option;
using Microsoft.ML.Trainers.LightGbm;
using System.Linq;

public static class Methods
{
    public async static Task<ITransformer> DefaultExperiment()
    {
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

        var cts = new CancellationTokenSource();
        var experimentResults = await experiment.RunAsync(cts.Token);

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
        Console.WriteLine("Direct prediction - Heart Disease Risk exists: {0}", directPrediction.GetColumn<bool>("PredictedLabel").FirstOrDefault());

        var ctx = new MLContext();
        ITransformer predictionPipeline = ctx.Model.Load("model.zip", out _);
        var predictionEngine = ctx.Model.CreatePredictionEngine<ModelInput, ModelOutput>(predictionPipeline);
        var prediction = predictionEngine.Predict(input);
        Console.WriteLine("Saved model - Heart Disease Risk exists: {0}", prediction.PredictedLabel);

        return bestModel;
    }

    public async static Task<ITransformer> CustomExperiment()
    {
        var mlContext = new MLContext();

        var dataPath = "DataSets/framingham.csv";
        var columnInfo = mlContext.Auto().InferColumns(dataPath, labelColumnName: "TenYearCHD", groupColumns: false);

        //The following two lines show how to change a column type if required.
        //columnInfo.ColumnInformation.NumericColumnNames.Remove("education");
        //columnInfo.ColumnInformation.TextColumnNames.Add("education");

        columnInfo.ColumnInformation.IgnoredColumnNames.Add("totChol");

        IDataView data = mlContext.Data.LoadFromTextFile(dataPath, columnInfo.TextLoaderOptions);
        var splitData = mlContext.Data.TrainTestSplit(data, testFraction: 0.1);

        var lgbmSearchSpace = new SearchSpace<LgbmOptionExtended>();
        var lgbmFactory = (MLContext ctx, LgbmOptionExtended param) =>
        {
            var lgbmOptions = new LightGbmBinaryTrainer.Options()
            {
                LearningRate = 0.01F,
                NumberOfIterations = 5,
                NumberOfLeaves = 10,
                UseCategoricalSplit = true,
                MinimumExampleCountPerLeaf = 10,
                L2CategoricalRegularization = 0.02F,
                LabelColumnName = columnInfo.ColumnInformation.LabelColumnName,
                BatchSize = param.BatchSize
            };
            return ctx.BinaryClassification.Trainers.LightGbm(lgbmOptions);
        };

        lgbmSearchSpace["L1Regularization"] = new UniformSingleOption(min: 0.01f, max: 1.0f, defaultValue: 0.1f);

        var nestedSearchSpace = new SearchSpace();
        nestedSearchSpace["IntOption"] = new UniformIntOption(min: -10, max: 10);
        lgbmSearchSpace["Nest"] = nestedSearchSpace;

        var lgbmCustomEstimator = mlContext.Auto().CreateSweepableEstimator(lgbmFactory, lgbmSearchSpace);

        var pipeline = mlContext.Auto().Featurizer(data, columnInformation: columnInfo.ColumnInformation)
                .Append(mlContext.Auto()
                .BinaryClassification(labelColumnName: columnInfo.ColumnInformation.LabelColumnName,
                useFastTree: false, useLbfgs: false))
                .Append(lgbmCustomEstimator);

        var experiment = mlContext.Auto().CreateExperiment();
        experiment
            .SetPipeline(pipeline)
            .SetTrainingTimeInSeconds(10)
            .SetBinaryClassificationMetric(BinaryClassificationMetric.Accuracy, columnInfo.ColumnInformation.LabelColumnName)
            .SetDataset(splitData);

        experiment.SetGridSearchTuner();

        var monitor = new CustomExperimentMonitor(pipeline);
        experiment.SetMonitor(monitor);

        var cts = new CancellationTokenSource();
        var experimentResults = await experiment.RunAsync(cts.Token);

        var checkpointPath = Path.Join(Directory.GetCurrentDirectory(), "checkpoints");
        experiment.SetCheckpoint(checkpointPath);
        
        var completedTrials = monitor.GetCompletedTrials();

        var bestModel = experimentResults.Model;
        Console.WriteLine($"Accuracy: {experimentResults.Metric}.");

        var pfi = CalculateFeatureImportance(mlContext, bestModel, splitData.TestSet, 
            columnInfo.ColumnInformation.LabelColumnName);
        foreach (var item in pfi)
            Console.WriteLine($"{item.Item1}: {item.Item2}");

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
            SysBP = 221F,
            DiaBP = 91F,
            BMI = 3873F,
            HeartRate = 95F,
            Glucose = 86F
        };

        var directPrediction = bestModel.Transform(mlContext.Data.LoadFromEnumerable(new List<ModelInput>() { input }));
        Console.WriteLine("Direct prediction - Heart Disease Risk exists: {0}", directPrediction.GetColumn<bool>("PredictedLabel").FirstOrDefault());

        var ctx = new MLContext();
        ITransformer predictionPipeline = ctx.Model.Load("model.zip", out _);
        var predictionEngine = ctx.Model.CreatePredictionEngine<ModelInput, ModelOutput>(predictionPipeline);
        var prediction = predictionEngine.Predict(input);
        Console.WriteLine("Saved model - Heart Disease Risk exists: {0}", prediction.PredictedLabel);

        return bestModel;
    }

    public static List<Tuple<string, BinaryClassificationMetricsStatistics>> CalculateFeatureImportance(MLContext mlContext, 
        ITransformer model, IDataView dataset, string labelColumnName)
    {
        var linearPredictor = model as TransformerChain<ITransformer>;
        var pfiResults = mlContext.BinaryClassification
            .PermutationFeatureImportanceNonCalibrated(linearPredictor, dataset, labelColumnName);

        var featureImportance = pfiResults.Select(x => Tuple.Create(x.Key, x.Value))
        .OrderByDescending(x => x.Item2).ToList();

        return featureImportance;
    }
}