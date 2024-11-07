using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SharedUtilities.CustomExceptions;
using UserService.Models.Dto;
using UserService.Models.Entities;
using UserService.Persistence;
using UserService.Services.Contracts;

namespace UserService.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsersService(UserDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;    
            _mapper = mapper;
        }

        public async Task<User> CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public async Task<User> GetUser(int id)
        {
            return await GetUserOrThrowNotFoundException(id);
        }

        private async Task<User> GetUserOrThrowNotFoundException(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new NotFoundException("User not found.");

            return user;
        }
    }
}
