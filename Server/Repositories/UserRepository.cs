
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.Repositories
{

    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private WeatherContext _dbContext;
        public UserRepository(WeatherContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> Get(int id)
        {
            return await _dbContext.Users.Where(_ => _.Id == id).ToListAsync();
        }

        public async Task<bool> Authenticate(string login, string password)
        {
            //времянка пока не загнал в БД пару пользователей
            return true;
            if (await _dbContext.Users.SingleOrDefaultAsync(x => x.Username == login && x.Password == password) != null)
            {
                return true;
            }
            return false;
        }
    }
}
