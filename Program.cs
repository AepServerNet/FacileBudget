using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace FacileBudget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHostBuilder => {
                    webHostBuilder
                        // Usare solo per il debug, lasciare commentato per il deploy su IIS
                        //.UseStartup<Startup>();

                        // Per eseguire il deploy su IIS, decommentare il codice sottostante e lanciare il comando: dotnet publish --configuration Release
                        .UseStartup<Startup>()
                        .UseSerilog((webHostBuilderContext, loggerConfiguration) => 
                        {
                            loggerConfiguration.ReadFrom.Configuration(webHostBuilderContext.Configuration);
                        });
                });
    }
}