using FeatureFlagsDemo.Core.Entities.Weather;
using FeatureFlagsDemo.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace FeatureFlagsDemo.Core.Services
{
    public class WeatherService : IWeatherService
    {
        static readonly HttpClient client = new HttpClient();
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;

        public WeatherService(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiKey = _configuration["WeatherApiKey"];
        }

        public async Task<WeatherReport> GetWeatherAsync(string location)
        {
            var response = await client.GetAsync($"https://api.weatherapi.com/v1/current.json?q={location}&key={_apiKey}");
            var content = await response.Content.ReadFromJsonAsync<WeatherReport>();
            return content;
        }
    }
}
