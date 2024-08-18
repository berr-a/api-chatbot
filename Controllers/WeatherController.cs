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
        // Örnek hava durumu verileri
        private static readonly List<WeatherForecast> WeatherForecasts = new List<WeatherForecast>
        {
            new WeatherForecast { Date = DateTime.Now, TemperatureC = 25, Summary = "Güneşli", Humidity = 60, WindSpeed = 10 },
            new WeatherForecast { Date = DateTime.Now.AddDays(1), TemperatureC = 28, Summary = "Parçalı Bulutlu", Humidity = 65, WindSpeed = 15 },
            new WeatherForecast { Date = DateTime.Now.AddDays(2), TemperatureC = 22, Summary = "Yağmurlu", Humidity = 80, WindSpeed = 20 },
            new WeatherForecast { Date = DateTime.Now.AddDays(3), TemperatureC = 24, Summary = "Rüzgarlı", Humidity = 70, WindSpeed = 12 },
            new WeatherForecast { Date = DateTime.Now.AddDays(4), TemperatureC = 26, Summary = "Açık", Humidity = 55, WindSpeed = 8 },
            new WeatherForecast { Date = DateTime.Now.AddDays(5), TemperatureC = 27, Summary = "Güneşli", Humidity = 60, WindSpeed = 10 },
        };

        // GET: /Weather?days=5
        [HttpGet]
        public IActionResult GetWeatherForecast([FromQuery] int days = 15)
        {
            // days parametresi 1 ile 15 arasında olmalı
            if (days < 1 || days > 15)
            {
                return BadRequest("Gün sayısı 1 ile 15 arasında olmalıdır."); // Hatalı parametre için hata döndür
            }

            var forecasts = WeatherForecasts.Take(days).ToList();
            return Ok(forecasts); // Hava durumu verilerini döndür
        }

        // POST: /Weather/addDay
        [HttpPost("addDay")]
        public IActionResult AddDay([FromBody] WeatherForecast newDay)
        {
            if (newDay == null || newDay.Date == default || newDay.TemperatureC < -100 || newDay.Humidity < 0 || newDay.WindSpeed < 0)
            {
                return BadRequest("Geçersiz veri."); // Geçersiz veri için hata döndür
            }

            WeatherForecasts.Add(newDay);

            return Ok(new
            {
                Message = $"Gün {newDay.Date.ToShortDateString()} başarıyla eklendi.",
                AddedDay = newDay // Eklenen günü detaylı bilgi ile döndür
            });
        }
    }
}
