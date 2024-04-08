using FeatureFlagsDemo.Core.Entities.Weather;

namespace FeatureFlagsDemo.NetWebApp.Models
{
    public class WeatherViewModel
    {
        public string Location { get; set; }
        public WeatherReport Report { get; set; }
    }
}
