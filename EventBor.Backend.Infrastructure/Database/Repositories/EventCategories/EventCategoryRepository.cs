using EventBor.Backend.Domain.Entities;

namespace EventBor.Backend.Infrastructure.Database.Repositories.EventCategories;

internal class EventCategoryRepository : Repository<EventCategory>, IEventCategoryRepository
{
    public EventCategoryRepository(AppDbContext context) : base(context)
    {
    }
}
