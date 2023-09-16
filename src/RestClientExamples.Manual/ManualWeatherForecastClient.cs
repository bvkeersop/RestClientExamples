using RestClientExamples.ExampleApi.Models;

namespace RestClientExamples.Manual;

public interface IManualWeatherForecastClient
{
    Task<IEnumerable<WeatherForecast>> GetAsync(string location);
    Task PostAsync(WeatherReport weatherReport);
}

public class ManualWeatherForecastClient : IManualWeatherForecastClient
{
    private readonly string _weatherForecast = "WeatherForecast";
    private readonly HttpClient _httpClient;

    public ManualWeatherForecastClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<WeatherForecast>> GetAsync(string location)
    {
        var subUrl = $"{_weatherForecast}/GetWeatherForecasts?location={location}";
        var response = await _httpClient.GetAsync(subUrl);
        response.EnsureSuccessStatusCode();
        var deserializedContent = await response.GetDeserializedContent<IEnumerable<WeatherForecast>>();

        if (deserializedContent is null)
        {
            return Enumerable.Empty<WeatherForecast>();
        }

        return deserializedContent;
    }

    public async Task PostAsync(WeatherReport weatherReport)
    {
        var subUrl = $"{_weatherForecast}/CreateWeatherReport";
        var httpContent = weatherReport.ToJsonHttpContent();
        var response = await _httpClient.PostAsync(subUrl, httpContent);
        response.EnsureSuccessStatusCode();
    }
}