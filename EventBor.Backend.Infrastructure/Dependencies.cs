using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EventBor.Backend.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using EventBor.Backend.Infrastructure.Database.Repositories;
using EventBor.Backend.Infrastructure.Database.Repositories.Categories;

namespace EventBor.Backend.Infrastructure;

public static class Dependencies
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnectionString")));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
