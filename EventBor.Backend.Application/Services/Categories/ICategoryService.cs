using EventBor.Backend.Application.DTOs;
using EventBor.Backend.Application.DTOs.Categories;

namespace EventBor.Backend.Application.Services.Categories;

public interface ICategoryService
{
    Task<bool> RemoveAsync(long id);
    Task<CategoryForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CategoryForResultDto>> RetrieveAllAsync();
    Task<CategoryForResultDto> AddAsync(CategoryForCreationDto createDto);
    Task<CategoryForResultDto> ModifyAsync(long id, CategoryForUpdateDto updateDto);
}
