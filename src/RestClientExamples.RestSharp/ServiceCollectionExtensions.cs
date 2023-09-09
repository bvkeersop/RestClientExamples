using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace RestClientExamples.RestSharp;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRestSharpWeatherForecastClient(this IServiceCollection services, Action<RestClientOptions> configureClient)
    {
        var configure = new ConfigureRestClient(configureClient);
        var restClient = new RestClient(configure);

        services
            .AddScoped<IRestSharpWeatherForecastClient, RestSharpWeatherForecastClient>()
            .AddScoped(sp => restClient);

        return services;
    }
}
