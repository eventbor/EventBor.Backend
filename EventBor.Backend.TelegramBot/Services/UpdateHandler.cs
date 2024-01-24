using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace EventBor.Backend.TelegramBot.Services;

public class UpdateHandler
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly ILogger<UpdateHandler> _logger;

    public UpdateHandler(ITelegramBotClient telegramBotClient,
        ILogger<UpdateHandler> logger)
    {
        _telegramBotClient = telegramBotClient;
        _logger = logger;
    }

    public async Task UpdateHandlerAsync(Update update)
    {
        var handler = update.Type switch
        {
            UpdateType.Message => HandleCommandAsync(update.Message),
            _ => HandleNotAvailableCommandAsync(update.Message)
        };

        await handler;
    }

    public async Task HandleCommandAsync(Message message)
    {
        if (message is null || message.Text is null)
        {
            return;
        }

        if (message.Text.StartsWith("/") is false)
        {
            return;
        }

        _logger.LogInformation($"Incoming message: {message.Text}");

        try
        {
            var task = message.Text switch
            {
                "/start" => HandleStartCommandAsync(message),
                _ => HandleNotAvailableCommandAsync(message)
            };

            await task;
        }
        catch (Exception exception)
        {
            await this._telegramBotClient.SendTextMessageAsync(
                chatId: message.From.Id,
                text: "Sizning so'rovingizda xatolik yuz berdi. Qayta urinib ko'ring");

            return;
        }
    }

    private async Task HandleStartCommandAsync(Message message)
    {
        var buttons = new List<InlineKeyboardButton>()
        {
            new InlineKeyboardButton("⏪")
            {
                CallbackData = $"prev 1"
            },
            new InlineKeyboardButton("⏩")
            {
                CallbackData = $"prev 2"
            }
        };

        await this._telegramBotClient.SendTextMessageAsync(
                chatId: message.From.Id,
                text: "<b>Botimizga xush kelibsiz</b>",
                parseMode: ParseMode.Html,
                replyMarkup: new InlineKeyboardMarkup(buttons));
    }

    private async Task HandleNotAvailableCommandAsync(Message message)
    {
        await this._telegramBotClient.SendTextMessageAsync(
                chatId: message.From.Id,
                text: "Mavjud bo'lmagan komanda kiritildi. " +
                "Tekshirib ko'ring.");
    }
}
