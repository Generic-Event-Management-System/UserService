using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dto;
using UserService.Services.Contracts;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService) 
        {
            _usersService = usersService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            return Ok(await _usersService.CreateUser(userDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _usersService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _usersService.GetUser(id));
        }
    }
}
