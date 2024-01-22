using EventBor.Backend.Domain.Entities.Commons;

namespace EventBor.Backend.Domain.Entities;

public class EventCategory : Auditable
{
    public long EventId { get; set; }
    public Event Event { get; set; }


    public long CategoryId { get; set; }
    public Category Category { get; set; }
}
