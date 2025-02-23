using Serilog;

namespace AWS.Sample.API.Infrastructure;

public static class ServiceConfiguration
{
    public static IServiceCollection AddSerilogLogging(this IServiceCollection services, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        return services;
    }
}