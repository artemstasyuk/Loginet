using Loginet.BLL.Interfaces;
using Loginet.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Loginet.BLL;

public static class Dependencies
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        services.AddScoped<IAlbumService, AlbumService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }

    
}