using Microsoft.AspNetCore.Mvc.Filters;

namespace FeatureFlagsDemo.NetWebApp.Infrastructure.Filters
{
    public class SlowDownActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await Task.Delay(5000);
            await next();
        }
    }
}
