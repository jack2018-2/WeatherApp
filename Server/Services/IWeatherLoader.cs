using Server.Models;

namespace Server.Services.Implementation
{
    public interface IWeatherLoader
    {
        Task<OpenMeteoTemperatureReponse> Load(DateTime date);
    }
}