namespace RestClientExamples.Cli;

public class PerformanceResult
{
    public string Name { get; set; }
    public int NumberOfRequests { get; set; }
    public TimeSpan TotalDuration { get; set; }
    public TimeSpan AvarageDurationPerRequest => TotalDuration / NumberOfRequests;
}
