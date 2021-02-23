using DotNetService.Clients;
using DotNetService.Data;
using DotNetService.Services;
using DotNetService.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

// Exceptionally, this class must be in the Vtex namespace so the startup extender works.
namespace Vtex
{
    public class StartupExtender
    {
        // This method is called inside Startup's constructor.
        // You can use it to build a custom configuration.
        public void ExtendConstructor(IConfiguration config, IWebHostEnvironment env)
        {
        }

        // This method is called inside Startup.ConfigureServices()
        public void ExtendConfigureServices(IServiceCollection services)
        {
            // No need to AddMvc() or AddControllers()
            // We're adding the RefitExceptionHandler as a global filter here
            services.Configure<MvcOptions>(opt => opt.Filters.Add(new RefitExceptionHandler()));

            // The repository is then configured according to the VtexHttpClient settings and the interface specs
            services.AddRefitClient<IProductRepository>()
                .ConfigureHttpClient(VtexHttpClient.Configure);

            // Don't forget to register all injectable classes, including services
            services.AddScoped<IProductService, ProductService>();
        }

        // This method is called inside Startup.Configure() before calling app.UseRouting()
        public void ExtendConfigureBeforeRouting(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }

        // This method is called inside Startup.Configure() before calling app.UseEndpoint()
        public void ExtendConfigureBeforeEndpoint(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }

        // This method is called inside Startup.Configure() after calling app.UseEndpoint()
        public void ExtendConfigureAfterEndpoint(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}