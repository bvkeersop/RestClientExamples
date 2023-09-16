using RestClientExamples.ExampleApi.Models;
using RestSharp;
using System.Text.Json;

namespace RestClientExamples.RestSharp;

public interface IRestSharpWeatherForecastClient
{
    Task<IEnumerable<WeatherForecast>> GetAsync(string location);
    Task PostAsync(WeatherReport weatherForecast);
}

public class RestSharpWeatherForecastClient : IRestSharpWeatherForecastClient
{
    private readonly string _weatherForecast = "WeatherForecast";
    private readonly RestClient _restClient;

    public RestSharpWeatherForecastClient(RestClient restClient)
    {
        _restClient = restClient;
    }

    public async Task<IEnumerable<WeatherForecast>> GetAsync(string location)
    {
        var subUrl = $"{_weatherForecast}/GetWeatherForecasts";
        var request = new RestRequest(subUrl)
            .AddParameter("location", location);

        var response = await _restClient.ExecuteGetAsync<IEnumerable<WeatherForecast>>(request);

        if (!response.IsSuccessful)
        {
            throw new HttpRequestException("Something went wrong while retrieving weather forecasts", null, 
                statusCode: response.StatusCode);
        }

        if (response.Data is null)
        {
            return Enumerable.Empty<WeatherForecast>();
        }

        return response.Data;
    }

    public async Task PostAsync(WeatherReport weatherForecast)
    {
        var subUrl = $"{_weatherForecast}/CreateWeatherReport";
        var json = JsonSerializer.Serialize(weatherForecast);
        var request = new RestRequest(subUrl).AddJsonBody(json);

        var response = await _restClient.ExecutePostAsync(request);

        if (!response.IsSuccessful)
        {
            throw new HttpRequestException("Something went wrong while creating a weather report", null,
                statusCode: response.StatusCode);
        }
    }
}