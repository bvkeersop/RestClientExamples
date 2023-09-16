namespace RestClientExamples.ExampleApi.Models
{
    public class WeatherForecast
    {
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    }
}