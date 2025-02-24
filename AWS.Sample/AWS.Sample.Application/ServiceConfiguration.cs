using AWS.Sample.Application.Services;
using AWS.Sample.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AWS.Sample.Application;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection provider)
    {
        provider.AddScoped<ITaskItemService, TaskItemService>();
        
        return provider;
    }
}