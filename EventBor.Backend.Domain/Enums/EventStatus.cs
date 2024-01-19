namespace EventBor.Backend.Domain.Enums;

public enum EventStatus : short
{
    Approved = 1,
    Rejected,
    Cancelled,
    Completed,
    InProcess
}
