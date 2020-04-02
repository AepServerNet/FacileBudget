using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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
                    .UseUrls("http://*:8080")
                    .UseKestrel()
                    .UseStartup<Startup>();
                });
    }
}
