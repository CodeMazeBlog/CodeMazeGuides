using Microsoft.ML.Data;

namespace MachineLearningInCsharpEngine.DataModels.BinaryClassification;

public class ModelOutput
{
    [ColumnName("PredictedLabel")]
    public bool Prediction { get; set; }

    public float Score { get;set; }

    public override string ToString()
    {
        return $"Prediction: {Prediction}, Score: {Score}";
    }
}
