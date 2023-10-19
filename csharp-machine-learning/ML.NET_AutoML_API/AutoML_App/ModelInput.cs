using Microsoft.ML.Data;

public class ModelInput
{
    [ColumnName(@"male")]
    public float Male { get; set; }

    [ColumnName(@"age")]
    public float Age { get; set; }

    [ColumnName(@"education")]
    public float Education { get; set; }

    [ColumnName(@"currentSmoker")]
    public float CurrentSmoker { get; set; }

    [ColumnName(@"cigsPerDay")]
    public float CigsPerDay { get; set; }

    [ColumnName(@"BPMeds")]
    public float BPMeds { get; set; }

    [ColumnName(@"prevalentStroke")]
    public float PrevalentStroke { get; set; }

    [ColumnName(@"prevalentHyp")]
    public float PrevalentHyp { get; set; }

    [ColumnName(@"diabetes")]
    public float Diabetes { get; set; }

    [ColumnName(@"totChol")]
    public float TotChol { get; set; }

    [ColumnName(@"sysBP")]
    public float SysBP { get; set; }

    [ColumnName(@"diaBP")]
    public float DiaBP { get; set; }

    [ColumnName(@"BMI")]
    public float BMI { get; set; }

    [ColumnName(@"heartRate")]
    public float HeartRate { get; set; }

    [ColumnName(@"glucose")]
    public float Glucose { get; set; }

    [ColumnName(@"TenYearCHD")]
    public bool TenYearCHD { get; set; }
}