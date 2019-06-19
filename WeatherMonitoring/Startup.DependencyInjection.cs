using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using WeatherMonitoring.Api.Modules;
using WeatherMonitoring.Api.Modules.Extensions;

namespace WeatherMonitoring.Api
{
    public partial class Startup
    {
        private readonly Container _container = new Container();

        public void ConfigureDependencyInjection(IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services
                .AddSingleton<IControllerActivator>(
                    new SimpleInjectorControllerActivator(_container))
                .EnableSimpleInjectorCrossWiring(_container);

            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        public void UseDependencyInjection(IApplicationBuilder app)
        {
            _container.RegisterMvcControllers(app);

            RegisterModules();
        }

        public void RegisterModules()
        {
            _container.RegisterModule<InfrastructureModule>(Configuration);

            _container.Verify();
        }
    }
}
