namespace EventBor.Backend.Domain.Entities;

public class EventCategory
{
    public long EventId { get; set; }
    public Event Event { get; set; }


    public long CategoryId { get; set; }
    public Category Category { get; set; }
}
