using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace Server.Services.Implementation
{
    public class WeatherLoader : IWeatherLoader
    {
        private OpenMeteoTemperatureReponse _apiResponse;

        private ILogger _logger;

        private string _URL;

        private string _datePlaceholder = "{DATE}";

        public WeatherLoader(IConfiguration configuration, ILogger<WeatherLoader> logger)
        {
            _logger = logger;
            _URL = configuration.GetSection("WeatherURL").Value;
        }

        //todo здесь надо бы нормально обработать экспешны
        public async Task<OpenMeteoTemperatureReponse> Load(DateTime date)
        {
            _logger.LogInformation($"Запущен процесс получения температуры за {DateTime.Now.Date}");
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var responseRaw = await client.GetAsync(
                        _URL.Replace(_datePlaceholder, date.ToString("yyyy-MM-dd"))
                        );
                    var json = await responseRaw.Content.ReadAsStringAsync();
                    _apiResponse = JsonSerializer.Deserialize<OpenMeteoTemperatureReponse>(json);
                }
                _logger.LogInformation($"Температура на {DateTime.Now.Date} получена");
                return _apiResponse;
            }
            catch (Exception e)
            {
                var msg = "Не удалось получить температуру";
                throw new BadHttpRequestException(msg);
            }
        }
    }
}
