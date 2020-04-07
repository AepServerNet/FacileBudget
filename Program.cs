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
                        // Usare solo per il debug, lasciare commentato per il deploy su IIS
                        //.UseUrls("http://localhost:81")
                        //.UseKestrel()
                        // Per eseguire il deploy lanciare il comando: dotnet publish --configuration Release
                        .UseStartup<Startup>()
                        .UseSerilog((webHostBuilderContext, loggerConfiguration) => 
                        {
                            loggerConfiguration.ReadFrom.Configuration(webHostBuilderContext.Configuration);
                        });
                });
    }
}