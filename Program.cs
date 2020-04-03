using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace FacileBudget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseUrls("http://localhost:8080")
                    .UseKestrel()
                    .UseStartup<Startup>()
                    .UseSerilog((webHostBuilderContext, loggerConfiguration) => 
                    {
                        loggerConfiguration.ReadFrom.Configuration(webHostBuilderContext.Configuration);
                    });
                });
    }
}