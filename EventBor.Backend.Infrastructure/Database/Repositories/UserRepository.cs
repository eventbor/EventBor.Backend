using EventBor.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBor.Backend.Infrastructure.Database.Repositories;

internal class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<bool> VerifyTelegramId(long telegramId)
    {
        return await _context
            .Set<UserTelegramInfo>()
            .AnyAsync(p => p.TelegramId == telegramId);
    }
}
