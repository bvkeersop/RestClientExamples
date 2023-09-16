using Microsoft.Extensions.DependencyInjection;
using RestClientExamples.Cli;
using RestClientExamples.Flurl;
using RestClientExamples.Manual;
using RestClientExamples.NSwag;
using RestClientExamples.Refit;
using RestClientExamples.RestEase;
using RestClientExamples.RestSharp;
using System.Reflection;

Console.WriteLine("### RestClientExamples ###");
Console.WriteLine("This console application will demo the usage of multiple types of REST clients.");

var exampleApiBaseAdress = "https://localhost:7020";
var exampleApiBaseUri = new Uri(exampleApiBaseAdress);
var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

if (currentDir is null)
{
    throw new InvalidOperationException("Could not determine current directory");
}

var services = new ServiceCollection();

services
    .AddExamples()
    .AddManualWeatherForecastClient(options => options.BaseAddress = exampleApiBaseUri)
    .AddNswagWeatherForecastClient(options => options.BaseAddress = exampleApiBaseUri)
    .AddRefitWeatherForecastClient(options => options.BaseAddress = exampleApiBaseUri)
    .AddRestEaseWeatherForecastClient(exampleApiBaseAdress)
    .AddRestSharpWeatherForecastClient(options => options.BaseUrl = exampleApiBaseUri)
    .AddFlurlWeatherForecastClient(options => options.BaseUri = exampleApiBaseAdress);

var serviceProvider = services.BuildServiceProvider();

var getExamples = serviceProvider.GetRequiredService<GetExamples>();
var postExamples = serviceProvider.GetRequiredService<PostExamples>();

var inputDemo = "1";
var inputPerformance = "2";

var userInput = ConsoleHelper.GetUserInput(
    prompt: $"Press '{inputDemo}' for Demo, press '{inputPerformance}' for Performance Test", 
    firstTimePrompting: true,
    allowedValues: new string[] { inputDemo, inputPerformance});

if (userInput == inputDemo)
{
    Console.WriteLine();
    await getExamples.ExecuteExamples();
    Console.WriteLine();
    await postExamples.ExecuteExamples();
    Console.WriteLine();
    Console.WriteLine("Demo complete, press any key to close the application");
    Console.ReadKey();
}
else if (userInput == inputPerformance)
{
    Console.WriteLine();
    await getExamples.ExecuteGetPerformanceTest();
    Console.WriteLine();
    await postExamples.ExecutePostPerformanceTest();
    Console.WriteLine();
    Console.WriteLine("Performance test complete, press any key to close the application");
    Console.ReadKey();
}