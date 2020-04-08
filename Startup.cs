using FacileBudget.Models.Options;
using FacileBudget.Models.Services.Application;
using FacileBudget.Models.Services.Infrastructure;
using FacileBudget.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacileBudget
{
    public class Startup
    {
         public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblyContaining<SpeseCreateValidator>();
            })

            #if DEBUG
            .AddRazorRuntimeCompilation()
            #endif
            ;

            // Database
            services.AddTransient<ISpeseService, AdoNetSpeseService>();
            services.AddTransient<IDatabaseAccessor, SqliteDatabaseAccessor>();

            // Options
            services.Configure<SpeseOptions>(Configuration.GetSection("Spese"));
            services.Configure<ConnectionStringsOptions>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseResponseCaching();

            app.UseEndpoints(routeBuilder => {
                routeBuilder.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
