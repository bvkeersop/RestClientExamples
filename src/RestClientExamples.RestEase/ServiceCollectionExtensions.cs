using Microsoft.Extensions.DependencyInjection;
using RestEase.HttpClientFactory;

namespace RestClientExamples.RestEase;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRestEaseWeatherForecastClient(this IServiceCollection services, string baseUri)
    {
        services.AddRestEaseClient<IRestEaseWeatherForecastClient>(baseUri);
        return services;
    }
}