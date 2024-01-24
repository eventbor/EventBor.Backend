using EventBor.Backend.TelegramBot.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace EventBor.Backend.API.Controllers;

[Route("bot")]
[ApiController]
public class BotController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] Update update,
        [FromServices] UpdateHandler updateHandler)
    {
        await updateHandler
            .UpdateHandlerAsync(update);

        return Ok();
    }
}
