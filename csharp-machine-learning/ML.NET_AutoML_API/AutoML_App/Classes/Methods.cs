using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.Data;
using Microsoft.ML.SearchSpace;
using Microsoft.ML.SearchSpace.Option;
using Microsoft.ML.Trainers.LightGbm;

public static class Methods
{
    public static async Task<ITransformer> DefaultExperiment()
    {
        var mlContext = new MLContext();

        var dataPath = "DataSets/framingham.csv";
        var columnInfo = mlContext.Auto().InferColumns(dataPath, 
            labelColumnName: "TenYearCHD", groupColumns: false);

        var data = mlContext.Data.LoadFromTextFile(dataPath, columnInfo.TextLoaderOptions);
        var splitData = mlContext.Data.TrainTestSplit(data, testFraction: 0.1);

        var pipeline = mlContext.Auto().Featurizer(data, 
            columnInformation: columnInfo.ColumnInformation)
                .Append(mlContext.Auto()
                .BinaryClassification(
                    labelColumnName: columnInfo.ColumnInformation.LabelColumnName));

        var experiment = mlContext.Auto().CreateExperiment();
        experiment
            .SetPipeline(pipeline)
            .SetTrainingTimeInSeconds(10)
            .SetBinaryClassificationMetric(BinaryClassificationMetric.Accuracy, 
            columnInfo.ColumnInformation.LabelColumnName)
            .SetDataset(splitData);

        var cts = new CancellationTokenSource();
        var experimentResults = await experiment.RunAsync(cts.Token);
        cts.Dispose();
        var bestModel = experimentResults.Model;

        Console.WriteLine($"Accuracy: {experimentResults.Metric}");

        mlContext.Model.Save(bestModel, data.Schema, "model.zip");

        TestModel(mlContext, bestModel);

        return bestModel;
    }

    public async static Task<ITransformer> CustomExperiment()
    {
        var mlContext = new MLContext();

        var dataPath = "DataSets/framingham.csv";
        var columnInfo = mlContext.Auto().InferColumns(dataPath, 
            labelColumnName: "TenYearCHD", groupColumns: false);

        //The following two lines show how to change a column type if required.
        //columnInfo.ColumnInformation.NumericColumnNames.Remove("education");
        //columnInfo.ColumnInformation.TextColumnNames.Add("education");

        columnInfo.ColumnInformation.IgnoredColumnNames.Add("totChol");

        var data = mlContext.Data.LoadFromTextFile(dataPath, columnInfo.TextLoaderOptions);
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
        cts.Dispose();

        var checkpointPath = Path.Join(Directory.GetCurrentDirectory(), "checkpoints");
        experiment.SetCheckpoint(checkpointPath);

        var completedTrials = monitor.GetCompletedTrials();

        var bestModel = experimentResults.Model;
        Console.WriteLine($"Accuracy: {experimentResults.Metric}.");

        CalculateFeatureImportance(mlContext, bestModel, splitData.TrainSet, 
            columnInfo.ColumnInformation.LabelColumnName);

        mlContext.Model.Save(bestModel, data.Schema, "model.zip");

        TestModel(mlContext, bestModel);
       
        return bestModel;
    }

    private static void TestModel(MLContext mlContext, ITransformer bestModel)
    {
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
            BMI = 387F,
            HeartRate = 95F,
            Glucose = 86F
        };

        var directPrediction = bestModel.Transform(
            mlContext.Data.LoadFromEnumerable(new List<ModelInput>() { input }));

        Console.WriteLine("\nDirect prediction - Heart Disease Risk exists: {0}", 
            directPrediction.GetColumn<bool>("PredictedLabel").FirstOrDefault());

        var ctx = new MLContext();
        ITransformer predictionPipeline = ctx.Model.Load("model.zip", out _);
        var predictionEngine = ctx.Model
            .CreatePredictionEngine<ModelInput, ModelOutput>(predictionPipeline);
        var prediction = predictionEngine.Predict(input);

        Console.WriteLine("\nSaved model - Heart Disease Risk exists: {0}", 
            prediction.PredictedLabel);
    }

    public static void CalculateFeatureImportance(MLContext mlContext,
        ITransformer model, IDataView dataset, string labelColumnName)
    {
        var transformedData = model.Transform(dataset);
        var linearPredictor = (model as TransformerChain<ITransformer>)?.LastTransformer;

        var pfiResults = mlContext.BinaryClassification
            .PermutationFeatureImportanceNonCalibrated(linearPredictor, transformedData, labelColumnName);

        var featureAUCs = pfiResults
                .Select(m => new { m.Key, m.Value.AreaUnderRocCurve })
                .OrderByDescending(m => Math.Abs(m.AreaUnderRocCurve.Mean))
                .Select(m => new
                {
                    Feature = m.Key,
                    AUC = m.AreaUnderRocCurve
                });

        Console.WriteLine("\nFeature Importance Calculations");

        foreach (var item in featureAUCs)
            Console.WriteLine($"{item.Feature, -20}{item.AUC.Mean}");
    }
}