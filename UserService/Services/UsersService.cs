using UserService.Persistence;
using UserService.Services.Contracts;

namespace UserService.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserDbContext _dbContext;

        public UsersService(UserDbContext dbContext) 
        {
            _dbContext = dbContext;    
        }
    }
}
