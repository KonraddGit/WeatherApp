using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherAppWeb.Models;

namespace WeatherAppWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private static readonly string WEATHER_API_ID = "4330022d14c558f535c62753c8d5884c";

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> WeatherJson(string city)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid={WEATHER_API_ID}&units=metric&lang=pl");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);
                return Ok(new
                {
                    City = weatherResponse.Name,
                    Temp = weatherResponse.Main.Temp,
                    Summary = weatherResponse.Weather.Select(x => x.Description),
                    Icon = weatherResponse.Weather.Select(x => x.Icon),
                    Wind = weatherResponse.Wind.Speed
                });

            }
        }

    }
}
