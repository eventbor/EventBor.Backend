namespace EventBor.Backend.Application.DTOs;

public record CreateUserDto(
    string FirstName,
    string LastName,
    string? UserName,
    string PhoneNumber,
    long TelegramId
);
