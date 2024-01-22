using EventBor.Backend.Domain.Entities;

namespace EventBor.Backend.Infrastructure.Database.Repositories;

internal class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context)
    {
    }
}
