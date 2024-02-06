using EventBor.Backend.Application.Services;
using EventBor.Backend.Application.Services.Categories;
using Microsoft.Extensions.DependencyInjection;

namespace EventBor.Backend.Application;

public static class Dependencies
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}
