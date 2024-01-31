using EventBor.Backend.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventBor.Backend.Application;

public static class Dependencies
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEventService, EventService>();
        return services;
    }
}
