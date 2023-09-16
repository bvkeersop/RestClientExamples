using RestClientExamples.Flurl;
using RestClientExamples.Manual;
using RestClientExamples.NSwag;
using RestClientExamples.Refit;
using RestClientExamples.RestEase;
using RestClientExamples.RestSharp;

namespace RestClientExamples.Cli
{
    public class GetExamples : Examples
    {
        public GetExamples(
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
        }

        public async Task ExecuteExamples()
        {
            Console.WriteLine("### Executing GET examples ###");
            Console.WriteLine();

            var location = "Amsterdam";

            LogRetrievalMessage(manual);
            var weatherForecastsViaManual = await _manualWeatherForecastClient.GetAsync(location);
            LogResult(weatherForecastsViaManual.Count());

            LogRetrievalMessage(nSwag);
            var weatherForecastsViaNswag = await _nswagWeatherForecastClient.GetWeatherForecastsAsync(location);
            LogResult(weatherForecastsViaNswag.Count);

            LogRetrievalMessage(refit);
            var weatherForecastsViaRefit = await _refitWeatherForecastClient.GetAsync(location);
            LogResult(weatherForecastsViaRefit.Count());

            LogRetrievalMessage(restEase);
            var weatherForecastsViaRestEase = await _restEaseWeatherForecastClient.GetAsync(location);
            LogResult(weatherForecastsViaRestEase.Count());

            LogRetrievalMessage(restSharp);
            var weatherForecastsViaRestSharp = await _restSharpWeatherForecastClient.GetAsync(location);
            LogResult(weatherForecastsViaRestSharp.Count());

            LogRetrievalMessage(flurl);
            var weatherForecastsViaFlurl = await _flurlWeatherForecastClient.GetAsync(location);
            LogResult(weatherForecastsViaFlurl.Count());

            Console.WriteLine();
            Console.WriteLine("### GET examples finished! ###");
        }

        public async Task ExecuteGetPerformanceTest()
        {
            Console.WriteLine("### Executing GET performance test ###");
            Console.WriteLine();

            var location = "Amsterdam";

            var weatherForecastsViaManual = async () => await _manualWeatherForecastClient.GetAsync(location);
            var manualPerformanceResult = await ExecutePerformanceTestAsync(manual, weatherForecastsViaManual);

            var weatherForecastsViaNswag = async () => await _nswagWeatherForecastClient.GetWeatherForecastsAsync(location);
            var nSwagPerformanceResult = await ExecutePerformanceTestAsync(nSwag, weatherForecastsViaNswag);

            var weatherForecastsViaRefit = async () => await _refitWeatherForecastClient.GetAsync(location);
            var refitPerformanceResult = await ExecutePerformanceTestAsync(refit, weatherForecastsViaRefit);

            var weatherForecastsViaRestEase = async () => await _restEaseWeatherForecastClient.GetAsync(location);
            var restEasePerformanceResult = await ExecutePerformanceTestAsync(restEase, weatherForecastsViaRestEase);

            var weatherForecastsViaRestSharp = async () => await _restSharpWeatherForecastClient.GetAsync(location);
            var restSharpPerformanceResult = await ExecutePerformanceTestAsync(restSharp, weatherForecastsViaRestSharp);

            var weatherForecastsViaFlurl = async () => await _flurlWeatherForecastClient.GetAsync(location);
            var flurlPerformanceResult = await ExecutePerformanceTestAsync(flurl, weatherForecastsViaFlurl);

            Console.WriteLine();
            Console.WriteLine("The GET performance results are as follows:");

            LogPerformance(
                manualPerformanceResult,
                nSwagPerformanceResult,
                refitPerformanceResult,
                restEasePerformanceResult,
                restSharpPerformanceResult,
                flurlPerformanceResult);

            Console.WriteLine("### GET performance test finished! ###");
        }

        private static void LogRetrievalMessage(string clientName)
        {
            Console.WriteLine($"Retrieving WeatherForecasts via the {clientName} client...");
        }

        private static void LogResult(int count)
        {
            Console.WriteLine($"Successfully Retrieved {count} WeatherForecasts!");
        }
    }
}
