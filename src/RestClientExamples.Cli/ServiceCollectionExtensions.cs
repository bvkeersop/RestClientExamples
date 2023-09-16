using Microsoft.Extensions.DependencyInjection;

namespace RestClientExamples.Cli
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExamples(this IServiceCollection services)
            => services.AddSingleton<GetExamples>()
            .AddSingleton<PostExamples>();
    }
}
