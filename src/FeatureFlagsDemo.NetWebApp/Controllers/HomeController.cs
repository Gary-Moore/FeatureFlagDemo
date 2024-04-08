using FeatureFlagsDemo.Core;
using FeatureFlagsDemo.NetWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace FeatureFlagsDemo.NetWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeatureManager _featureManager;

        public HomeController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new WelcomeViewModel();

            if (await _featureManager.IsEnabledAsync(AppFeatureFlags.Welcome)) 
            {
                model.ShowWelcomeMessage = true;
                model.WelcomeMessage = "Welcome to the feature flagging extraordinaire...";
            }            

            return View(model);
        }
    }
}
