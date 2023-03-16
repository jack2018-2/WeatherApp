using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    /// <summary>
    /// Погода в мск по дням
    /// </summary>
    public class WeatherInMoscow : BaseModel
    {
        static WeatherInMoscow()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Температура в градусах цельсия
        /// </summary>
        public double TemperatureC { get; set; }

        /// <summary>
        /// Вычисляемая температура в градусах Фаренгейта
        /// </summary>
        [NotMapped]
        public double TemperatureF => 32 + (TemperatureC / 0.5556);
    }
}
