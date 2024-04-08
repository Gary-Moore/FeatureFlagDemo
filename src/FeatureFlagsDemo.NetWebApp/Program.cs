using Autofac;
using Autofac.Extensions.DependencyInjection;
using FeatureFlagsDemo.Core;
using FeatureFlagsDemo.NetWebApp.Infrastructure;
using FeatureFlagsDemo.NetWebApp.Infrastructure.Filters;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModule());
    });

builder.Services.AddControllersWithViews(options =>
{
    // Config for controlling ActionFilter behavior via feature flag
    options.Filters.AddForFeature<SlowDownActionFilter>(AppFeatureFlags.SlowDown);
});

// setup for .NET feature flag management and custom handler for disabled features
builder.Services.AddFeatureManagement()
    .UseDisabledFeaturesHandler(new CustomDisabledFeaturesHandler())
    .AddFeatureFilter<PercentageFilter>();

builder.Services.AddAzureAppConfiguration();

// configuration for Azure App Configuration
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(builder.Configuration.GetConnectionString("AppConfig"))
    .UseFeatureFlags();
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// enable Azure App Configuration
app.UseAzureAppConfiguration();

// enable middleware for feature flag
//app.UseMiddlewareForFeature<MiddleWare>(AppFeatureFlags.Feature);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
