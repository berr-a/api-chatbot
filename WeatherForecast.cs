using System;

namespace WeatherAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }
    }
}
