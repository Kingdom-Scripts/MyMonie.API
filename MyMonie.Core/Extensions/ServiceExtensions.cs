using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyMonie.Core.Interfaces;
using MyMonie.Core.Services;

namespace MyMonie.Core.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        // services.AddLazyCache();


        services.AddSingleton<ICacheService, CacheService>();
        services.TryAddScoped<ITokenGenerator, TokenGenerator>();

        return services;
    }
}