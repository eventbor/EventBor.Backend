using EventBor.Backend.Application.DTOs;
using EventBor.Backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventBor.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(CreateUserDto createUserDto)
        {
            return Ok(await _userService.CreateUserAsync(createUserDto));
        }
    }
}
