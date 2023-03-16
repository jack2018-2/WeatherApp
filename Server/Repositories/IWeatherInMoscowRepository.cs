using Server.Models;

namespace Server.Repositories
{
    public interface IWeatherInMoscowRepository
    {
        Task<IEnumerable<WeatherInMoscow>> Get();
        Task<IEnumerable<WeatherInMoscow>> Get(int id);
        Task Upload(WeatherInMoscow weather);
    }
}