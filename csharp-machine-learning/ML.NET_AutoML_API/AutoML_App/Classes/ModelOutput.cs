using Microsoft.ML.Data;

public class ModelOutput
{
    [ColumnName(@"PredictedLabel")]
    public bool PredictedLabel { get; set; }

    [ColumnName(@"Score")]
    public float Score { get; set; }
}