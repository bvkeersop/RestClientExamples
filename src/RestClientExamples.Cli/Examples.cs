using RestClientExamples.Flurl;
using RestClientExamples.Manual;
using RestClientExamples.NSwag;
using RestClientExamples.Refit;
using RestClientExamples.RestEase;
using RestClientExamples.RestSharp;
using System.Diagnostics;

namespace RestClientExamples.Cli;

public abstract class Examples
{
    public const int numberOfExecutions = 1000;

    public const string manual = "Manual";
    public const string nSwag = "NSwag";
    public const string refit = "Refit";
    public const string restEase = "RestEase";
    public const string restSharp = "RestSharp";
    public const string flurl = "Flurl";

    protected readonly IManualWeatherForecastClient _manualWeatherForecastClient;
    protected readonly INswagWeatherForecastClient _nswagWeatherForecastClient;
    protected readonly IRefitWeatherForecastClient _refitWeatherForecastClient;
    protected readonly IRestEaseWeatherForecastClient _restEaseWeatherForecastClient;
    protected readonly IRestSharpWeatherForecastClient _restSharpWeatherForecastClient;
    protected readonly IFlurlWeatherForecastClient _flurlWeatherForecastClient;

    public Examples(
            IManualWeatherForecastClient manualWeatherForecastClient,
            INswagWeatherForecastClient nswagWeatherForecastClient,
            IRefitWeatherForecastClient refitWeatherForecastClient,
            IRestEaseWeatherForecastClient restEaseWeatherForecastClient,
            IRestSharpWeatherForecastClient restSharpWeatherForecastClient,
            IFlurlWeatherForecastClient flurlWeatherForecastClient)
    {
        _manualWeatherForecastClient = manualWeatherForecastClient;
        _nswagWeatherForecastClient = nswagWeatherForecastClient;
        _refitWeatherForecastClient = refitWeatherForecastClient;
        _restEaseWeatherForecastClient = restEaseWeatherForecastClient;
        _restSharpWeatherForecastClient = restSharpWeatherForecastClient;
        _flurlWeatherForecastClient = flurlWeatherForecastClient;
    }

    protected static async Task<PerformanceResult> ExecutePerformanceTestAsync(string name, Func<Task> taskToExecute)
    {
        Console.WriteLine($"Executing operation on the {name} client {numberOfExecutions} times...");
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        for (var i = 0; i < numberOfExecutions; i++)
        {
            await taskToExecute();
        }

        stopwatch.Stop();

        return new PerformanceResult
        {
            Name = name,
            NumberOfRequests = numberOfExecutions,
            TotalDuration = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds)
        };
    }

    protected static void LogPerformance(params PerformanceResult[] performanceResults)
    {
        var orderedPerformanceResults = performanceResults.OrderBy(p => p.AvarageDurationPerRequest);

        Console.WriteLine();
        Console.WriteLine("--- Performance test results ---");
        foreach (var performanceResult in orderedPerformanceResults)
        {
            Console.WriteLine($"Client {performanceResult.Name} " +
                $"executed {performanceResult.NumberOfRequests} " +
                $"in {performanceResult.TotalDuration}, " +
                $"This means the avarage request took {performanceResult.AvarageDurationPerRequest.TotalMilliseconds} miliseconds");
        }
        Console.WriteLine();
    }
}
