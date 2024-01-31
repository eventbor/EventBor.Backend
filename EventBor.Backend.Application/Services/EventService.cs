using EventBor.Backend.Application.DTOs.Events;
using EventBor.Backend.Infrastructure.Database.Repositories;

namespace EventBor.Backend.Application.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public Task<EventForResultDto> AddAsync(EventForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<EventForResultDto> ModifyAsync(long id, EventForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EventForResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EventForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
