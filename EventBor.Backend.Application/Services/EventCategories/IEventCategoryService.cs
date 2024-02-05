using EventBor.Backend.Application.DTOs.EventCategories;

namespace EventBor.Backend.Application.Services.EventCategories;

public interface IEventCategoryService
{
    Task<bool> RemoveAsync(long id);
    Task<EventCategoryForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<EventCategoryForResultDto>> RetrieveAllAsync();
    Task<EventCategoryForResultDto> AddAsync(EventCategoryForCreationDto createDto);
    Task<EventCategoryForResultDto> ModifyAsync(long id, EventCategoryForUpdateDto updateDto);
}
