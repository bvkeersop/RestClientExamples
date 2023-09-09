using RestClientExamples.ExampleApi.Models;
using RestSharp;

namespace RestClientExamples.RestSharp;

public interface IRestSharpWeatherForecastClient
{
    Task<IEnumerable<WeatherForecast>> GetAsync();
}

public class RestSharpWeatherForecastClient : IRestSharpWeatherForecastClient
{
    private readonly string _weatherForecast = "WeatherForecast";
    private readonly RestClient _restClient;

    public RestSharpWeatherForecastClient(RestClient restClient)
    {
        _restClient = restClient;
    }

    public async Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        var weatherForecasts = await _restClient.GetJsonAsync<IEnumerable<WeatherForecast>>(_weatherForecast);

        if (weatherForecasts is null)
        {
            return Enumerable.Empty<WeatherForecast>();
        }

        return weatherForecasts;
    }
}