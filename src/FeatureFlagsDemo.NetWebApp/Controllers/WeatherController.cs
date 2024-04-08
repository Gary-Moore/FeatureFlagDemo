using FeatureFlagsDemo.Core;
using FeatureFlagsDemo.Core.Interfaces;
using FeatureFlagsDemo.NetWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlagsDemo.NetWebApp.Controllers
{
    [FeatureGate(AppFeatureFlags.Weather)]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new WeatherViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetCurrentWeather(WeatherViewModel model)
        {
            var result = await _weatherService.GetWeatherAsync(model.Location);

            model.Report = result;

            return View("Index", model);
        }
    }
}
