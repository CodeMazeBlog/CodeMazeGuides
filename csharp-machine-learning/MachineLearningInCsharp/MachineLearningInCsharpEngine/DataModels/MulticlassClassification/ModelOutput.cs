using Microsoft.ML.Data;
namespace MachineLearningInCsharpEngine.DataModels.MulticlassClassification;

public class ModelOutput
{
    [ColumnName("PredictedLabel")]
    public string Prediction { get; set; }
}
