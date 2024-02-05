using EventBor.Backend.Application.Services;
using EventBor.Backend.Application.Services.Categories;
using EventBor.Backend.Application.Services.EventCategories;
using Microsoft.Extensions.DependencyInjection;

namespace EventBor.Backend.Application;

public static class Dependencies
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IEventCategoryService, EventCategoryService>();
        return services;
    }
}
