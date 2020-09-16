using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SpacePark.API
{
    public class Program
    {
        //Test comment
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
