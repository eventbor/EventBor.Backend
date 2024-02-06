using Microsoft.AspNetCore.Mvc;
using EventBor.Backend.Application.Services;
using EventBor.Backend.Application.DTOs.Events;

namespace EventBor.Backend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] EventForCreationDto dto)
        => Ok(await _eventService.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _eventService.RetrieveAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _eventService.RetrieveByIdAsync(id));


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _eventService.RemoveAsync(id));


    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] EventForUpdateDto dto)
        => Ok(await _eventService.ModifyAsync(id, dto));
}
