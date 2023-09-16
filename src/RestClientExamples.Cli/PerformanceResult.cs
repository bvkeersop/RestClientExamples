namespace RestClientExamples.Cli;

public class PerformanceResult
{
    public string Name { get; set; } = string.Empty;
    public int NumberOfRequests { get; set; }
    public TimeSpan TotalDuration { get; set; }
    public TimeSpan AverageDurationPerRequest => TotalDuration / NumberOfRequests;
}
