using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private static readonly List<WeatherForecast> WeatherForecasts = new List<WeatherForecast>
        {
            new WeatherForecast { Date = DateTime.Now, TemperatureC = 25, Summary = "Güneşli", Humidity = 60, WindSpeed = 10 },
            new WeatherForecast { Date = DateTime.Now.AddDays(1), TemperatureC = 28, Summary = "Parçalı Bulutlu", Humidity = 65, WindSpeed = 15 },
            new WeatherForecast { Date = DateTime.Now.AddDays(2), TemperatureC = 22, Summary = "Yağmurlu", Humidity = 80, WindSpeed = 20 },
        };

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return WeatherForecasts;
        }

        [HttpPost("addDay")]
        public IActionResult AddDay([FromBody] WeatherForecast newDay)
        {
            if (newDay == null || newDay.Date == default || newDay.TemperatureC < -100 || newDay.Humidity < 0 || newDay.WindSpeed < 0)
            {
                return BadRequest("Geçersiz veri.");
            }

            WeatherForecasts.Add(newDay);
            return Ok($"Gün {newDay.Date.ToShortDateString()} başarıyla eklendi.");
        }
    }
}
