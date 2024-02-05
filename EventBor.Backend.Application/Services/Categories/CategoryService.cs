using AutoMapper;
using EventBor.Backend.Application.Commons.Exceptions;
using EventBor.Backend.Application.DTOs.Categories;
using EventBor.Backend.Domain.Entities;
using EventBor.Backend.Infrastructure.Database.Repositories.Categories;
using Microsoft.EntityFrameworkCore;

namespace EventBor.Backend.Application.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, 
        IMapper mapper)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryForResultDto> AddAsync(CategoryForCreationDto createDto)
    {
        var category = await _categoryRepository.SelectAll()
            .Where(c => c.Name == createDto.Name)
            .FirstOrDefaultAsync();

        if (category is not null)
            throw new CustomException(403, "Category is already exists");

        var mappedCategory = _mapper.Map<Category>(createDto);

        var result = await _categoryRepository.InsertAsync(mappedCategory);

        return _mapper.Map<CategoryForResultDto>(result);
    }

    public async Task<CategoryForResultDto> ModifyAsync(long id, CategoryForUpdateDto updateDto)
    {
        var category = await _categoryRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

        if (category is null)
            throw new CustomException(404, "Category is not found");

        var mappedCategory = _mapper.Map(updateDto, category);

        var result = await _categoryRepository.UpdateAsync(mappedCategory);

        return _mapper.Map<CategoryForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var category = await _categoryRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        if (category is null)
            throw new CustomException(404, "Category is not found");

        var result = await _categoryRepository.SelectByIdAsync(id);

        await _categoryRepository.DeleteAsync(result);

        return true;
    }

    public async Task<IEnumerable<CategoryForResultDto>> RetrieveAllAsync()
    {
        var categories = await _categoryRepository.SelectAll()
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<CategoryForResultDto>>(categories);
    }

    public async Task<CategoryForResultDto> RetrieveByIdAsync(long id)
    {
        var category = await _categoryRepository.SelectAll()
            .Where(c => c.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (category is null)
            throw new CustomException(404, "Category is not found");

        return _mapper.Map<CategoryForResultDto>(category);
    }
}
