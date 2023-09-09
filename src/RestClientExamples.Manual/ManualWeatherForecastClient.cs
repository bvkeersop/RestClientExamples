using RestClientExamples.ExampleApi.Models;

namespace RestClientExamples.Manual;

public interface IManualWeatherForecastClient
{
    Task<IEnumerable<WeatherForecast>> GetAsync();
}

public class ManualWeatherForecastClient : IManualWeatherForecastClient
{
    private readonly string _weatherForecast = "WeatherForecast";
    private readonly HttpClient _httpClient;

    public ManualWeatherForecastClient(HttpClient httpClient)
	{
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        var response = await _httpClient.GetAsync(_weatherForecast);
        response.EnsureSuccessStatusCode();
        var deserializedContent = await response.GetDeserializedContent<IEnumerable<WeatherForecast>>();

        if (deserializedContent is null)
        {
            return Enumerable.Empty<WeatherForecast>();
        }

        return deserializedContent;
    }
}