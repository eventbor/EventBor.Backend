using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
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
            UpdateType.InlineQuery => HandleInlineQueryAsync(update.InlineQuery),
            UpdateType.CallbackQuery => HandleCallBackQueryAsync(update.CallbackQuery),
            _ => HandleNotAvailableCommandAsync(update.Message)
        };

        await handler;
    }

    private Task HandleCallBackQueryAsync(CallbackQuery? callbackQuery)
    {
        _logger.LogInformation(callbackQuery.Data);

        return Task.CompletedTask;
    }

    private async Task HandleInlineQueryAsync(InlineQuery? inlineQuery)
    {
        List<InlineQueryResult> list = new()
        {
            new InlineQueryResultArticle("2", "Nodir", new InputTextMessageContent("Xayrli kech")),
            new InlineQueryResultArticle("1", "Xondamir", new InputTextMessageContent("Xayrli kun"))
        };

        _logger.LogInformation(inlineQuery.Query);

        await _telegramBotClient.AnswerInlineQueryAsync(inlineQuery.Id, list.ToArray());
    }

    public async Task HandleCommandAsync(Message message)
    {
        _logger.LogInformation(message.Text);

        if (message.Type == MessageType.Voice)
        {
            await _telegramBotClient.SendVoiceAsync(5687861117, message.Voice.FileId);
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
                "/menu" => HandleMenuCommandAsync(message),
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

    private async Task HandleMenuCommandAsync(Message message)
    {
        var buttons = new List<KeyboardButton>()
        {
            new KeyboardButton("Ro'yxat")
            {
                RequestLocation = true,
            },
            new KeyboardButton("Kirish"),
            new KeyboardButton("Kirish"),
            new KeyboardButton("Kirish"),
            new KeyboardButton("Kirish"),
        };

        await this._telegramBotClient.SendTextMessageAsync(
                chatId: message.From.Id,
                text: "<b>Menu</b>",
                parseMode: ParseMode.Html,
                replyMarkup: new ReplyKeyboardMarkup(buttons) { ResizeKeyboard = true });
    }

    private async Task HandleNotAvailableCommandAsync(Message message)
    {
        await this._telegramBotClient.SendTextMessageAsync(
                chatId: message.From.Id,
                text: "Mavjud bo'lmagan komanda kiritildi. " +
                "Tekshirib ko'ring.");
    }
}
