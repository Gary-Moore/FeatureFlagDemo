using FeatureFlagsDemo.Core.Entities.Weather;

namespace FeatureFlagsDemo.Core.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherReport> GetWeatherAsync(string location);
    }
}

