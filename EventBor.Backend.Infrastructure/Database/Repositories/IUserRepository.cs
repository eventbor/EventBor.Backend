using EventBor.Backend.Domain.Entities;

namespace EventBor.Backend.Infrastructure.Database.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> VerifyTelegramId(long telegramId);
}
