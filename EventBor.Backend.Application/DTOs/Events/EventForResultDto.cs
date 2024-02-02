using EventBor.Backend.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace EventBor.Backend.Application.DTOs.Events;

public class EventForResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime StartedAt { get; set; }
    public string Duration { get; set; }
    public EventFormat Format { get; set; }
    public string Platform { get; set; }
    public IFormFile Banner { get; set; }
    public EventStatus Status { get; set; }
    public string Orginizer { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Address { get; set; }
    public bool IsPaid { get; set; }
    public decimal Price { get; set; }
    public string RegistrationLink { get; set; }
    public int Capacity { get; set; }
    public string Contact { get; set; }
    public string OfficialPage { get; set; }
}
