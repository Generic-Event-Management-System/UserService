using UserService.Models.Dto;
using UserService.Models.Entities;

namespace UserService.Services.Contracts
{
    public interface IUsersService
    {
        Task<User> CreateUser(UserDto userDto);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(int userId, UserDto userDto);
    }
}
