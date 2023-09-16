using Microsoft.AspNetCore.Mvc;
using RestClientExamples.ExampleApi.Models;

namespace RestClientExamples.ExampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] _summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetWeatherForecasts")]
    public IEnumerable<WeatherForecast> GetWeatherForecasts([FromQuery] string location)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Location = location,
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[Random.Shared.Next(_summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost("CreateWeatherReport")]
    public IActionResult CreateWeatherReport(WeatherReport weatherReport)
    {
        _logger.LogDebug("Received a weather report at {date}, it's {degrees} celsius in {location}!",
            weatherReport.Date, weatherReport.TemperatureC, weatherReport.Location);

        return Ok();
    }
}