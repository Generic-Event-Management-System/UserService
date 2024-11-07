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
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUser(int userId)
        {
            return await GetUserOrThrowNotFoundException(userId);
        }

        public async Task<User> UpdateUser(int userId, UserDto userDto)
        {
            var user = await GetUserOrThrowNotFoundException(userId);

            _mapper.Map(userDto, user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        private async Task<User> GetUserOrThrowNotFoundException(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                throw new NotFoundException("User not found.");

            return user;
        }
    }
}
