using Autofac;
using System.Reflection;

namespace FeatureFlagsDemo.NetWebApp.Infrastructure
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            var assemblies = executingAssembly.GetReferencedAssemblies()
                .Select(Assembly.Load)
                .Where(x => x.Location.Contains("FeatureFlagsDemo.Core"))
            .ToList();

            assemblies.Add(executingAssembly);

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .AsImplementedInterfaces()
                .AsSelf();
        }
    }
}
