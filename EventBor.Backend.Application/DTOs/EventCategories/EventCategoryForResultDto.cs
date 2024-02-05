using EventBor.Backend.Application.DTOs.Categories;
using EventBor.Backend.Application.DTOs.Events;

namespace EventBor.Backend.Application.DTOs.EventCategories;

public class EventCategoryForResultDto
{
    public long Id { get; set; }
    public CategoryForResultDto Category { get; set; }
    public EventForResultDto Event { get; set; }
}
