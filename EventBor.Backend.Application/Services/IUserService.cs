using EventBor.Backend.Application.DTOs;
using EventBor.Backend.Domain.Entities;

namespace EventBor.Backend.Application.Services;

public interface IUserService
{
    Task<User> CreateUserAsync(CreateUserDto createUserDto);
    List<User> GetUsers();
    Task<User> GetUserByIdAsync(long id);
    Task<User> ModifyUserAsync(User user);
    Task<User> RemoveUserAsync(long id);
}
