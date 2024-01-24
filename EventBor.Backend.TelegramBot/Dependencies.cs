using EventBor.Backend.TelegramBot.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace EventBor.Backend.TelegramBot;

public static class Dependencies
{
    public static IServiceCollection AddTelegramBot(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string botApiKey = configuration.GetSection("TelegramBot").Value;

        services.AddSingleton<ITelegramBotClient, TelegramBotClient>(x => new TelegramBotClient(botApiKey));

        services.AddTransient<UpdateHandler>();

        return services;
    }
}
