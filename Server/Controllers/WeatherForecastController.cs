using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using Server.Services.Implementation;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherInMoscowRepository _repository;
        private readonly IWeatherLoader _weatherLoader;


        public WeatherForecastController(IWeatherInMoscowRepository repository, IWeatherLoader weatherLoader, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _repository = repository;
            _weatherLoader = weatherLoader;
        }

        [HttpGet]
        public async Task<IActionResult> GetTemperature(DateTime date)
        {
            var response = await _weatherLoader.Load(date);
            return Ok(response.Daily.TemperatureMax);
        }

        [HttpPut]
        public async Task<IActionResult> SaveTemperature(DateTime date)
        {
            var response = await _weatherLoader.Load(date);
            var weather = new Models.WeatherInMoscow()
            {
                Date = date.ToUniversalTime(),
                TemperatureC = response.Daily.TemperatureMax.FirstOrDefault()
            };

            _repository.Upload(weather);
            return Ok();
        }
    }
}