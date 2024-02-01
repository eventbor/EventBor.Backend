using EventBor.Backend.Domain.Entities.Commons;

namespace EventBor.Backend.Domain.Entities;

public class UserTelegramInfo : Auditable
{
    public long UserId { get; set; }
    public long TelegramId { get; set; }
}
