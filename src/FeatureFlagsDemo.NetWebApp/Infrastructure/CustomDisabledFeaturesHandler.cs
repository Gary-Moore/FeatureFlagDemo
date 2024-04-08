using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlagsDemo.NetWebApp.Infrastructure
{
    public class CustomDisabledFeaturesHandler : IDisabledFeaturesHandler
    {
        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
            context.Result = new ContentResult()
            {
                ContentType = "text/plain",
                Content = "Feature is disabled",
                StatusCode = StatusCodes.Status403Forbidden
            };

            return Task.CompletedTask;
        }
    }
}
