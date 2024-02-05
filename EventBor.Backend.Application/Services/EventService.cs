﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EventBor.Backend.Domain.Entities;
using EventBor.Backend.Application.DTOs.Events;
using EventBor.Backend.Application.Commons.Exceptions;
using EventBor.Backend.Infrastructure.Database.Repositories;

namespace EventBor.Backend.Application.Services;

public class EventService : IEventService
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public EventService(IMapper mapper, IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }
    public async Task<EventForResultDto> AddAsync(EventForCreationDto dto)
    {
        var eventData = await _eventRepository
            .SelectAll()
            .Where(e => e.Title.ToLower() == dto.Title.ToLower())
            .FirstOrDefaultAsync();

        if(eventData is not null)
            throw new CustomException(409,"Event is already exist");

        var mappedEventData = _mapper.Map<Event>(dto);

        return _mapper.Map<EventForResultDto>(await _eventRepository.InsertAsync(mappedEventData));
    }

    public async Task<EventForResultDto> ModifyAsync(long id, EventForUpdateDto dto)
    {
        var eventData = await _eventRepository
            .SelectAll()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();

        if(eventData is null)
            throw new CustomException(404,"Event not found");

        var mappedEventData = _mapper.Map(dto, eventData);
        return _mapper.Map<EventForResultDto>(_eventRepository.UpdateAsync(mappedEventData));
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var eventData = await _eventRepository
            .SelectAll()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        if (eventData is null)
            throw new CustomException(404,"Event not found");

        await _eventRepository.DeleteAsync(eventData);

        return true;
    }

    public async Task<IEnumerable<EventForResultDto>> RetrieveAllAsync()
    {
        var allEventData = await _eventRepository
            .SelectAll()
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return _mapper.Map<IEnumerable<EventForResultDto>>(allEventData);
    }

    public async Task<EventForResultDto> RetrieveByIdAsync(long id)
    {
        var eventData = await _eventRepository
            .SelectAll()
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (eventData is null)
            throw new CustomException(404, "Event is not found");

        return _mapper.Map<EventForResultDto>(eventData);
    }
}