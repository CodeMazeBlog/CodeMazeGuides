using Microsoft.ML.Data;

namespace MachineLearningInCsharpEngine.DataModels.MulticlassClassification;

public class ModelInput
{
    [ColumnName("duration"), LoadColumn(1)]
    public float Duration { get; set; }

    [ColumnName("credit_amount"), LoadColumn(4)]
    public float CreditAmount { get; set; }

    [ColumnName("age"), LoadColumn(12)]
    public float Age { get; set; }

    [ColumnName("class"), LoadColumn(20)]
    public string Class { get; set; }
}
