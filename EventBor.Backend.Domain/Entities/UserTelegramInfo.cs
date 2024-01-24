namespace EventBor.Backend.Domain.Entities;

public class UserTelegramInfo
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long TelegramId { get; set; }
}
