using EventBor.Backend.Domain.Entities;

namespace EventBor.Backend.Infrastructure.Database.Repositories;

internal class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context)
    {   }
}
