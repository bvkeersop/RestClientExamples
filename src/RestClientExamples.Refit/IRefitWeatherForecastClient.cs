using Refit;
using RestClientExamples.ExampleApi.Models;

namespace RestClientExamples.Refit;

public interface IRefitWeatherForecastClient
{
    [Get("/WeatherForecast/GetWeatherForecasts?location={location}")]
    Task<IEnumerable<WeatherForecast>> GetAsync(string location);

    [Post("/WeatherForecast/CreateWeatherReport")]
    Task PostAsync(WeatherReport weatherForecast);
}