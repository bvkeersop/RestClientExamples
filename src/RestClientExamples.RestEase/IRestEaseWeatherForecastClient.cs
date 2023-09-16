using RestClientExamples.ExampleApi.Models;
using RestEase;

namespace RestClientExamples.RestEase;

public interface IRestEaseWeatherForecastClient
{
    [Get("/WeatherForecast/GetWeatherForecasts?location={location}")]
    Task<IEnumerable<WeatherForecast>> GetAsync([Path] string location);

    [Post("/WeatherForecast/CreateWeatherReport")]
    Task PostAsync([Body] WeatherReport weatherForecast);
}