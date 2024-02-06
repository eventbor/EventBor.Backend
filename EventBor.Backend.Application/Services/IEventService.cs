﻿using EventBor.Backend.Application.DTOs.Events;

namespace EventBor.Backend.Application.Services;

public interface IEventService
{
    Task<bool> RemoveAsync(long id);
    Task<EventForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<EventForResultDto>> RetrieveAllAsync();
    Task<EventForResultDto> AddAsync(EventForCreationDto dto);
    Task<EventForResultDto> ModifyAsync(long id, EventForUpdateDto dto);
}
