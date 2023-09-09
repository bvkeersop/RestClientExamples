using Refit;
using RestClientExamples.ExampleApi.Models;

namespace RestClientExamples.Refit;

public interface IRefitWeatherForecastClient
{
    [Get("/WeatherForecast")]
    Task<IEnumerable<WeatherForecast>> GetAsync();
}