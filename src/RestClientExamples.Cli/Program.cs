using Microsoft.Extensions.DependencyInjection;
using RestClientExamples.Manual;
using RestClientExamples.NSwag;
using RestClientExamples.Refit;
using RestClientExamples.RestSharp;
using System.Reflection;

Console.WriteLine("### RestClientExamples ###");
Console.WriteLine("This console application will demo the retrieval of WeatherForecasts with multiple clients.");

var exampleApiBaseAdress = new Uri("https://localhost:7020");
var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

if (currentDir is null)
{
    throw new InvalidOperationException("Could not determine current directory");
}

var services = new ServiceCollection();

services
    .AddManualWeatherForecastClient(options => options.BaseAddress = exampleApiBaseAdress)
    .AddNswagWeatherForecastClient(options => options.BaseAddress = exampleApiBaseAdress)
    .AddRefitWeatherForecastClient(options => options.BaseAddress = exampleApiBaseAdress)
    .AddRestSharpWeatherForecastClient(options => options.BaseUrl = exampleApiBaseAdress);

var serviceProvider = services.BuildServiceProvider();

var manualWeatherForecastClient = serviceProvider.GetRequiredService<IManualWeatherForecastClient>();
var nswagWeatherForecastClient = serviceProvider.GetRequiredService<INswagWeatherForecastClient>();
var refitWeatherForecastClient = serviceProvider.GetRequiredService<IRefitWeatherForecastClient>();
var restSharpWeatherForecastClient = serviceProvider.GetRequiredService<IRestSharpWeatherForecastClient>();

LogRetrievalMessage("Manual");
var weatherForecastsViaManual = await manualWeatherForecastClient.GetAsync();
LogResult(weatherForecastsViaManual.Count());

LogRetrievalMessage("NSwag");
var weatherForecastsViaNswag = await nswagWeatherForecastClient.GetAsync();
LogResult(weatherForecastsViaNswag.Count);

LogRetrievalMessage("Refit");
var weatherForecastsViaRefit = await refitWeatherForecastClient.GetAsync();
LogResult(weatherForecastsViaRefit.Count());

LogRetrievalMessage("RestSharp");
var weatherForecastsViaRestSharp = await restSharpWeatherForecastClient.GetAsync();
LogResult(weatherForecastsViaRestSharp.Count());

Console.WriteLine("Demo complete, press any key to close the application");
Console.ReadKey();

void LogRetrievalMessage(string clientName)
{
    Console.WriteLine($"Retrieving WeatherForecasts via the {clientName} client...");
}

void LogResult(int count)
{
    Console.WriteLine($"Successfully Retrieved {count} WeatherForecasts!");
}
