using Microsoft.ML.AutoML;

public class CustomExperimentMonitor : IMonitor
{
    private readonly SweepablePipeline _pipeline;
    private readonly List<TrialResult> _completedTrials;
    public IEnumerable<TrialResult> GetCompletedTrials() => _completedTrials;

    public CustomExperimentMonitor(SweepablePipeline pipeline)
    {
        _pipeline = pipeline;
        _completedTrials = new List<TrialResult>();
    }

    public void ReportBestTrial(TrialResult result)
    {
        return;
    }

    public void ReportCompletedTrial(TrialResult result)
    {
        var timeToTrain = result.DurationInMilliseconds;
        var pipeline = _pipeline.ToString(result.TrialSettings.Parameter);
        _completedTrials.Add(result);

        Console.WriteLine($"\t- finished training in {timeToTrain}ms with pipeline {pipeline}");
    }

    public void ReportFailTrial(TrialSettings settings, Exception exception = null)
    {
        if (exception.Message.Contains("Operation was canceled."))
            Console.WriteLine($"\t- cancelled. Time budget exceeded.");
        
        Console.WriteLine($"\t- failed with exception {exception.Message}");
    }

    public void ReportRunningTrial(TrialSettings setting)
    {
        Console.WriteLine($"Running Trial Id {setting.TrialId}:");
    }
}