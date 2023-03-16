using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories
{
    /// <summary>
    /// Репозиторий погоды в Москве
    /// </summary>
    public class WeatherInMoscowRepository : IWeatherInMoscowRepository
    {
        private WeatherContext _dbContext;
        public WeatherInMoscowRepository(WeatherContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<WeatherInMoscow>> Get()
        {
            return await _dbContext.WeathersInMoscow.ToListAsync();
        }

        public async Task<IEnumerable<WeatherInMoscow>> Get(int id)
        {
            return await _dbContext.WeathersInMoscow.Where(_ => _.Id == id).ToListAsync();
        }

        public async Task Upload(WeatherInMoscow weather)
        {
            _dbContext.Add(weather);
            await _dbContext.SaveChangesAsync();
        }
    }
}
