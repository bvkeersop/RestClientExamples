using Microsoft.Extensions.DependencyInjection;

namespace RestClientExamples.Manual;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddManualWeatherForecastClient(this IServiceCollection services, Action<HttpClient> configureClient)
    {
        services.AddHttpClient<IManualWeatherForecastClient, ManualWeatherForecastClient>(configureClient);
        return services;
    }
}
