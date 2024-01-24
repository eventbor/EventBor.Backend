using EventBor.Backend.Application.DTOs;
using EventBor.Backend.Domain.Entities;
using EventBor.Backend.Infrastructure.Database.Repositories;

namespace EventBor.Backend.Application.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(CreateUserDto createUserDto)
    {
        if (await _userRepository.VerifyTelegramId(createUserDto.TelegramId))
        {
            throw new Exception("User already exists");
        }

        var user = new User
        {
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
            UserName = createUserDto.UserName,
            PhoneNumber = createUserDto.PhoneNumber,
            UserTelegramInfo = new UserTelegramInfo
            {
                TelegramId = createUserDto.TelegramId,
            }
        };

        return await _userRepository.InsertAsync(user);
    }

    public List<User> GetUsers()
    {
        return _userRepository.SelectAll().ToList();
    }

    public async Task<User> GetUserByIdAsync(long id)
    {
        return await _userRepository.SelectByIdAsync(id);
    }

    public async Task<User> ModifyUserAsync(User user)
    {
        return await _userRepository.UpdateAsync(user);
    }

    public async Task<User> RemoveUserAsync(long id)
    {
        var user = await _userRepository.SelectByIdAsync(id);

        return await _userRepository.DeleteAsync(user);
    }
}
