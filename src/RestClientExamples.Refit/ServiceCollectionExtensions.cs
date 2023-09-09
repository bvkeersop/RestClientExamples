using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace RestClientExamples.Refit;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRefitWeatherForecastClient(this IServiceCollection services, Action<HttpClient> configureClient)
    {
        services
            .AddRefitClient<IRefitWeatherForecastClient>()
            .ConfigureHttpClient(configureClient);
        return services;
    }
}
