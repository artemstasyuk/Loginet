using Loginet.BLL.Interfaces.Clients;
using Loginet.BLL.Interfaces.Persistence;
using Loginet.Infrastructure.Clients.JsonPlaceholder;
using Loginet.Infrastructure.Persistence;
using Loginet.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;

namespace Loginet.Infrastructure;

public static class Dependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, 
        IHostBuilder host)
    {
        services
            .AddPersistence(configuration)
            .AddLogging(configuration, host);
        
        services.Configure<JsonPlaceholderOptions>(configuration.GetSection(nameof(JsonPlaceholderOptions)));
        services.AddHttpClient<IJsonPlaceholderClient, JsonPlaceholderClient>()
            .ConfigureHttpClient((serviceProvider, client) =>
                {
                    var optionsService = serviceProvider
                        .GetRequiredService<IOptions<JsonPlaceholderOptions>>();
                    var options = optionsService.Value;
                    client.BaseAddress = new Uri($"https://{options.Host}");
                }
            );
        return services;
    }
    
    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Postgres")!);
        });
        
        services.AddHostedService<DbContextAppInitializer>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAlbumRepository, AlbumRepository>();
        
        return services;
    }
    
    private static void AddLogging(this IServiceCollection services, IConfiguration configuration,
        IHostBuilder host)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        host.UseSerilog(logger);
    }
}