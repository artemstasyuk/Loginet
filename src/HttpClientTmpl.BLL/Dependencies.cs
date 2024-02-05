using HttpClientTmpl.BLL.Interfaces;
using HttpClientTmpl.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HttpClientTmpl.BLL;

public static class Dependencies
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        services.AddScoped<IAlbumService, AlbumService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }

    
}