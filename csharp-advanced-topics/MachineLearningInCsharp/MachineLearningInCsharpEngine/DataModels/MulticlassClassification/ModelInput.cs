using Microsoft.ML.Data;

namespace MachineLearningInCsharpEngine.DataModels.MulticlassClassification;

public class ModelInput
{
    [ColumnName("duration"), LoadColumn(1)]
    public float duration { get; set; }

    [ColumnName("credit_amount"), LoadColumn(4)]
    public float credit_amount { get; set; }

    [ColumnName("age"), LoadColumn(12)]
    public float age { get; set; }

    [ColumnName("class"), LoadColumn(20)]
    public string @class { get; set; }
}
