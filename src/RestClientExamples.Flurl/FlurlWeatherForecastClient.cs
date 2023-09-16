using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using RestClientExamples.ExampleApi.Models;
using System.Net;

namespace RestClientExamples.Flurl;

public interface IFlurlWeatherForecastClient
{
    Task<IEnumerable<WeatherForecast>> GetAsync(string location);
    Task PostAsync(WeatherReport weatherReport);
}

public class FlurlWeatherForecastClient : IFlurlWeatherForecastClient
{
    private readonly FlurlWeatherForecastClientOptions _options;

    public FlurlWeatherForecastClient(IOptions<FlurlWeatherForecastClientOptions> options)
    {
        _options = options.Value;
    }

    public async Task<IEnumerable<WeatherForecast>> GetAsync(string location)
    {
        var result = await _options.WeatherControllerUri
            .AppendPathSegment("GetWeatherForecasts")
            .SetQueryParam("location", location)
            .GetJsonAsync<IEnumerable<WeatherForecast>>();

        if (result is null)
        {
            return Enumerable.Empty<WeatherForecast>();
        }

        return result;
    }

    public async Task PostAsync(WeatherReport weatherReport)
    {
        var result = await _options.WeatherControllerUri
            .AppendPathSegment("CreateWeatherReport")
            .PostJsonAsync(weatherReport);

        if (result.StatusCode != (int)HttpStatusCode.OK)
        {
            throw new HttpRequestException("Something went wrong while creating a weather report", null,
                statusCode: (HttpStatusCode)result.StatusCode);
        }
    }
}