using AWS.Sample.Domain.Persistence.Repositories;
using AWS.Sample.Infrastructure.Persistence;
using AWS.Sample.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AWS.Sample.Infrastructure;

public static class ServiceConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection provider,
        IConfiguration configuration)
    {
        provider.AddDbContext<IAWSDbContext, AWSDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        
        provider.AddScoped<ITaskItemRepository, TaskItemRepository>();

        provider.AddScoped<DatabaseMigrator>();
        
        return provider;
    }
}