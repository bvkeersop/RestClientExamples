namespace RestClientExamples.Flurl;

public class FlurlWeatherForecastClientOptions
{
    public string BaseUri { get; set; } = string.Empty;
    public string WeatherControllerUri => $"{BaseUri}/WeatherForecast";
}
