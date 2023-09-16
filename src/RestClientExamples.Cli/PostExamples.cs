using RestClientExamples.ExampleApi.Models;
using RestClientExamples.Flurl;
using RestClientExamples.Manual;
using RestClientExamples.NSwag;
using RestClientExamples.Refit;
using RestClientExamples.RestEase;
using RestClientExamples.RestSharp;

namespace RestClientExamples.Cli;

public class PostExamples : Examples
{
    private readonly Random _random;

    public PostExamples(
        IManualWeatherForecastClient manualWeatherForecastClient,
        INswagWeatherForecastClient nswagWeatherForecastClient,
        IRefitWeatherForecastClient refitWeatherForecastClient,
        IRestEaseWeatherForecastClient restEaseWeatherForecastClient,
        IRestSharpWeatherForecastClient restSharpWeatherForecastClient,
        IFlurlWeatherForecastClient flurlWeatherForecastClient)
        : base(
            manualWeatherForecastClient,
            nswagWeatherForecastClient,
            refitWeatherForecastClient,
            restEaseWeatherForecastClient,
            restSharpWeatherForecastClient,
            flurlWeatherForecastClient)
    {
        _random = new Random();
    }

    public async Task ExecuteExamples()
    {
        Console.WriteLine("### Executing POST examples ###");
        Console.WriteLine();

        LogCreationMessage(manual);
        var manualWeatherReport = CreateWeatherReport(manual);
        await _manualWeatherForecastClient.PostAsync(manualWeatherReport);

        LogCreationMessage(nSwag);
        var nSwagWeatherReport = CreateWeatherReport(nSwag);
        await _nswagWeatherForecastClient.CreateWeatherReportAsync(nSwagWeatherReport);

        LogCreationMessage(refit);
        var refitWeatherReport = CreateWeatherReport(refit);
        await _refitWeatherForecastClient.PostAsync(refitWeatherReport);

        LogCreationMessage(restEase);
        var restEaseWeatherReport = CreateWeatherReport(restEase);
        await _restEaseWeatherForecastClient.PostAsync(restEaseWeatherReport);

        LogCreationMessage(restSharp);
        var restSharpWeatherReport = CreateWeatherReport(restSharp);
        await _restSharpWeatherForecastClient.PostAsync(restSharpWeatherReport);

        LogCreationMessage(flurl);
        var flurlWeatherReport = CreateWeatherReport(flurl);
        await _flurlWeatherForecastClient.PostAsync(flurlWeatherReport);

        Console.WriteLine();
        Console.WriteLine("### POST examples finished ###");
    }

    public async Task ExecutePostPerformanceTest()
    {
        Console.WriteLine("### Executing POST performance test ###");
        Console.WriteLine();

        var manualWeatherReport = CreateWeatherReport(manual);
        var createWeatherReportManually = async () => await _manualWeatherForecastClient.PostAsync(manualWeatherReport);
        var manualPerformanceResult = await ExecutePerformanceTestAsync(manual, createWeatherReportManually);

        var nSwagWeatherReport = CreateWeatherReport(nSwag);
        var createWeatherReportNswag = async () => await _nswagWeatherForecastClient.CreateWeatherReportAsync(nSwagWeatherReport);
        var nSwagPerformanceResult = await ExecutePerformanceTestAsync(nSwag, createWeatherReportNswag);

        var refitWeatherReport = CreateWeatherReport(refit);
        var createWeatherReportRefit = async () => await _refitWeatherForecastClient.PostAsync(refitWeatherReport);
        var refitPerformanceResult = await ExecutePerformanceTestAsync(refit, createWeatherReportRefit);

        var restEaseWeatherReport = CreateWeatherReport(restEase);
        var createWeatherReportRestEase = async () => await _restEaseWeatherForecastClient.PostAsync(restEaseWeatherReport);
        var restEasePerformanceResult = await ExecutePerformanceTestAsync(restEase, createWeatherReportRestEase);

        var restSharpWeatherReport = CreateWeatherReport(restSharp);
        var createWeatherReportRestSharp = async () => await _restSharpWeatherForecastClient.PostAsync(restSharpWeatherReport);
        var restSharpPerformanceResult = await ExecutePerformanceTestAsync(restSharp, createWeatherReportRestSharp);

        var flurlWeatherReport = CreateWeatherReport(flurl);
        var createWeatherReportFlurl = async () => await _flurlWeatherForecastClient.PostAsync(flurlWeatherReport);
        var flurlPerformanceResult = await ExecutePerformanceTestAsync(flurl, createWeatherReportFlurl);

        Console.WriteLine();
        Console.WriteLine("The POST performance results are as follows:");

        LogPerformance(
            manualPerformanceResult,
            nSwagPerformanceResult,
            refitPerformanceResult,
            restEasePerformanceResult,
            restSharpPerformanceResult,
            flurlPerformanceResult);

        Console.WriteLine("### POST performance test finished! ###");
    }

    private static void LogCreationMessage(string clientName)
    {
        Console.WriteLine($"Creating WeatherReport via the {clientName} client...");
    }

    private WeatherReport CreateWeatherReport(string clientName) => new()
    {
        Date = DateTime.Now,
        Location = clientName,
        TemperatureC = _random!.Next(-10, 36),
    };
}
