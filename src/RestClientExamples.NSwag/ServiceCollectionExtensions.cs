using Microsoft.Extensions.DependencyInjection;

namespace RestClientExamples.NSwag;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNswagWeatherForecastClient(this IServiceCollection services, Action<HttpClient> configureClient)
    {
        services.AddHttpClient<INswagWeatherForecastClient, NswagWeatherForecastClient>(configureClient);
        return services;
    }
}
