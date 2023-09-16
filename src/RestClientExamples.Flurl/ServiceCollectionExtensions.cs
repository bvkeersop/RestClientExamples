using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace RestClientExamples.Flurl;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFlurlWeatherForecastClient(this IServiceCollection services, Action<FlurlWeatherForecastClientOptions> configureOptions)
    {
        services.AddScoped<IFlurlWeatherForecastClient, FlurlWeatherForecastClient>();
        return services
            .Configure(configureOptions)
            .AddSingleton<IValidateOptions<FlurlWeatherForecastClientOptions>, FlurlWeatherForecastClientOptionsValidator>();
    }
}
