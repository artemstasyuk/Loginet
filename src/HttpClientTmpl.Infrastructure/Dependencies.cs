using HttpClientTmpl.BLL.Interfaces.Clients;
using HttpClientTmpl.BLL.Interfaces.Persistence;
using HttpClientTmpl.Infrastructure.Clients.JsonPlaceholder;
using HttpClientTmpl.Infrastructure.Persistence;
using HttpClientTmpl.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;

namespace HttpClientTmpl.Infrastructure;

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