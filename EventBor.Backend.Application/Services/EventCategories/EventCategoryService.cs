using AutoMapper;
using EventBor.Backend.Application.Commons.Exceptions;
using EventBor.Backend.Application.DTOs.Categories;
using EventBor.Backend.Application.DTOs.EventCategories;
using EventBor.Backend.Domain.Entities;
using EventBor.Backend.Infrastructure.Database.Repositories.Categories;
using EventBor.Backend.Infrastructure.Database.Repositories.EventCategories;
using Microsoft.EntityFrameworkCore;

namespace EventBor.Backend.Application.Services.EventCategories;

public class EventCategoryService : IEventCategoryService
{
    private readonly IMapper _mapper;
    private readonly IEventCategoryRepository _repository;

    public EventCategoryService(IMapper mapper, IEventCategoryRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<EventCategoryForResultDto> AddAsync(EventCategoryForCreationDto createDto)
    {
        var CheckEventId = await _repository.SelectAll()
            .AsNoTracking()
            .Where(e => e.EventId == createDto.EventId)
            .FirstOrDefaultAsync();

        if (CheckEventId is not null)
            throw new CustomException(409, "Event already exists");

        var CheckCategoryId = await _repository.SelectAll()
            .AsNoTracking()
            .Where(c => c.EventId == createDto.EventId)
            .FirstOrDefaultAsync();

        if (CheckCategoryId is not null)
            throw new CustomException(409, "Category already exists");

        var mapped = _mapper.Map<EventCategory> (createDto);
        var result = await _repository.InsertAsync(mapped);
        return _mapper.Map<EventCategoryForResultDto>(result);

    }

    public async Task<EventCategoryForResultDto> ModifyAsync(long id, EventCategoryForUpdateDto updateDto)
    {
        var CheckById = await _repository.SelectAll()
            .AsNoTracking()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();

        if (CheckById is null)
            throw new CustomException(404, "Not Found");

        var mapped = _mapper.Map(updateDto, CheckById);
        var result = _repository.UpdateAsync(mapped);
        return _mapper.Map<EventCategoryForResultDto>(result);

    }

    public async Task<bool> RemoveAsync(long id)
    {
        var CheckById = await _repository.SelectAll()
            .AsNoTracking()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();

        if (CheckById is null)
            throw new CustomException(404, "Not Found");

        await _repository.DeleteAsync(CheckById);
        return true;
    }

    public async Task<IEnumerable<EventCategoryForResultDto>> RetrieveAllAsync()
    {
        var eventcategories = await _repository.SelectAll()
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<EventCategoryForResultDto>>(eventcategories);
    }

    public async Task<EventCategoryForResultDto> RetrieveByIdAsync(long id)
    {
        var CheckById = await _repository.SelectAll()
            .AsNoTracking()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();

        if (CheckById is null)
            throw new CustomException(404, "Not Found");

        return _mapper.Map<EventCategoryForResultDto>(CheckById);
    }
}
