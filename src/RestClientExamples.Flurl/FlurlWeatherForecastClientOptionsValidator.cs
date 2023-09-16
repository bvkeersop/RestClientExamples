using Microsoft.Extensions.Options;

namespace RestClientExamples.Flurl;

public class FlurlWeatherForecastClientOptionsValidator : IValidateOptions<FlurlWeatherForecastClientOptions>
{
    public ValidateOptionsResult Validate(string? name, FlurlWeatherForecastClientOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.BaseUri))
        {
            return ValidateOptionsResult.Fail($"{nameof(options.BaseUri)} cannot be null or empty.");
        }

        return ValidateOptionsResult.Success;
    }
}
