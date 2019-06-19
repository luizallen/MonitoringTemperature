using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System;

namespace WeatherMonitoring.Api.Modules.Extensions
{

    public static class ContainerExtensions
    {
        public static void RegisterModule<T>(
            this Container container,
            IConfiguration configuration) where T : IModule
        {
            var t = Activator.CreateInstance<T>() as IModule;

            t.Load(container, configuration);
        }
    }
}
